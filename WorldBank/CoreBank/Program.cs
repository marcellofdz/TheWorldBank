using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBank
{
    class Program
    {
        public static string EnteredVal = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            string nombreBanco = "WorldBank";
            string user;
            string password;
            string salir = "no";
            string respuesta;


            int intento = 1;
            //int intentorestante = 2;

            Console.Title = nombreBanco;

            Console.WriteLine(nombreBanco);

            while (intento < 4)
            {
                Console.WriteLine("Inicio de sesion");

                Console.WriteLine("Inserte su usuario:");
                user = Console.ReadLine();
                password = "Inserte su contraseña: ";
                PasswordVerify(password);
                //TODO metodo validacion de login
                var loginTrue = true;
                Console.Clear();

                if (loginTrue == true)
                {
                    //TODO validacion con el servicio

                    log.Info($"El usuario {user} se logeo");
                    Console.Clear();

                    Console.WriteLine("Bienvenido al menu del sistema principal");

                    Console.WriteLine("Opciones:");

                    while (salir == "no")
                    {
                        #region MenuPrincipal
                        Console.WriteLine("1. Usuario");
                        Console.WriteLine("2. Cliente");
                        Console.WriteLine("3. Cuentas");
                        Console.WriteLine("4. Empleado");
                        Console.WriteLine("5. Buscar cliente por su id");
                        Console.WriteLine("6. Salir");
                        Console.WriteLine("");
                        Console.Write("Inserte la opcion que desea: ");

                        respuesta = Console.ReadLine();
                         
                        
                        #endregion
                    }
                }

            }
        }

        #region Private Methods
        private static void PasswordVerify(string password)
        {
            try
            {
                Console.Write(password);
                EnteredVal = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        EnteredVal += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && EnteredVal.Length > 0)
                        {
                            EnteredVal = EnteredVal.Substring(0, (EnteredVal.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            if (string.IsNullOrWhiteSpace(EnteredVal))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("No se permiten valores vacios");
                                PasswordVerify(password);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                break;
                            }
                        }
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
