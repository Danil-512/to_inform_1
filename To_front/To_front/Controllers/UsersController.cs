using Microsoft.AspNetCore.Mvc;
using To_front.Models;

namespace To_front.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new[]
            {
                new User { User_login  = "user1", User_password = "pass by user1" }
                ,new User { User_login = "user2", User_password = "pass by user2" }
                ,new User { User_login = "user3", User_password = "pass by user3" }
                ,new User { User_login = "user4", User_password = "pass by user4" }
            };
        }
    }
}
