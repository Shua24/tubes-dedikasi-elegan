using LoginRegister;

namespace LoginAPI
{
    public class Users
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Users(string username, string password)
        {
            Username = username;
            Password = UserLogin.Hasher.HashPassword(password);
        }
    }
}
