using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoginRegister;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        String[] usernames =
        {
             "Rakha",
             "Joshua",
             "Aufa",
             "Dzawin",
             "Yousef",
             "John",
             "Steve",
             "Alan"
        };

        string[] docUsernames =
        {
            
        };



        [HttpGet("{id}")]
        public string Get(int id)
        {
            return usernames[id];
        }

        [HttpGet]
        public string[] Get()
        {
            return usernames;
        }
    }
}
