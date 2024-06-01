using System.Diagnostics;

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
                String[] usernames =
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
                String[] passwords =
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

                if (index >= 0 && (index < docUsernames.Length))
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

                if (index >= 0 && (index < docPasswords.Length))
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

            public List<UserLogin> docs = new List<UserLogin>
            {
                new UserLogin(s_GetDocUsername(Doctor.alan), s_GetDocPasswords(Doctor.alan)),
                new UserLogin(s_GetDocUsername(Doctor.steve), s_GetDocPasswords(Doctor.steve)),
                new UserLogin(s_GetDocUsername(Doctor.john), s_GetDocPasswords(Doctor.john)),
            };
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
            StateLogin loginState = new StateLogin();
            UserList user = new UserList();

            Console.Write("Login:\nUsername: ");
            string nameinput = Console.ReadLine();
            Debug.Assert(!string.IsNullOrEmpty(nameinput), "Username tidak boleh null");

            Console.Write("Password: ");
            string passwdInput = Console.ReadLine();
            Debug.Assert(!string.IsNullOrEmpty(passwdInput), "Password tidak boleh null");

            for (int i = 0; i < user.users.Count; i++)
            {
                if ((nameinput == user.users[i]._userName) && (passwdInput == user.users[i]._password))
                {
                    loginState.Action(Trigger.LOGIN);
                }
            }
            this._stateLogin = loginState.current;
        }

        public void LoginDoc()
        {
            StateLogin loginState = new StateLogin();
            UserList user = new UserList();

            Console.Write("Login:\nUsername: ");
            string nameinput = Console.ReadLine();

            Console.Write("Password: ");
            string passwdInput = Console.ReadLine();

            for (int i = 0; i < user.docs.Count; i++)
            {
                if ((nameinput == user.docs[i]._userName) && (passwdInput == user.docs[i]._password))
                {
                    loginState.Action(Trigger.LOGIN);
                }
            }
            this._stateLogin = loginState.current;
        }

        // untuk GUI
        public LoginState Login(string username, string password)
        {
            StateLogin state = new StateLogin();
            UserList users = new UserList();

            for(int on = 0; on < users.users.Count; on++)
            {
                if (username == users.users[on]._userName && password == users.users[on]._password)
                {
                    state.Action(Trigger.LOGIN);
                }
            }
            _stateLogin = state.current;
            return _stateLogin;
        }

        public LoginState DocLogin(string username, string password)
        {
            StateLogin docState = new StateLogin();
            UserList doctors = new UserList();

            for(int at = 0; at < doctors.docs.Count; at++)
            {
                if (username == doctors.docs[at]._userName && password == doctors.docs[at]._password)
                {
                    docState.Action(Trigger.LOGIN);
                }
            }
            _stateLogin = docState.current;
            return _stateLogin;
        }

        public void Logout()
        {
            StateLogin loginState = new StateLogin();
            loginState.Action(Trigger.LOGOUT);
            this._stateLogin = loginState.current;
        }
    }
}
