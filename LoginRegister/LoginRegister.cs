using System.Diagnostics;

namespace LoginRegister
{

    public enum LoginState { SUDAH_LOGIN, BELUM_LOGIN }
    public enum Trigger { LOGIN, LOGOUT }

    public class UserLogin
    {
        private LoginState stateLogin;
        private string UserName { get; set; }
        private string Password { get; set; }

        public UserLogin(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        public UserLogin() { }


        public LoginState getLoginState()
        {
            return this.stateLogin;
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
                if ((nameinput == user.users[i].UserName) && (passwdInput == user.users[i].Password))
                {
                    loginState.Action(Trigger.LOGIN);
                }
            }

            this.stateLogin = loginState.Current;
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
                if ((nameinput == user.docs[i].UserName) && (passwdInput == user.docs[i].Password))
                {
                    loginState.Action(Trigger.LOGIN);
                }
            }

            this.stateLogin = loginState.Current;
        }

        // untuk GUI
        public LoginState Login(string username, string password)
        {
            StateLogin state = new StateLogin();
            UserList users = new UserList();

            for(int on = 0; on < users.users.Count; on++)
            {
                if (username == users.users[on].UserName && password == users.users[on].Password)
                {
                    state.Action(Trigger.LOGIN);
                }
            }
            stateLogin = state.Current;
            return stateLogin;
        }

        public LoginState DocLogin(string username, string password)
        {
            StateLogin docState = new StateLogin();
            UserList doctors = new UserList();

            for(int at = 0; at < doctors.docs.Count; at++)
            {
                if (username == doctors.docs[at].UserName && password == doctors.docs[at].Password)
                {
                    docState.Action(Trigger.LOGIN);
                }
            }

            stateLogin = docState.Current;

            return stateLogin;
        }

        public void Logout()
        {
            StateLogin loginState = new StateLogin();
            loginState.Action(Trigger.LOGOUT);
            this.stateLogin = loginState.Current;
        }
    }

    public class StateLogin
    {
        public LoginState Current;
        public StateLogin()
        {
            Current = LoginState.BELUM_LOGIN;
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

            Current = NextState(Current, trigger);

            if (Current == LoginState.BELUM_LOGIN && trigger == Trigger.LOGIN)
            {
                Console.WriteLine("Silahkan Login");
            }
            else if (Current == LoginState.SUDAH_LOGIN && trigger == Trigger.LOGIN)
            {
                Console.WriteLine("Sudah Masuk");
            }
            else if (Current == LoginState.SUDAH_LOGIN && trigger == Trigger.LOGOUT)
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

        public static string GetUsername(User user)
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

        public static string GetPassword(User user)
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

        public enum Doctors
        {
            john,
            steve,
            alan
        }

        public static string GetDocUsername(Doctors doctors)
        {
            string[] docUsernames =
            {
                "John",
                "Steve",
                "Alan"
            };
            int index = (int)doctors;
            if(index >= 0 && (index < docUsernames.Length))
            {
                return docUsernames[index];
            }
            return "Username dokter tidak ditemukan";
        }

        public static string GetDocPasswords(Doctors doctors)
        {
            string[] docPasswords =
            {
                "doe",
                "allen",
                "bob"
            };
            int index = (int)doctors;
            if(index >= 0 && (index < docPasswords.Length))
            {
                return docPasswords[index];
            }

            return "Password dokter tidak ditemukan";
        }

        public List<UserLogin> users = new List<UserLogin>
        {
            new UserLogin(GetUsername(User.rakha), GetPassword(User.rakha)),
            new UserLogin(GetUsername(User.joshua), GetPassword(User.joshua)),
            new UserLogin(GetUsername(User.aufa), GetPassword(User.aufa)),
            new UserLogin(GetUsername(User.dzawin), GetPassword(User.dzawin)),
            new UserLogin(GetUsername(User.yousef), GetPassword(User.yousef))
        };

        public List<UserLogin> docs = new List<UserLogin>
        {
            new UserLogin(GetDocUsername(Doctors.alan), GetDocPasswords(Doctors.alan)),
            new UserLogin(GetDocUsername(Doctors.steve), GetDocPasswords(Doctors.steve)),
            new UserLogin(GetDocUsername(Doctors.john), GetDocPasswords(Doctors.john)),
        };
    }

}
