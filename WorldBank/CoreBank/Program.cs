using CoreBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                var loginTrue = 1;
                Console.Clear();

                if (loginTrue == 1)
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
                        Console.WriteLine("Loading...");
                        Thread.Sleep(2000);
                        Console.Clear();
                        switch (respuesta)
                        {
                            case "1":
                                try
                                {
                                    if (loginTrue == 0 || loginTrue == 1)
                                    {
                                        string name, lastname, identification, adress, teleph;
                                        int genderid, identificationid;
                                        Console.WriteLine("Inserte su nombre");
                                        name = Console.ReadLine();
                                        Console.WriteLine("Inserte su apellido");
                                        lastname = Console.ReadLine();
                                        Console.WriteLine("Que tipo de identificacion? 0 para cedula, 1 para pasaporte");
                                        identificationid = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Inserte la identificacion");
                                        identification = Console.ReadLine();
                                        Console.WriteLine("Inserte su telefono");
                                        teleph = Console.ReadLine();
                                        Console.WriteLine("Inserte su dirección");
                                        adress = Console.ReadLine();
                                        Console.WriteLine("Inserte su genero: M para masculino, F para femenino");
                                        genderid = int.Parse(Console.ReadLine());
                                        var clienteTrue = true;
                                        // TODO metodo que traiga estos datos
                                        //var ClientPetition = new ClientPetitionHandler
                                        //{
                                        //    Origin = PetitionOrigin.CoreConsole,
                                        //    UserId = Consoleuser.Id,
                                        //    Client = new Client
                                        //    {
                                        //        Address = adress,
                                        //        Telephone = teleph,

                                        //        Identification = identification,
                                        //        IdentificationType = (IdentificationType)identificationid,
                                        //        Gender = (Gender)genderid,
                                        //        Name = name,
                                        //        LastName = lastname
                                        //    }
                                        //};
                                        if (clienteTrue == true)
                                        {
                                            Console.WriteLine("Cliente Insertado");
                                            log.Info($"Se guardo el cliente");//TODO agregar datos del cliente agregados
                                            Console.WriteLine("Presione Enter para continuar");
                                            Console.ReadLine();
                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine(clienteTrue);//TODO agregar datos del cliente 
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No puede realizar esta accion");

                                        Thread.Sleep(1200);
                                        Console.Clear();
                                        log.Info($"Usuario intento agregar una cuenta sin permiso");//TODO agregar datos de usuario
                                        break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Ocurrio un error");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    log.Error($"ERROR: {e.Message}");
                                    break;
                                }
                            case "2":
                                try
                                {
                                    if (loginTrue == 0 || loginTrue == 1)//if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                    {
                                        Cliente clientModel = new Cliente();//TODO metodo de webservice
                                        Console.WriteLine("Inserte la identificacion");
                                        var identification2 = Console.ReadLine();
                                        //var clientToModificatePetition = new ClientPetitionHandler
                                        //{
                                        //    Identification = identification2,
                                        //     Origin = PetitionOrigin.CoreConsole,
                                        //     UserId = Consoleuser.Id
                                        // };
                                        //var clientToModificateResponse = soapClient.GetClientByIdentification(clientToModificatePetition); TODO metodo de modificacion 
                                        var clienteMOD = true;
                                        if (clienteMOD == true) //if (clientToModificateResponse.Approved)
                                        {
                                            clientModel = clientToModificateResponse.Data.FirstOrDefault();
                                            Console.WriteLine($"ID: {clientModel.Id}, Nombre: {clientModel.Name} {clientModel.LastName}");
                                            Console.WriteLine("Desea modificarlo? {s/n}");
                                            var confirmacion = Console.ReadLine();
                                            if (confirmacion == "s")
                                            {
                                                Console.WriteLine("Inserte su nombre");
                                                clientModel.Nombre = Console.ReadLine();
                                                Console.WriteLine("Inserte su apellido");
                                                clientModel.Apellido = Console.ReadLine();
                                                Console.WriteLine("Inserte su telefono");
                                                clientModel.Telefono = Console.ReadLine();
                                                Console.WriteLine("Inserte su dirección");
                                                clientModel.Direccion = Console.ReadLine();
                                                //var ClientPetition2 = new ClientPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    Client = clientModel
                                                //};
                                                //var ClientResponse = soapClient.UpdateClient(ClientPetition2);

                                                if (clienteMOD == true)//if (ClientResponse.Approved)
                                                {

                                                    Console.WriteLine("Cliente modificado");
                                                    log.Info($"Modificacion del cliente {clientModel.Nombre}, apellido: {clientModel.Apellido} por el empleado{Consoleaccount}");
                                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                    Console.WriteLine("Press Enter...");
                                                    Console.ResetColor();
                                                    Console.ReadLine();
                                                    Thread.Sleep(2000);
                                                    Console.Clear();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine(ClientResponse.Message);
                                                    Console.Clear();
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                            Console.WriteLine("Cliente no encontrado");

                                    }
                                    else
                                    {
                                        Console.WriteLine("Usted no tiene permisos para esto!!");
                                        Console.ResetColor();

                                        Thread.Sleep(1200);
                                        Console.Clear();
                                        log.Info($"El usuario {Consoleuser.Email} intentó crear una cuenta sin permisos!");
                                        break;
                                    }
                                }
                                catch (Exception e)
                                {

                                    Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");
                                    Console.ResetColor();

                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    log.Error($"Error: {e.Message}");
                                    break;
                                }
                                break;

                            case "3":
                                try
                                {
                                    if (loginTrue == 0 || loginTrue == 1)//if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                    {
                                        string CLientID;
                                        string confirmacion;
                                        Console.WriteLine("Inserte la identificacion del cliente");
                                        CLientID = (Console.ReadLine());
                                        //var ClientSearchPetition3 = new ClientPetitionHandler
                                        //{
                                        //    Origin = PetitionOrigin.CoreConsole,
                                        //    UserId = Consoleuser.Id,
                                        //    Identification = CLientID
                                        //};
                                        //var clienteSearchedResponse3 = soapClient.GetClientByIdentification(ClientSearchPetition3);
                                        //var ClienteSearched3 = clienteSearchedResponse3.Data.FirstOrDefault();

                                        //var ClientToDeletePetition = new ClientPetitionHandler
                                        //{
                                        //    Origin = PetitionOrigin.CoreConsole,
                                        //    UserId = Consoleuser.Id,
                                        //    Id = ClienteSearched3.Id
                                        //};


                                        Console.WriteLine($"ID: {ClienteSearched3.Id}\nNombre: {ClienteSearched3.Name}\nApellido: {ClienteSearched3.LastName}");
                                        Console.WriteLine("Desea eliminarlo? {s/n}");
                                        confirmacion = Console.ReadLine();
                                        if (confirmacion == "s")
                                        {
                                            var clienterDelete = true;
                                            //var DeleteClientResponse = soapClient.DeleteClient(ClientToDeletePetition);
                                            if (clienterDelete == true)
                                            {

                                                //log.Info($"Elminacion del cliente {DeleteClientResponse.Data.FirstOrDefault().Name} {DeleteClientResponse.Data.FirstOrDefault().LastName}, por el empleado{Consoleaccount}");
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine("Cliente ha sido eliminado");
                                                Console.WriteLine("Press Enter...");
                                                Console.ResetColor();
                                                Console.ReadLine();
                                                Thread.Sleep(2000);
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                //Console.WriteLine(DeleteClientResponse.Message);
                                                Console.Clear();
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Usted no tiene permisos para esto!!");
                                        Console.ResetColor();

                                        Thread.Sleep(1200);
                                        Console.Clear();
                                        log.Error($"El usuario {Consoleuser.Email} intentó eliminar una cuenta sin permisos!");
                                        break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");
                                    Console.ResetColor();

                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    log.Info($"Error: {e.Message}");
                                    break;
                                }
                            case "4":
                                try
                                {
                                    var FullListPetition = new ClientPetitionHandler
                                    {
                                        Origin = PetitionOrigin.CoreConsole,
                                        UserId = Consoleuser.Id

                                    };
                                    var listadoClientes = soapClient.GetAllClients(FullListPetition);
                                    if (listadoClientes.Approved)
                                    {
                                        foreach (var client in listadoClientes.Data)
                                        {
                                            Console.WriteLine($"Nombre: {client.Name}, Apellido: {client.LastName}, telefono: {client.Telephone}, direccion: {client.Address}, identificacion: {client.Identification}");

                                        };
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine("Press Enter...");
                                        Console.ResetColor();
                                        Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine(listadoClientes.Message);
                                        Console.Clear();
                                        break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");
                                    Console.ResetColor();

                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    log.Error($"Error: {e.Message}");
                                    break;
                                }
                            case "5":
                                try
                                {
                                    string id3;
                                    Console.WriteLine("Inserte su identificacion");
                                    id3 = (Console.ReadLine());
                                    //var SearchClientPetition = new ClientPetitionHandler
                                    //{
                                    //    Origin = PetitionOrigin.CoreConsole,
                                    //    UserId = Consoleuser.Id,
                                    //    Identification = id3
                                    //};
                                    //var SearchClientResponse = soapClient.GetClientByIdentification(SearchClientPetition);
                                    // var SearchedClient = SearchClientResponse.Data.FirstOrDefault();
                                    if (SearchClientResponse.Approved)
                                    {
                                        Console.WriteLine($"Nombre: {SearchedClient.Name}, Apellido: {SearchedClient.LastName}, identificacion: {SearchedClient.Identification}, direccion: {SearchedClient.Address}");

                                        log.Info($"Se buscó el cliente {SearchedClient.Name}, apellido: {SearchedClient.LastName} por el empleado{Consoleaccount}");
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine("Press Enter...");
                                        Console.ResetColor();
                                        Console.ReadLine();
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine(SearchClientResponse.Message);
                                        Console.Clear();
                                        break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");
                                    Console.ResetColor();

                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    log.Error($"Error: {e.Message}");
                                    break;
                                }
                            //Opcion invalida o Salir de menu
                            default:
                                Console.WriteLine("Saliendo de menú...");
                                Console.ResetColor();
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;
                        }
                        break;
                         #endregion
                            #region MENU CUENTAS
                            case "3":
                                //Menu principal
                                string resp;
                        Console.WriteLine("Bienvneido al Menú de cuentas");
                        Console.WriteLine("Opciones:");
                        Console.WriteLine("1. crear una cuenta");
                        Console.WriteLine("2. editar una cuenta");
                        Console.WriteLine("3. borrar una cuenta");
                        Console.WriteLine("4. buscar cuenta por el numero");
                        Console.WriteLine("5. buscar listado de cuentas");
                        Console.WriteLine("6. salir de este menú");
                        Console.WriteLine("");
                        Console.Write("Inserte la opción que desea: ");

                        resp = Console.ReadLine();
                        Console.WriteLine("Loading...");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();

                        switch (resp)
                        {
                            //Insertar cuenta
                            case "1":
                                try
                                {
                                    if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                    {
                                        string alias, identifi;
                                        int accountType, CurrencyType;
                                        Console.WriteLine("Inserte su alias");
                                        alias = Console.ReadLine();
                                        Console.WriteLine("Inserte el tipo de cuenta {0 para ahorro, 1 para corriente, 2 para otro}");
                                        accountType = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Inserte el tipo de dinero {0 para peso dominicano, 1 para dolar, 2 para euro");
                                        CurrencyType = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Inserte su identificacion");
                                        identifi = Console.ReadLine();
                                        var GetClientPetition = new ClientPetitionHandler
                                        {
                                            Origin = PetitionOrigin.CoreConsole,
                                            UserId = Consoleuser.Id,
                                            Identification = identifi
                                        };
                                        var GetClientResponse = soapClient.GetClientByIdentification(GetClientPetition);
                                        if (GetClientResponse.Approved)
                                        {
                                            var Client = GetClientResponse.Data.FirstOrDefault();
                                            var InsertAccountPetition = new AccountPetitionHandler
                                            {
                                                Origin = PetitionOrigin.CoreConsole,
                                                UserId = Consoleuser.Id,
                                                Account = new Account
                                                {
                                                    Alias = alias,
                                                    AccountType = (AccountType)accountType,
                                                    CurrencyType = (WS.CurrencyType)CurrencyType,
                                                    AccountManagerId = 1,
                                                    OwnerId = Client.Id
                                                }
                                            };
                                            var InsertAccountResponse = soapClient.InsertAccount(InsertAccountPetition);
                                            if (InsertAccountResponse.Approved)
                                            {
                                                Console.WriteLine("Se ha creado la cuenta del clinete: {0} {1}", Client.Name, Client.LastName);
                                                log.Info($"Inserción de una nueva cuenta para el clinete {Client.Name} {Client.LastName}, por el empleado{Consoleaccount}");
                                                Console.WriteLine("Press Enter...");
                                                Console.ReadLine();
                                                Thread.Sleep(2000);
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(InsertAccountResponse.Message);
                                                Console.Clear();
                                                break;
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Cliente no encontrado");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Usted no tiene permisos para esto!!");

                                        Thread.Sleep(1200);
                                        Console.Clear();
                                        log.Info($"El usuario {Consoleuser.Email} intentó agregarar una cuenta sin permisos!");
                                        break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");

                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    log.Error($"Error: {e.Message}");
                                    break;
                                }
                                break;
                            case "2":
                                try
                                {
                                    if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                    {
                                        Cuenta accountModel = new Cuenta();
                                        Console.WriteLine("Inserte el no. cuenta");
                                        var accNumber = Console.ReadLine();
                                        var cuentaToModificatePetition = new AccountPetitionHandler
                                        {
                                            UserId = Consoleuser.Id,
                                            Origin = PetitionOrigin.CoreConsole,
                                            Number = accNumber
                                        };
                                        var cuentaToModificateResponse = soapClient.GetAccountByNumber(cuentaToModificatePetition);
                                        if (cuentaToModificateResponse.Approved)
                                        {
                                            accountModel = cuentaToModificateResponse.Data.FirstOrDefault();
                                            var clienteResp = soapClient.GetClientByIdentification(new ClientPetitionHandler { Id = accountModel.OwnerId, Origin = PetitionOrigin.CoreConsole, UserId = Consoleuser.Id });
                                            var cliente = clienteResp.Data.FirstOrDefault();
                                            Console.WriteLine($"Numero: {accountModel.Number}, Propietario: {cliente.Name} {cliente.LastName}, Balance: {accountModel.Balance}, Tipo Moneda: {accountModel.CurrencyType}, Tipo Cuenta: {accountModel.AccountType}");
                                            Console.WriteLine("Desea modificarlo? {s/n}");
                                            var confirmacion = Console.ReadLine();
                                            if (confirmacion == "s")
                                            {
                                                Console.WriteLine("Inserte el tipo de cuenta {0 para ahorro, 1 para corriente, 2 para otro}");
                                                accountModel.AccountType = (AccountType)int.Parse(Console.ReadLine());
                                                Console.WriteLine("Inserte el tipo de dinero {0 para peso dominicano, 1 para dolar, 2 para euro");
                                                accountModel.CurrencyType = (CurrencyType)int.Parse(Console.ReadLine());
                                                var InsertAccountPetition2 = new AccountPetitionHandler
                                                {
                                                    Origin = PetitionOrigin.CoreConsole,
                                                    UserId = Consoleuser.Id,
                                                    Account = accountModel
                                                };
                                                var InsertAccountResponse2 = soapClient.UpdateAccount(InsertAccountPetition2);
                                                if (InsertAccountResponse2.Approved)
                                                {
                                                    Console.WriteLine("Numero de cuenta: {0}", accountModel.Number);
                                                    log.Info($"Actualizacion de la cuenta { accountModel.Number}, por el empleado{Consoleaccount}");
                                                    Console.WriteLine("Press Enter...");
                                                    Console.ReadLine();
                                                    Thread.Sleep(2000);
                                                    Console.Clear();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine(InsertAccountResponse2.Message);
                                                    Console.Clear();
                                                    break;
                                                }

                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Usted no tiene permisos para esto!!");

                                            Thread.Sleep(1200);
                                            Console.Clear();
                                            log.Info($"El usuario {Consoleuser.Email} intentó agregar una cuenta sin permisos!");
                                            break;
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");

                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    log.Error($"Error: {e.Message}");
                                    break;
                                }
                                break;
                            case "3":
                                try
                                {
                                    if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                    {
                                        string number;
                                        Console.WriteLine("Inserte el número de su cuenta");
                                        number = Console.ReadLine();
                                        var AccountSearched3 = new AccountPetitionHandler
                                        {
                                            Origin = PetitionOrigin.CoreConsole,
                                            UserId = Consoleuser.Id,
                                            Identification = number
                                        };
                                        var AccountSearched3Response = soapClient.GetAccountByNumber(AccountSearched3);
                                        var AccountSearched = AccountSearched3Response.Data.FirstOrDefault();

                                        var AccountToEliminatePetition = new AccountPetitionHandler
                                        {
                                            Origin = PetitionOrigin.CoreConsole,
                                            UserId = Consoleuser.Id,
                                            Id = AccountSearched.Id
                                        };
                                        string confir;
                                        Console.WriteLine("Desea eliminar la cuenta?{s/n}");
                                        Console.WriteLine($"Numero: {AccountSearched.Number}, Alias: {AccountSearched.Alias}");
                                        confir = Console.ReadLine();
                                        if (confir == "s")
                                        {
                                            var AccountToEliminteResponse = soapClient.DeleteAccount(AccountToEliminatePetition);
                                            if (AccountToEliminteResponse.Approved)
                                            {
                                                Console.WriteLine("Cuenta eliminada!");
                                                log.Info($"Se eliminó la cuenta {AccountToEliminteResponse.Data.FirstOrDefault().Alias}, por el empleado{Consoleaccount}");
                                                Console.WriteLine("Press Enter...");
                                                Console.ReadLine();
                                                Thread.Sleep(2000);
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(AccountToEliminteResponse.Message);
                                                Console.Clear();
                                                break;
                                            }
                                        }

                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Usted no tiene permisos para esto!!");

                                        Thread.Sleep(1200);
                                        Console.Clear();
                                        log.Info($"El usuario {Consoleuser.Email} intentó eliminar una cuenta sin permisos!");
                                        break;

                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");

                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    log.Error($"Error: {e.Message}");
                                    break;
                                }
                        }
                    }
                }
            }

        }
        #endregion
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