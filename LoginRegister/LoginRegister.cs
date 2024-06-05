using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace LoginRegister
{
    public enum LoginState { SUDAH_LOGIN, BELUM_LOGIN }
    public enum Trigger { LOGIN, LOGOUT }

    public class UserLogin
    {
        private LoginState _stateLogin = LoginState.BELUM_LOGIN;
        private string _userName { get; set; }
        private string _password { get; set; }

        public UserLogin(string username, string password)
        {
            this._userName = username;
            this._password = password;
        }

        public UserLogin() { }

        public class Hasher
        {
            private const int SaltSize = 32; // 256 bit
            private const int KeySize = 64; // 512 bit
            private const int Iterations = 10000; // Number of PBKDF2 iterations

            public static string HashPassword(string password)
            {
                // Generate a salt
                byte[] salt = new byte[SaltSize];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }

                // Generate the hash
                byte[] hash;
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
                {
                    hash = pbkdf2.GetBytes(KeySize);
                }

                // Combine salt and hash
                byte[] hashBytes = new byte[SaltSize + KeySize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

                // Convert to base64
                string base64Hash = Convert.ToBase64String(hashBytes);

                return base64Hash;
            }

            public static bool Verify(string password, string base64Hash)
            {
                // Get the bytes from the stored hash
                byte[] hashBytes = Convert.FromBase64String(base64Hash);

                // Extract the salt
                byte[] salt = new byte[SaltSize];
                Array.Copy(hashBytes, 0, salt, 0, SaltSize);

                // Extract the hash
                byte[] storedHash = new byte[KeySize];
                Array.Copy(hashBytes, SaltSize, storedHash, 0, KeySize);

                // Hash the input password with the stored salt
                byte[] hash;
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
                {
                    hash = pbkdf2.GetBytes(KeySize);
                }

                // Compare the hashes
                for (int i = 0; i < KeySize; i++)
                {
                    if (storedHash[i] != hash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public class UserList
        {
            public enum User
            {
                rakha,
                joshua,
                aufa,
                dzawin,
                yousef
            }

            public static string s_GetUsername(User user)
            {
                string[] usernames =
                {
                    "Rakha",
                    "Joshua",
                    "Aufa",
                    "Dzawin",
                    "Yousef",
                };

                int index = (int)user;

                if (index >= 0 && index < usernames.Length)
                {
                    return usernames[index];
                }
                return "Username Tidak Ditemukan";
            }

            public static string s_GetPassword(User user)
            {
                string[] passwords =
                {
                    "galih",
                    "daniel",
                    "taqiyya",
                    "nuha",
                    "gumilar",
                };

                int index = (int)user;

                if (index >= 0 && index < passwords.Length)
                {
                    return passwords[index];
                }
                return "Password Tidak Ditemukan";
            }

            public enum Doctor
            {
                john,
                steve,
                alan
            }

            public static string s_GetDocUsername(Doctor doctor)
            {
                string[] docUsernames =
                {
                    "John",
                    "Steve",
                    "Alan"
                };

                int index = (int)doctor;

                if (index >= 0 && index < docUsernames.Length)
                {
                    return docUsernames[index];
                }
                return "Username dokter tidak ditemukan";
            }

            public static string s_GetDocPasswords(Doctor doctor)
            {
                string[] docPasswords =
                {
                    "doe",
                    "allen",
                    "bob"
                };

                int index = (int)doctor;

                if (index >= 0 && index < docPasswords.Length)
                {
                    return docPasswords[index];
                }

                return "Password dokter tidak ditemukan";
            }

            public List<UserLogin> users = new List<UserLogin>
            {
                new UserLogin(s_GetUsername(User.rakha), s_GetPassword(User.rakha)),
                new UserLogin(s_GetUsername(User.joshua), s_GetPassword(User.joshua)),
                new UserLogin(s_GetUsername(User.aufa), s_GetPassword(User.aufa)),
                new UserLogin(s_GetUsername(User.dzawin), s_GetPassword(User.dzawin)),
                new UserLogin(s_GetUsername(User.yousef), s_GetPassword(User.yousef))
            };

            public List<UserLogin> GetUsers()
            {
                return users;
            }

            public List<UserLogin> docs = new List<UserLogin>
            {
                new UserLogin(s_GetDocUsername(Doctor.alan), s_GetDocPasswords(Doctor.alan)),
                new UserLogin(s_GetDocUsername(Doctor.steve), s_GetDocPasswords(Doctor.steve)),
                new UserLogin(s_GetDocUsername(Doctor.john), s_GetDocPasswords(Doctor.john)),
            };

            public List<UserLogin> GetDocs() { return docs; }
        };

        public class StateLogin
        {
            public LoginState current;
            public StateLogin()
            {
                current = LoginState.BELUM_LOGIN;
            }

            Transition[] transitions =
            {
                new Transition(LoginState.BELUM_LOGIN, Trigger.LOGIN, LoginState.SUDAH_LOGIN),
                new Transition(LoginState.SUDAH_LOGIN, Trigger.LOGOUT, LoginState.BELUM_LOGIN),
            };

            public LoginState NextState(LoginState initLoginState, Trigger trigger)
            {
                LoginState stateAkhir = initLoginState;

                for (int i = 0; i < transitions.Length; i++)
                {
                    Transition transition = transitions[i];

                    if (initLoginState == transition.stateAwal && trigger == transition.trigger)
                    {
                        stateAkhir = transitions[i].stateAkhir;
                    }
                }
                return stateAkhir;
            }

            public void Action(Trigger trigger)
            {
                current = NextState(current, trigger);

                if (current == LoginState.BELUM_LOGIN && trigger == Trigger.LOGIN)
                {
                    Console.WriteLine("Silahkan Login");
                }
                else if (current == LoginState.SUDAH_LOGIN && trigger == Trigger.LOGIN)
                {
                    Console.WriteLine("Sudah Masuk");
                }
                else if (current == LoginState.SUDAH_LOGIN && trigger == Trigger.LOGOUT)
                {
                    Console.WriteLine("User Logout");
                }
            }
        }

        public class Transition
        {
            public LoginState stateAwal;
            public Trigger trigger;
            public LoginState stateAkhir;

            public Transition(LoginState stateAwal, Trigger trigger, LoginState stateAkhir)
            {
                this.stateAwal = stateAwal;
                this.trigger = trigger;
                this.stateAkhir = stateAkhir;
            }
        }

        public LoginState getLoginState()
        {
            return this._stateLogin;
        }

        public void Login()
        {
            string nameinput = GetInput("Login:\nUsername: ");
            string passwdInput = GetInput("Password: ");

            LoginHelper(nameinput, passwdInput, false);
        }

        public void LoginDoc()
        {
            string nameinput = GetInput("Login:\nUsername: ");
            string passwdInput = GetInput("Password: ");

            LoginHelper(nameinput, passwdInput, true);
        }

        private void LoginHelper(string username, string password, bool isDoctor)
        {
            StateLogin loginState = new StateLogin();
            UserList user = new UserList();
            List<UserLogin> userList = isDoctor ? user.GetDocs() : user.GetUsers();

            string hashed = Hasher.HashPassword(password);

            for (int i = 0; i < userList.Count; i++)
            {
                if (username == userList[i]._userName && Hasher.Verify(password, hashed))
                {
                    loginState.Action(Trigger.LOGIN);
                }
            }
            this._stateLogin = loginState.current;
        }

        private string GetInput(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input tidak boleh kosong. Silakan coba lagi.");
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            return input;
        }

        // for GUI
        public LoginState Login(string username, string password)
        {
            LoginHelper(username, password, false);
            return _stateLogin;
        }

        public LoginState DocLogin(string username, string password)
        {
            LoginHelper(username, password, true);
            return _stateLogin;
        }

        public void Logout()
        {
            StateLogin loginState = new StateLogin { current = this._stateLogin };
            loginState.Action(Trigger.LOGOUT);
            this._stateLogin = loginState.current;
        }
    }
}
