using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Data;
using WebAPIDemo.Models;
using WebAPIDemo.Models.Dto;
using WebAPIDemo.Repository.IRepository;

namespace WebAPIDemo.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private string _secretKey;
        public UserRepository(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string username)
        {
            var user = _db.LocalUsers.FirstOrDefault(x => x.UserName == username);
            if (user == null) return true;
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto dto)
        {
            var user = _db.LocalUsers.FirstOrDefault(x => x.UserName.ToLower() == dto.UserName.ToLower() &&
                                                    x.Password.ToLower() == dto.Password.ToLower());

            if (user == null) return null;

            //generiranje JWT Tokena
            var tokenHandler = new JwtSecurityTokenHandler();
            //pretvori u byte array
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDto response = new LoginResponseDto()
            {
                User = user,
                Token = tokenHandler.WriteToken(token)
            };

            return response;
        }

        public async Task<LocalUser> Register(RegistrationRequestDto dto)
        {
            LocalUser user = new LocalUser()
            {
                UserName = dto.UserName,
                Role = dto.Role,
                Password = dto.Password,
                Name = dto.Name
            }; 
            await _db.LocalUsers.AddAsync(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
