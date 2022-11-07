using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_CleanCode
{
    abstract class user
    {
        protected user()
        {

        }
        protected user(string _username, string _password, estado _status)
        {
            username = _username;
            password = _password;
            AcountStatus = _status;

        }


        public enum estado { active, inactive };
        public enum UserType { admin, normal };
        public string username;
        public string password;
        public estado AcountStatus;
        public abstract void Login();

    }

    class adminUser : user
    {
        public adminUser()
        { }
        public adminUser(string _username, string _password, estado _status) : base(_username, _password, _status)
        {
            username = _username;
            password = _password;
            AcountStatus = _status;

        }

        public override void Login()
        {
            Console.WriteLine("Has iniciado como administrador");
            Console.WriteLine("Tus responsabilidades son : ");
            Console.WriteLine(UserResponsibilities.Showresponsibilities("admin") + '\n');
        }
    }
    class normalUser : user
    {
        public normalUser(string _username, string _password, estado _status) : base(_username, _password, _status)
        {
            username = _username;
            password = _password;
            AcountStatus = _status;
        }

        override public void Login()
        {
            Console.WriteLine("Has iniciado como usuario normal");
            Console.WriteLine("Tus responsabilidades son : ");
            Console.WriteLine(UserResponsibilities.Showresponsibilities("normal") + '\n');
        }

    }


    static class UserResponsibilities
    {
        static Dictionary<string, string> responsibilities = new Dictionary<string, string>
        {
            ["normal"] = "no responsibility",
            ["admin"] = "administrate the databases"

        };
        


        public static string Showresponsibilities(string rol)
        {
                return responsibilities[rol];
        }



    }



    class LoginManager
    {
        List<user> users = new List<user>();

        public LoginManager()
        {
            users.Add(new adminUser("user", "pass", user.estado.active));
            users.Add(new normalUser("user2", "pass2", user.estado.active));


        }


        public void login(string username, string password)
        {
            bool IsLogged = false;
            String InvalidSessionMessage = "Invalid entered credentials, check if your username," +
                " password or if this user is [ active ]";
            String LoggedSucesffulMessage = "You have successfully logged in";

            foreach (user user in users)
            {
                bool IsUserValid = (
                        user.username == username
                        && user.password == password
                        && user.AcountStatus == user.estado.active
                     );

                if (IsUserValid)
                {
                    user.Login();
                    IsLogged = true;
                }
            }

            Console.WriteLine(IsLogged ? LoggedSucesffulMessage : InvalidSessionMessage);
        }


    }
}
