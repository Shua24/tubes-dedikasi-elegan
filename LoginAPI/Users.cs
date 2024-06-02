using LoginRegister;

namespace LoginAPI
{
    public class Users
    {
        public string username { get; set; }
        public string password { get; set; }

        public Users(string username, string password)
        {
            this.username = username;
            this.password = UserLogin.Hasher.HashPassword(password);
        }
    }
}
