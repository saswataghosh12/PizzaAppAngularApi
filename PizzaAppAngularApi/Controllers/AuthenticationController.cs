using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAppAngularApi.Models;
using PizzaAppAngularApi.Models.Request;
using PizzaAppAngularApi.Models.Response;
using PizzaAppAngularApi.Services;
using System.Threading.Tasks;

namespace PizzaAppAngularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ResponseModel>> SignUp(User userModel)
        {
            return await _userService.SaveUser(userModel);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var response = new LoginResponse();
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return BadRequest();
            var user = await _userService.GetUserDetailsByEmailPassword(request.Email,request.Password);
            if(user == null)
            {
                response.IsSuccess = false;
                response.Messsage = Constants.UserNotExistMessage;
                return NotFound(response);
            }
            response.IsSuccess = true;
            response.Messsage = Constants.SuccessMessage;
            response.User = user;
            return Ok(response);

        }
    }
}
