/*
 Elegancia operador ternario 
 Números mágicos 
Complejidad condicional 
Polimorfismo vs Enum 
Ser declarativo
Método de tabla

 */



using Login_CleanCode;


/*
 ************************************************************************************************************************************************************************************************
 */








/*
 ************************************************************************************************************************************************************************************************
 */

// NO USING CLEAN CODE


class LogMng
{
    string[,] users = new string[,] { 
        { "user", "pass", "active", "admin" },
        { "user2", "pass2", "active", "normal"}
    };


    private void LoginUserNormal()
    {
        Console.WriteLine("Has iniciado como usuario normal");
        responsibilities.Showresponsibilities(1);
    }


    private void loginUserAdmin()
    {

        Console.WriteLine("Has iniciado como administrador");
        responsibilities.Showresponsibilities(0);


    }





    public void Log(string u , string p)
    {
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i,0] == u
                && users[i,1] == p
                && users[i,2] == "active")
            {

                if (users[i,3] == "admin")
                {
                    loginUserAdmin();

                }else if(users[i,3] == "normal")
                {
                    LoginUserNormal();
                }

            }
            else
            {
                Console.WriteLine(
                "Credenciales ingresadas invalidas , revisa si tu usuario ," +
                " contraseña o si este usuario esta [ activo ]");

            }    

        }

    }

    



}

class responsibilities
{

    public static void Showresponsibilities(int rol)
    {
        if(rol == 0)
        {
            Console.WriteLine("administrate the databases");
        }
        if(rol == 1)
        {
            Console.WriteLine("no responsibility");
        }


    }



}

/*
 ************************************************************************************************************************************************************************************************
 */






class MainClass
{

    

    public static void Main(string[] args)
    {
        LoginManager loginManager = new LoginManager();
        string user, pass;


        Console.WriteLine("___Login___");
        Console.Write("User: ");
        user = Console.ReadLine();
        Console.Write("Pass: ");
        pass = Console.ReadLine();

        //logMng.Log(user, pass);
       loginManager.login(user, pass);



    }




}