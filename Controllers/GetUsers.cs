using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Jwt.Interface;

namespace WebApi_Jwt.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GetUsers : ControllerBase
    {
        public IUsers _users;

        public GetUsers(IUsers users)
        {
            _users = users;
        }

        [HttpGet(Name = "GetUsers")]
        [Authorize]
        public string Users()
        {
            var users = _users.GetAllUsers();
            return users;
        }
    }
}
