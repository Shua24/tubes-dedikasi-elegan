﻿namespace UserData
{
    public enum LoginState{ SUDAH_LOGIN, BELUM_LOGIN }
    public enum Trigger { LOGIN }

    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserLogin(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
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

        public string GetUsername(User user)
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

        public string GetPassword(User user)
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

        public List<UserLogin> users = new List<UserLogin>
        {
            new UserLogin(GetUsername(User.rakha), GetPassword(User.rakha)),
            new UserLogin(GetUsername(User.joshua), GetPassword(User.joshua)),
            new UserLogin(GetUsername(User.aufa), GetPassword(User.aufa)),
            new UserLogin(GetUsername(User.dzawin), GetPassword(User.dzawin)),
            new UserLogin(GetUsername(User.yousef), GetPassword(User.yousef))
        };
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

    public static class LogInAction
    {
        public static LoginState login()
        {
            StateLogin loginState = new StateLogin();
            UserList user = new UserList();

            Console.Write("Login:\n Username: ");
            string nameinput = Console.ReadLine();
            Console.Write("Password: ");
            string passwdInput = Console.ReadLine();

            for (int i = 0; i < user.users.Count; i++)
            {
                if ((nameinput == user.users[i].UserName) && (passwdInput == user.users[i].Password))
                {
                    loginState.Action(Trigger.LOGIN);
                }
            }

            return loginState.Current;
        }
    }
}