using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoginRegister;
using Microsoft.AspNetCore.Identity;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static string[] s_username =
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

        static string[] s_password =
        {
            "galih",
            "daniel",
            "taqiyya",
            "nuha",
            "gumilar",
            "doe",
            "allen",
            "bob"
        };

        private List<string> usernameList = s_username.ToList();
        private List<string> passwordsList = s_password.ToList();

        List<Users> userList = s_username
        .Zip(s_password, (user, pass) => new Users(user, pass))
        .ToList();

        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return userList[id];
        }

        [HttpGet]
        public List<Users> Get()
        {
            return userList;
        }
    }
}
