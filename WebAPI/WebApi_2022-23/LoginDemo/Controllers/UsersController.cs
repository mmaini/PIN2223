using LoginDemo.Models;
using LoginDemo.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoginDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private ApiResponse _response;

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _response = new ApiResponse();
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse>> Login([FromBody] LoginRequestDto dto)
        {
            var loginResponse = await _userRepo.Login(dto);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Invalid username or password");

            }
            else
            {
                _response.Result = loginResponse;
            }
            return _response;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> Register([FromBody] RegistrationRequestDto dto)
        {
            bool isUsernameUnique = _userRepo.IsUniqueUser(dto.UserName);
            if (!isUsernameUnique)
            {
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add("Bad username");
            }
            else
            {
                var user = await _userRepo.Register(dto);
                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error while registering");
                }
            }

            return _response;
        }
    }
}
