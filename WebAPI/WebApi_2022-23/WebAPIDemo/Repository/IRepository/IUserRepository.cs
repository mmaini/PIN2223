using System.Threading.Tasks;
using WebAPIDemo.Models;
using WebAPIDemo.Models.Dto;

namespace WebAPIDemo.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDto> Login(LoginRequestDto dto);
        Task<LocalUser> Register(RegistrationRequestDto dto);
    }
}
