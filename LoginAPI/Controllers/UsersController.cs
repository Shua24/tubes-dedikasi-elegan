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
        static String[] usernames =
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

        static string[] passwords =
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

        private List<string> usernameList = usernames.ToList();
        private List<string> passwordsList = passwords.ToList();

        List<Users> userList = usernames
        .Zip(passwords, (user, pass) => new Users(user, pass))
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
