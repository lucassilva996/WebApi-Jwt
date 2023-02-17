using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Jwt.Models;
using WebApi_Jwt.Repositories;
using WebApi_Jwt.Services;

namespace WebApi_Jwt.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Autentication([FromBody] User model)
        {
            var user = UsersRepository.Get(model.Username, model.Password);

            if(user == null)
            {
                return NotFound(new { message = "Usuário e senha digitados são inválidos!" });
            }

            var token = TokenGeneratorService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }
    }
}
