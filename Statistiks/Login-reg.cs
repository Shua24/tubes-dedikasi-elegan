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
        public List<UserLogin> users = new List<UserLogin>
        {
            new UserLogin("Rakha", "galih"),
            new UserLogin("Joshua", "daniel"),
            new UserLogin("Aufa", "taqiyya"),
            new UserLogin("Dzawin", "nuha"),
            new UserLogin("Yousef", "gumilar")
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