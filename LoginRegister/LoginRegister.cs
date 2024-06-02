using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoginRegister
{
    public enum LoginState { SUDAH_LOGIN, BELUM_LOGIN }
    public enum Trigger { LOGIN, LOGOUT }

    public class UserLogin
    {
        private LoginState _stateLogin;
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
            private const int SaltSize = 16;
            private const int KeySize = 32;
            private const int Iterations = 10000;
            private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;

            public static string HashPassword(string password)
            {
                byte[] salt = new byte[SaltSize];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }

                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithm);
                byte[] hash = pbkdf2.GetBytes(KeySize);

                byte[] hashBytes = new byte[SaltSize + KeySize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

                string base64Hash = Convert.ToBase64String(hashBytes);

                return base64Hash;
            }

            public static bool Verify(string password, string base64Hash)
            {
                byte[] hashBytes = Convert.FromBase64String(base64Hash);

                byte[] salt = new byte[SaltSize];
                Array.Copy(hashBytes, 0, salt, 0, SaltSize);

                byte[] storedHash = new byte[KeySize];
                Array.Copy(hashBytes, SaltSize, storedHash, 0, KeySize);

                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithm);
                byte[] hash = pbkdf2.GetBytes(KeySize);

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

            public static async Task<string> s_GetUsernameAsync(User user)
            {
                string[] usernames = Array.Empty<string>();

                using (HttpClient client = new HttpClient())
                {
                    // URL dasar API
                    client.BaseAddress = new Uri("https://localhost:7032/api/Users");

                    try
                    {
                        // Mengambil semua username
                        HttpResponseMessage response = await client.GetAsync("");
                        response.EnsureSuccessStatusCode(); // Melempar pengecualian jika status code tidak sukses

                        string jsonString = await response.Content.ReadAsStringAsync();
                        usernames = JsonSerializer.Deserialize<string[]>(jsonString);
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine($"Request error: {e.Message}");
                        return "Error fetching usernames";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Unexpected error: {e.Message}");
                        return "Unexpected error occurred";
                    }
                }

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

            public static async Task<List<UserLogin>> InitializeUserLoginsAsync()
            {
                List<UserLogin> users = new List<UserLogin>();

                users.Add(new UserLogin(await s_GetUsernameAsync(User.rakha), Hasher.HashPassword(s_GetPassword(User.rakha))));
                users.Add(new UserLogin(await s_GetUsernameAsync(User.joshua), Hasher.HashPassword(s_GetPassword(User.joshua))));
                users.Add(new UserLogin(await s_GetUsernameAsync(User.aufa), Hasher.HashPassword(s_GetPassword(User.aufa))));
                users.Add(new UserLogin(await s_GetUsernameAsync(User.dzawin), Hasher.HashPassword(s_GetPassword(User.dzawin))));
                users.Add(new UserLogin(await s_GetUsernameAsync(User.yousef), Hasher.HashPassword(s_GetPassword(User.yousef))));

                return users;
            }

            public static async Task<List<UserLogin>> InitializeDoctorLoginsAsync()
            {
                List<UserLogin> docs = new List<UserLogin>
                {
                    new UserLogin(s_GetDocUsername(Doctor.alan), s_GetDocPasswords(Doctor.alan)),
                    new UserLogin(s_GetDocUsername(Doctor.steve), s_GetDocPasswords(Doctor.steve)),
                    new UserLogin(s_GetDocUsername(Doctor.john), s_GetDocPasswords(Doctor.john)),
                };

                return docs;
            }
        }

        public List<UserLogin> users = new List<UserLogin>();
        public List<UserLogin> docs = new List<UserLogin>();

        public async Task InitializeAsync()
        {
            users = await UserList.InitializeUserLoginsAsync();
            docs = await UserList.InitializeDoctorLoginsAsync();
        }

        public List<UserLogin> GetUsers()
        {
            return users;
        }

        public List<UserLogin> GetDocs()
        {
            return docs;
        }

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

        public async void Login()
        {
            StateLogin loginState = new StateLogin();
            await InitializeAsync();

            Console.Write("Login:\nUsername: ");
            string nameinput = Console.ReadLine();
            Debug.Assert(!string.IsNullOrEmpty(nameinput), "Username tidak boleh null");

            Console.Write("Password: ");
            string passwdInput = Console.ReadLine();
            Debug.Assert(!string.IsNullOrEmpty(passwdInput), "Password tidak boleh null");

            for (int i = 0; i < users.Count; i++)
            {
                if ((nameinput == users[i]._userName) && (passwdInput == users[i]._password))
                {
                    loginState.Action(Trigger.LOGIN);
                }
            }
            this._stateLogin = loginState.current;
        }

        public async void LoginDoc()
        {
            StateLogin loginState = new StateLogin();
            UserList user = new UserList();
            await InitializeAsync();

            Console.Write("Login:\nUsername: ");
            string nameinput = Console.ReadLine();

            Console.Write("Password: ");
            string passwdInput = Console.ReadLine();

            for (int i = 0; i < docs.Count; i++)
            {
                if ((nameinput == docs[i]._userName) && (passwdInput == docs[i]._password))
                {
                    loginState.Action(Trigger.LOGIN);
                }
            }
            this._stateLogin = loginState.current;
        }

        // untuk GUI
        public async void Login(string username, string password)
        {
            await InitializeAsync();
            StateLogin state = new StateLogin();

            string hashed = Hasher.HashPassword(password);

            for (int on = 0; on < users.Count; on++)
            {
                if (username == users[on]._userName && Hasher.Verify(password, hashed))
                {
                    state.Action(Trigger.LOGIN);
                }
            }
            _stateLogin = state.current;
        }

        public async void DocLogin(string username, string password)
        {
            await InitializeAsync();
            StateLogin docState = new StateLogin();

            for (int at = 0; at < docs.Count; at++)
            {
                if (username == docs[at]._userName && password == docs[at]._password)
                {
                    docState.Action(Trigger.LOGIN);
                }
            }
            _stateLogin = docState.current;
        }

        public void Logout()
        {
            StateLogin loginState = new StateLogin();
            loginState.Action(Trigger.LOGOUT);
            this._stateLogin = loginState.current;
        }
    }
}
