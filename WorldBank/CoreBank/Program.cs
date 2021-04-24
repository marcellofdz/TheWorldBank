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
        #region log y contraseña
        public static string EnteredVal = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        static void Main(string[] args)
        {
            #region variables y soapClient
            string answer, Consoleaccount, salir = "No";
            int intento = 1, intentorestante = 2;

            Console.Title = "CoreServer";

            //conexion con el cliente de webService
            CoreWSSoapClient soapClient = new CoreWSSoapClient();
            #endregion

            while (intento < 4)
            {
                #region log in
                //Log in 
                Console.WriteLine("THE WORLD BANK");
                Console.WriteLine("Inicie sesión");
                Console.WriteLine("");
                Console.WriteLine("Inserte su usuario:");
                Consoleaccount = Console.ReadLine();
                string enterText = "Inserte su contraseña: ";
                CheckPassword(enterText);
                var response_login = soapClient.ValidateEmployeeUserCredentials(Consoleaccount, EnteredVal);
                Console.Clear();
                #endregion

                if (response_login.Approved)
                {
                    var Consoleuser = response_login.Data.FirstOrDefault();

                    #region premenu
                    log.Info($"El usuario {Consoleaccount} se logeó");
                    Console.Clear();

                    //MENU
                    Console.WriteLine("Bienvenido al menú del sistema principal!");

                    Console.WriteLine("Opciones:");
                    Console.ResetColor();
                    #endregion
                    while (salir == "No")
                    {
                        #region MENU PRINCIPAL
                        Console.WriteLine("1. usuario");
                        Console.WriteLine("2. cliente");
                        Console.WriteLine("3. cuentas");
                        Console.WriteLine("4. empleado");
                        Console.WriteLine("5. transaccion");
                        Console.WriteLine("6. tarjeta");
                        Console.WriteLine("7.  sistema");
                        Console.WriteLine("");
                        Console.Write("Inserte la opción que desea: ");
                        answer = Console.ReadLine();
                        Console.WriteLine("Loading...");
                        Thread.Sleep(2000);
                        Console.Clear();
                        #endregion
                        switch (answer)
                        {
                            #region MENU USUARIO
                            //MENU USUARIO
                            case "1":
                                string respu;
                                Console.WriteLine("Bienvenido al menú de usuarios!");
                                Console.WriteLine("Opciones:");
                                Console.WriteLine("1 para crear usuario");
                                Console.WriteLine("2 para actualizar usuario");
                                Console.WriteLine("3 para eliminar un usuario");
                                Console.WriteLine("4 para buscar un usuario por nombre de usuario");
                                Console.WriteLine("5 para buscar el listado de usuarios");
                                Console.WriteLine("6 para salir de este menú");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("-------------------------------------------------");
                                Console.ResetColor();
                                Console.Write("Inserte la opción que desea: ");
                                respu = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Loading...");
                                Console.ResetColor();
                                Thread.Sleep(2000);
                                Console.Clear();


                                switch (respu)
                                {
                                    //Insertar usuario
                                    case "1":
                                        try
                                        {
                                            if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                            {
                                                string user1, password1, email1;
                                                string id1;
                                                Console.WriteLine("Inserte su usuario");
                                                user1 = Console.ReadLine();
                                                Console.WriteLine("Inserte su correo");
                                                email1 = Console.ReadLine();
                                                Console.WriteLine("Inserte su contraseña");
                                                password1 = Console.ReadLine();
                                                Console.WriteLine("Inserte su identificacion");
                                                id1 = (Console.ReadLine());
                                                //TODO Insertar usuario
                                                //var ClientSearchPetition = new ClientPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    Identification = id1
                                                //};
                                                //TODO conexion con busqueda de cliente
                                                //var clienteSearchedResponse = soapClient.GetClientByIdentification(ClientSearchPetition);
                                                //var ClienteSearched = clienteSearchedResponse.Data.FirstOrDefault();
                                                //Si es lista solo data
                                                //var UserToCreatPetition = new UserPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    User = new User
                                                //    {
                                                //        UserName = user1,
                                                //        Email = email1,
                                                //        Password = password1,
                                                //        ClientId = ClienteSearched.Id
                                                //    }
                                                //};
                                                //TODO metodo de insertar cliente
                                                //var ResponeUserToCreate = soapClient.InsertUser(UserToCreatPetition);
                                                if (ResponeUserToCreate.Approved)
                                                {

                                                    log.Info($"Inserción del usuario {UserToCreatPetition.User.UserName}, por el empleado{Consoleaccount}");
                                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                    Console.WriteLine("Ha sido insertado exitosamente!");
                                                    Console.WriteLine("Press Enter...");
                                                    Console.ResetColor();
                                                    Console.ReadLine();
                                                    Thread.Sleep(2000);
                                                    Console.Clear();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine(ResponeUserToCreate.Message);
                                                    Console.Clear();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Usted no tiene permisos para esto!!");

                                                Thread.Sleep(1200);
                                                Console.Clear();
                                                log.Info($"El usuario {Consoleuser.Email} intentó crear un usuario sin permisos!");
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
                                    //Actualizar usuario
                                    case "2":
                                        try
                                        {
                                            if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                            {

                                                string user2, password2, email2;
                                                string id2;
                                                User userModel = new User();
                                                Console.WriteLine("Inserte su usuario");
                                                user2 = Console.ReadLine();
                                                //TODO modificacion del usuario
                                                //var userToModificatePetition = new UserPetitionHandler
                                                //{
                                                //    Identification = user2,
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id
                                                //};
                                                //var usertToModificateResp = soapClient.GetUserByUserName(userToModificatePetition);
                                                if (usertToModificateResp.Approved)
                                                {
                                                    userModel = usertToModificateResp.Data.FirstOrDefault();
                                                    Console.WriteLine($"ID: {userModel.Id}\nEmail: {userModel.Email}\nUsername: {userModel.UserName}");
                                                    Console.WriteLine("Este es el registro que desea actualizar? s/n");
                                                    var updateResp = Console.ReadLine();
                                                    if (updateResp == "s")
                                                    {

                                                        Console.WriteLine("Inserte su correo");
                                                        userModel.Email = Console.ReadLine();
                                                        Console.WriteLine("Inserte su contraseña");
                                                        userModel.Password = Console.ReadLine();
                                                        //Si es lista solo data
                                                        var UserToCreatPetition2 = new UserPetitionHandler
                                                        {
                                                            Origin = PetitionOrigin.CoreConsole,
                                                            UserId = Consoleuser.Id,
                                                            User = userModel
                                                        };

                                                        var ResponseUpdateUser2 = soapClient.UpdateUser(UserToCreatPetition2);
                                                        if (ResponseUpdateUser2.Approved)
                                                        {
                                                            Console.WriteLine();
                                                            log.Info($"Actualizacion del usuario {UserToCreatPetition2.User.UserName}, por el empleado{Consoleaccount}");
                                                            Console.WriteLine("Press Enter...");
                                                            Console.ReadLine();
                                                            Thread.Sleep(2000);
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine(ResponseUpdateUser2.Message);
                                                            Console.Clear();
                                                            break;
                                                        }

                                                    }
                                                    else

                                                        break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Usuario no encontrado");
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Usted no tiene permisos para esto!!");

                                                Thread.Sleep(1200);
                                                Console.Clear();
                                                log.Info($"El usuario {Consoleuser.Email} intentó crear un usuario sin permisos!");
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
                                    //ELIMINAR USUARIO
                                    case "3":
                                        try
                                        {
                                            if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                            {
                                                string Usuario;
                                                string confirmacion;
                                                Console.WriteLine("Inserte el usuario");
                                                Usuario = (Console.ReadLine());
                                                //TODO buscador y eliminar usuario
                                                //var ClientSearchPetition3 = new UserPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    Identification = Usuario
                                                //};
                                                //var clienteSearchedResponse3 = soapClient.GetUserByUserName(ClientSearchPetition3);
                                                //var ClienteSearched3 = clienteSearchedResponse3.Data.FirstOrDefault();
                                                //var UserToDeletePetition = new UserPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    Id = ClienteSearched3.Id
                                                //};

                                                //Client client2 = soapClient.GetClientByIdentification(CLientID);
                                                //User UserToEliminate = soapClient.GetUserByClientId(client2.Id);

                                                Console.WriteLine($"ID: {ClienteSearched3.Id}\nEmail: {ClienteSearched3.Email}\nUsername: {ClienteSearched3.UserName}");
                                                Console.WriteLine("Desea eliminarlo? {s/n}");
                                                confirmacion = Console.ReadLine();
                                                if (confirmacion == "s")
                                                {
                                                    //var DeleteUserResponse = soapClient.DeleteUser(UserToDeletePetition);
                                                    if (DeleteUserResponse.Approved)
                                                    {

                                                        log.Info($"Elminacion del usuario {DeleteUserResponse.Data.FirstOrDefault().UserName}, por el empleado{Consoleaccount}");
                                                        Console.WriteLine("Usuario ha sido eliminado");
                                                        Console.WriteLine("Press Enter...");
                                                        Console.ReadLine();
                                                        Thread.Sleep(2000);
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine(DeleteUserResponse.Message);
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
                                                log.Info($"El usuario {Consoleuser.Email} intentó eliminar un usuario sin permisos!");
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

                                    //Buscar un usuario por su nombre de usuario
                                    case "4":
                                        try
                                        {
                                            string userName;
                                            Console.WriteLine("Inserte su usuario");
                                            userName = (Console.ReadLine());
                                            //TODO busqueda de usuario
                                            //var ClientSearchPetition4 = new UserPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id,
                                            //    Identification = userName
                                            //};
                                            //var clienteSearchedResponse4 = soapClient.GetUserByUserName(ClientSearchPetition4);
                                            if (clienteSearchedResponse4.Approved)
                                            {
                                                var ClienteSearched4 = clienteSearchedResponse4.Data.FirstOrDefault();
                                                Console.WriteLine($"Id Usuario:{ClienteSearched4.Id}, Usuario : {ClienteSearched4.UserName}, Correo : {ClienteSearched4.Email}, ClientID: {ClienteSearched4.ClientId}");
                                                log.Info($"Se buscó el usuario {ClienteSearched4.UserName}, por el empleado{Consoleaccount}");
                                                Console.WriteLine("Press Enter...");
                                                Console.ReadLine();
                                                Thread.Sleep(2000);
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Usuario no encontrado,favor intente de nuevo");
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
                                    //Buscar lista de usuarios
                                    case "5":
                                        try
                                        {
                                            //TODO buscar todos los registros de usuarios
                                            //var GetAllpetition = new UserPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id,

                                            //};

                                            //var GetAllResponse = soapClient.GetAllUsers(GetAllpetition);
                                            if (GetAllResponse.Approved)
                                            {
                                                foreach (var user in GetAllResponse.Data)
                                                {


                                                    Console.WriteLine($"Id Usuario: {user.Id},Usuario: {user.UserName}, Correo: {user.Email}");

                                                }
                                                log.Info($"El usuario {Consoleuser} ha buscado la lista de usuarios");
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine("Press Enter...");
                                                Console.ResetColor();
                                                Console.ReadLine();
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(GetAllResponse.Message);
                                                Console.WriteLine("Press Enter...");
                                                Console.ReadLine();
                                                Console.Clear();
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

                                    //Opción incorrecta o salir
                                    default:
                                        try
                                        {
                                            Console.WriteLine("Saliendo de menú...");
                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            break;
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");

                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            log.Info($"Error: {e.Message}");
                                            break;
                                        }
                                }
                                break;
                            #endregion
                            #region MENU CLIENTE
                            //Menu Clientes
                            case "2":

                                string respuesta;
                                Console.WriteLine("Bienvenido al menú de cliente");
                                Console.WriteLine("Opciones:");
                                Console.WriteLine("1. Insertar un cliente");
                                Console.WriteLine("2. Actualizar un cliente");
                                Console.WriteLine("3. Eliminar un cliente");
                                Console.WriteLine("4. Buscar todos los clientes");
                                Console.WriteLine("5. Buscar cliente por su id");
                                Console.WriteLine("6. Salir de este menú");
                                Console.WriteLine("");
                                Console.Write("Inserte la opción que desea: ");
                                respuesta = Console.ReadLine();
                                Console.WriteLine("Loading...");
                                Thread.Sleep(2000);
                                Console.Clear();
                                switch (respuesta)
                                {
                                    //Insertar cliente
                                    case "1":
                                        try
                                        {
                                            if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
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
                                                Console.WriteLine("Inserte su genero: 0 para masculino, 1 para femenino");
                                                genderid = int.Parse(Console.ReadLine());
                                                //TODO Buscar cliente en el menu de clientes.
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
                                                //var ClientResponse = soapClient.InsertClient(ClientPetition);

                                                if (ClientResponse.Approved)
                                                {

                                                    Console.WriteLine("Cliente insertado");
                                                    log.Info($"Insercion del cliente {ClientPetition.Client.Name}, apellido: {ClientPetition.Client.LastName} por el empleado{Consoleaccount}");
                                                    Console.WriteLine("Press Enter...");
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
                                            else
                                            {
                                                Console.WriteLine("Usted no tiene permisos para esto!!");

                                                Thread.Sleep(1200);
                                                Console.Clear();
                                                log.Info($"El usuario {Consoleuser.Email} intentó crear una cuenta sin permisos!");
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
                                    //Actualizar cliente
                                    case "2":
                                        try
                                        {
                                            if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                            {
                                                Cliente clientModel = new Cliente();
                                                Console.WriteLine("Inserte la identificacion");
                                                var identification2 = Console.ReadLine();

                                                if (clientToModificateResponse.Approved)
                                                {
                                                    clientModel = clientToModificateResponse.Data.FirstOrDefault();
                                                    Console.WriteLine($"ID: {clientModel.Cedula}, Nombre: {clientModel.Nombre} {clientModel.Apellido}");
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
                                                        //TODO modificacion de usuario
                                                        //var ClientPetition2 = new ClientPetitionHandler
                                                        //{
                                                        //    Origin = PetitionOrigin.CoreConsole,
                                                        //    UserId = Consoleuser.Id,
                                                        //    Client = clientModel
                                                        //};
                                                        //var ClientResponse = soapClient.UpdateClient(ClientPetition2);

                                                        if (ClientResponse.Approved)
                                                        {
                                                            Console.WriteLine("Cliente modificado");
                                                            log.Info($"Modificacion del cliente {clientModel.Nombre}, apellido: {clientModel.Apellido} por el empleado{Consoleaccount}");
                                                            Console.WriteLine("Press Enter...");
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

                                                Thread.Sleep(1200);
                                                Console.Clear();
                                                log.Info($"El usuario {Consoleuser.Email} intentó crear una cuenta sin permisos!");
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
                                    //Eliminar Cliente
                                    case "3":
                                        try
                                        {
                                            if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                            {
                                                string CLientID;
                                                string confirmacion;
                                                Console.WriteLine("Inserte la identificacion del cliente");
                                                CLientID = (Console.ReadLine());
                                                //TODO buscarClientes 
                                                //var ClientSearchPetition3 = new ClientPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    Identification = CLientID
                                                //};
                                                //var clienteSearchedResponse3 = soapClient.GetClientByIdentification(ClientSearchPetition3);
                                                var ClienteSearched3 = clienteSearchedResponse3.Data.FirstOrDefault();

                                                //TODO cliente eliminado
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
                                                    var DeleteClientResponse = soapClient.DeleteClient(ClientToDeletePetition);
                                                    if (DeleteClientResponse.Approved)
                                                    {

                                                        log.Info($"Elminacion del cliente {DeleteClientResponse.Data.FirstOrDefault().Name} {DeleteClientResponse.Data.FirstOrDefault().LastName}, por el empleado{Consoleaccount}");
                                                        Console.WriteLine("Cliente ha sido eliminado");
                                                        Console.WriteLine("Press Enter...");
                                                        Console.ReadLine();
                                                        Thread.Sleep(2000);
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine(DeleteClientResponse.Message);
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
                                                log.Error($"El usuario {Consoleuser.Email} intentó eliminar una cuenta sin permisos!");
                                                break;
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");

                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            log.Info($"Error: {e.Message}");
                                            break;
                                        }
                                    //Buscar Listado completo
                                    case "4":
                                        try
                                        {
                                            //TODO Mostrar todos los clientes
                                            //var FullListPetition = new ClientPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id

                                            //};
                                            //TODO todos los clientes
                                            //var listadoClientes = soapClient.GetAllClients(FullListPetition);
                                            if (listadoClientes.Approved)
                                            {
                                                foreach (var client in listadoClientes.Data)
                                                {
                                                    Console.WriteLine($"Nombre: {client.Name}, Apellido: {client.LastName}, telefono: {client.Telephone}, direccion: {client.Address}, identificacion: {client.Identification}");
                                                };
                                                Console.WriteLine("Press Enter...");
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
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");
                                            Console.ResetColor();

                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            log.Error($"Error: {e.Message}");
                                            break;
                                        }
                                    //Buscar por su id
                                    case "5":
                                        try
                                        {
                                            string id3;
                                            Console.WriteLine("Inserte su identificacion");
                                            id3 = (Console.ReadLine());
                                            //TODO Buscar por ID
                                            //var SearchClientPetition = new ClientPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id,
                                            //    Identification = id3
                                            //};
                                            //var SearchClientResponse = soapClient.GetClientByIdentification(SearchClientPetition);
                                            //var SearchedClient = SearchClientResponse.Data.FirstOrDefault();
                                            if (SearchClientResponse.Approved)
                                            {
                                                Console.WriteLine($"Nombre: {SearchedClient.Name}, Apellido: {SearchedClient.LastName}, identificacion: {SearchedClient.Identification}, direccion: {SearchedClient.Address}");

                                                log.Info($"Se buscó el cliente {SearchedClient.Name}, apellido: {SearchedClient.LastName} por el empleado{Consoleaccount}");
                                                Console.WriteLine("Press Enter...");
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

                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            log.Error($"Error: {e.Message}");
                                            break;
                                        }
                                    //Opcion invalida o Salir de menu
                                    default:
                                        Console.WriteLine("Saliendo de menú...");
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
                                Console.WriteLine("1. Crear una cuenta");
                                Console.WriteLine("2. Editar una cuenta");
                                Console.WriteLine("3. Borrar una cuenta");
                                Console.WriteLine("4. Buscar cuenta por el numero");
                                Console.WriteLine("5. Buscar listado de cuentas");
                                Console.WriteLine("6. Salir de este menú");
                                Console.WriteLine("");
                                Console.Write("Inserte la opción que desea: ");
                                resp = Console.ReadLine();
                                Console.WriteLine("Loading...");
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
                                                //TODO buscar todas las cuentas
                                                //var GetClientPetition = new ClientPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    Identification = identifi
                                                //};
                                                //var GetClientResponse = soapClient.GetClientByIdentification(GetClientPetition);
                                                if (GetClientResponse.Approved)
                                                {
                                                    //TODO insert cuenta 
                                                    //var Client = GetClientResponse.Data.FirstOrDefault();
                                                    //var InsertAccountPetition = new AccountPetitionHandler
                                                    //{
                                                    //    Origin = PetitionOrigin.CoreConsole,
                                                    //    UserId = Consoleuser.Id,
                                                    //    Account = new Account
                                                    //    {
                                                    //        Alias = alias,
                                                    //        AccountType = (AccountType)accountType,
                                                    //        CurrencyType = (WS.CurrencyType)CurrencyType,
                                                    //        AccountManagerId = 1,
                                                    //        OwnerId = Client.Id
                                                    //    }
                                                    //};
                                                    //var InsertAccountResponse = soapClient.InsertAccount(InsertAccountPetition);
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
                                    //Actualizar cuenta
                                    case "2":
                                        try
                                        {
                                            if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                            {
                                                Cuenta accountModel = new Cuenta();
                                                Console.WriteLine("Inserte el no. cuenta");
                                                var accNumber = Console.ReadLine();
                                                //TODO Actualizar Cuenta 
                                                //var cuentaToModificatePetition = new AccountPetitionHandler
                                                //{
                                                //    UserId = Consoleuser.Id,
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    Number = accNumber
                                                //};
                                                //var cuentaToModificateResponse = soapClient.GetAccountByNumber(cuentaToModificatePetition);
                                                if (cuentaToModificateResponse.Approved)
                                                {
                                                    accountModel = cuentaToModificateResponse.Data.FirstOrDefault();
                                                    var clienteResp = soapClient.GetClientByIdentification(new ClientPetitionHandler { Id = accountModel.OwnerId, Origin = PetitionOrigin.CoreConsole, UserId = Consoleuser.Id });
                                                    var cliente = clienteResp.Data.FirstOrDefault();
                                                    Console.WriteLine($"Numero: {accountModel.CuentaID}, Propietario: {cliente.Name} {cliente.LastName}, Balance: {accountModel.Balance}, Tipo Moneda: {accountModel.CurrencyType}, Tipo Cuenta: {accountModel.AccountType}");
                                                    Console.WriteLine("Desea modificarlo? {s/n}");
                                                    var confirmacion = Console.ReadLine();
                                                    if (confirmacion == "s")
                                                    {
                                                        Console.WriteLine("Inserte el tipo de cuenta {0 para ahorro, 1 para corriente, 2 para otro}");
                                                        accountModel.AccountType = (AccountType)int.Parse(Console.ReadLine());
                                                        Console.WriteLine("Inserte el tipo de dinero {0 para peso dominicano, 1 para dolar, 2 para euro");
                                                        accountModel.CurrencyType = (CurrencyType)int.Parse(Console.ReadLine());
                                                        //TODO insertar nueva cuenta
                                                        //var InsertAccountPetition2 = new AccountPetitionHandler
                                                        //{
                                                        //    Origin = PetitionOrigin.CoreConsole,
                                                        //    UserId = Consoleuser.Id,
                                                        //    Account = accountModel
                                                        //};
                                                        //var InsertAccountResponse2 = soapClient.UpdateAccount(InsertAccountPetition2);
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
                                    //Eliminar cuenta
                                    case "3":
                                        try
                                        {
                                            if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                            {
                                                string number;
                                                Console.WriteLine("Inserte el número de su cuenta");
                                                number = Console.ReadLine();
                                                //TODO buscador de cuenta
                                                //var AccountSearched3 = new AccountPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    Identification = number
                                                //};
                                                //var AccountSearched3Response = soapClient.GetAccountByNumber(AccountSearched3);
                                                //var AccountSearched = AccountSearched3Response.Data.FirstOrDefault();

                                                //TODO eliminar cuenta
                                                //var AccountToEliminatePetition = new AccountPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    Id = AccountSearched.Id
                                                //};
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
                                    //Buscar Cuenta por numero
                                    case "4":
                                        try
                                        {
                                            string number2;
                                            Console.WriteLine("Inserte el número de su cuenta");
                                            number2 = Console.ReadLine();
                                            //TODO buscar cuenta por numero
                                            //var AccountSearched3 = new AccountPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id,
                                            //    Identification = number2
                                            //};
                                            //var AccountSearched3Response = soapClient.GetAccountByNumber(AccountSearched3);
                                            //var AccountSearched = AccountSearched3Response.Data.FirstOrDefault();
                                            if (AccountSearched3Response.Approved)
                                            {
                                                Console.WriteLine($"Alias : {AccountSearched.Alias}, Numero : {AccountSearched.Number}, ClientID: {AccountSearched.OwnerId}");

                                                log.Info($"Se buscó la cuenta {AccountSearched.Alias}, por el empleado{Consoleaccount}");
                                                Console.WriteLine("Press Enter...");
                                                Console.ReadLine();
                                                Thread.Sleep(2000);
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(AccountSearched3Response.Message);
                                                Console.Clear();
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
                                    //Buscar listado de cuentas
                                    case "5":
                                        try
                                        {
                                            //TODO Listar todas las cuentas
                                            //var GetAllAccountsPetition = new AccountPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id

                                            //};
                                            //var GetAllAccountsResponse = soapClient.GetAllAccounts(GetAllAccountsPetition);
                                            if (GetAllAccountsResponse.Approved)
                                            {
                                                foreach (var Acc in GetAllAccountsResponse.Data)
                                                {
                                                    //TODO traer todas cuentas desde el 
                                                    //var clienteCuentaResponse = soapClient
                                                    //    .GetClientById(new ClientPetitionHandler { UserId = Consoleuser.Id, Origin = PetitionOrigin.CoreConsole, Id = Acc.OwnerId });
                                                    string nombreCliente = clienteCuentaResponse.Approved ? clienteCuentaResponse.Data.FirstOrDefault().Name : "";
                                                    string apellidoCliente = clienteCuentaResponse.Approved ? clienteCuentaResponse.Data.FirstOrDefault().LastName : "";
                                                    Console.WriteLine($"Alias: {Acc.Alias}, Numero: {Acc.Number}, Propietario: {nombreCliente} {apellidoCliente}");
                                                }
                                                log.Info($"Se buscó el listado de cuentas, por el empleado{Consoleaccount}");
                                                Console.WriteLine("Press Enter...");
                                                Console.ReadLine();
                                                Thread.Sleep(2000);
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(GetAllAccountsResponse.Message);
                                                Console.Clear();
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
                                    //Opcion erronea o salir
                                    default:
                                        Console.WriteLine("Saliendo de menú...");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                }
                                break;
                            #endregion
                            #region MENU Empleados
                            case "4":

                                string respuemp;
                                Console.WriteLine("Bienvenido al menú de usuarios empleados");
                                Console.WriteLine("Opciones:");
                                Console.WriteLine("1. Crear empleado");
                                Console.WriteLine("2. Actualizar empleado");
                                Console.WriteLine("3. Eliminar un empleado");
                                Console.WriteLine("4. Buscar un usuario por empleado");
                                Console.WriteLine("5. Buscar el listado de empleados");
                                Console.WriteLine("6. salir de este menú");
                                Console.WriteLine("");
                                Console.Write("Inserte la opción que desea: ");
                                respuemp = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Loading...");
                                Thread.Sleep(2000);
                                Console.Clear();

                                //Opciones
                                switch (respuemp)
                                {
                                    //Crear empleado
                                    case "1":
                                        try
                                        {
                                            if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                            {

                                                string user1, password1, email1;
                                                int id1, rolid;
                                                Console.WriteLine("Inserte su usuario");
                                                user1 = Console.ReadLine();
                                                Console.WriteLine("Inserte su correo");
                                                email1 = Console.ReadLine();
                                                Console.WriteLine("Inserte su contraseña");
                                                password1 = Console.ReadLine();
                                                Console.WriteLine("Ingrese su rol {0 para admin, 1 para CRUD, 2 para viewer}");
                                                rolid = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Inserte su Id de empleado");
                                                id1 = int.Parse(Console.ReadLine());
                                                //TODO Agregar empleado
                                                //var EmployeeInsertPetition = new EmployeeUserPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    User = new EmployeeUser
                                                //    {
                                                //        UserName = user1,
                                                //        Email = email1,
                                                //        Password = password1,
                                                //        Role = (Role)rolid,
                                                //        EmployeeId = id1

                                                //    }
                                                //};
                                                //var EmployeeInsertResponse = soapClient.InsertEmployeeUser(EmployeeInsertPetition);
                                                if (EmployeeInsertResponse.Approved)
                                                {
                                                    log.Info($"Inserción del usuario {user1}, por el empleado{Consoleaccount}");
                                                    Console.WriteLine("Ha sido insertado exitosamente!");
                                                    Console.WriteLine("Press Enter...");
                                                    Console.ReadLine();
                                                    Thread.Sleep(2000);
                                                    Console.Clear();
                                                    break;
                                                }

                                                else
                                                {
                                                    Console.WriteLine(EmployeeInsertResponse.Message);
                                                    Console.Clear();
                                                    break;
                                                }


                                            }
                                            else
                                            {
                                                Console.WriteLine("Usted no tiene permisos para esto!!");

                                                Thread.Sleep(1200);
                                                Console.Clear();
                                                log.Info($"El usuario {Consoleuser.Email} intentó crear un usuario sin permisos!");
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

                                    //Actualizar empleado
                                    case "2":
                                        try
                                        {
                                            if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                            {
                                                Empleado userModel = new Empleado();
                                                string user1;
                                                Console.WriteLine("Inserte su usuario");
                                                user1 = Console.ReadLine();
                                                //TODO actualizar empleado
                                                //var userToModificatePetition = new EmployeeUserPetitionHandler
                                                //{
                                                //    UserId = Consoleuser.Id,
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    Identification = user1
                                                //};
                                                //var userToModificateResponse = soapClient.GetEmployeeUserByUserName(userToModificatePetition);
                                                if (userToModificateResponse.Approved)
                                                {
                                                    userModel = userToModificateResponse.Data.FirstOrDefault();
                                                    Console.WriteLine($"ID: {userModel.EmpleadoId}\nEmail: {userModel.Email}\nUsername: {userModel.UserName}");
                                                    Console.WriteLine("Desea modificarlo? {s/n}");
                                                    var confirmacion = Console.ReadLine();
                                                    if (confirmacion == "s")
                                                    {
                                                        Console.WriteLine("Inserte su correo");
                                                        userModel.Email = Console.ReadLine();
                                                        Console.WriteLine("Inserte su contraseña");
                                                        userModel.Password = Console.ReadLine();
                                                        Console.WriteLine("Ingrese su rol {0 para admin, 1 para CRUD, 2 para viewer}");
                                                        userModel.RolesId = (Role)int.Parse(Console.ReadLine());
                                                        //TODO insertar empleado actualizado
                                                        //var EmployeeInsertPetition = new EmployeeUserPetitionHandler
                                                        //{
                                                        //    Origin = PetitionOrigin.CoreConsole,
                                                        //    UserId = Consoleuser.Id,
                                                        //    User = userModel
                                                        //};
                                                        //var EmployeeInsertResponse = soapClient.UpdateEmployeeUser(EmployeeInsertPetition);
                                                        if (EmployeeInsertResponse.Approved)
                                                        {

                                                            log.Info($"Modificacion del usuario {userModel.UserName}, por el empleado{Consoleaccount}");
                                                            Console.WriteLine("Ha sido modificado exitosamente!");
                                                            Console.WriteLine("Press Enter...");
                                                            Console.ReadLine();
                                                            Thread.Sleep(2000);
                                                            Console.Clear();
                                                            break;
                                                        }

                                                        else
                                                        {
                                                            Console.WriteLine(EmployeeInsertResponse.Message);
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    }


                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Usted no tiene permisos para esto!!");

                                                Thread.Sleep(1200);
                                                Console.Clear();
                                                log.Info($"El usuario {Consoleuser.Email} intentó crear un usuario sin permisos!");
                                                break;
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");

                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            log.Info($"Error: {e.Message}");
                                            break;
                                        }
                                        break;
                                    //Delete Employee
                                    case "3":
                                        try
                                        {
                                            if (((int)Consoleuser.Role == 0) || ((int)Consoleuser.Role == 1))
                                            {
                                                string EmployeeID;
                                                string confirmacion;
                                                Console.WriteLine("Inserte el usuario del empleado");
                                                EmployeeID = Console.ReadLine();
                                                //TODO buscar empleado para eliminar
                                                //var EmployeeDeletePetition = new EmployeeUserPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    Identification = EmployeeID
                                                //};
                                                //var SerchEmployee = soapClient.GetEmployeeUserByUserName(EmployeeDeletePetition);
                                                var SearchedEmployee = SerchEmployee.Data.FirstOrDefault();
                                                Console.WriteLine($"Id: {SearchedEmployee.Id}, Email: {SearchedEmployee.Email}, Usuario: {SearchedEmployee.UserName}");

                                                Console.WriteLine("Desea eliminarlo? {s/n}");
                                                confirmacion = Console.ReadLine();
                                                if (confirmacion == "s")
                                                {
                                                    //TODO eliminar empleado 
                                                    //var EmployeeDeletePetition2 = new EmployeeUserPetitionHandler
                                                    //{
                                                    //    Origin = PetitionOrigin.CoreConsole,
                                                    //    UserId = Consoleuser.Id,
                                                    //    Id = SearchedEmployee.Id
                                                    //};
                                                    //var EmployeeDeleteResponse = soapClient.DeleteEmployeeUser(EmployeeDeletePetition2);
                                                    if (EmployeeDeleteResponse.Approved)
                                                    {
                                                        log.Info($"Elminacion del usuario {SearchedEmployee.UserName}, por el empleado{Consoleaccount}");
                                                        Console.WriteLine("Usuario ha sido eliminado");
                                                        Console.WriteLine("Press Enter...");
                                                        Console.ReadLine();
                                                        Thread.Sleep(2000);
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine(EmployeeDeleteResponse.Message);
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
                                                log.Info($"El usuario {Consoleuser.Email} intentó eliminar un usuario sin permisos!");
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
                                    //Buscar empleado por su usuario
                                    case "4":
                                        try
                                        {
                                            string userName;
                                            Console.WriteLine("Inserte su usuario");
                                            userName = (Console.ReadLine());
                                            //TODO Buscar empleado por usuario
                                            //var ClientSearchPetition4 = new EmployeeUserPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id,
                                            //    Identification = userName
                                            //};
                                            //var clienteSearchedResponse4 = soapClient.GetEmployeeUserByUserName(ClientSearchPetition4);
                                            if (clienteSearchedResponse4.Approved)
                                            {
                                                var ClienteSearched4 = clienteSearchedResponse4.Data.FirstOrDefault();
                                                Console.WriteLine($"Id Usuario:{ClienteSearched4.Id}, Usuario : {ClienteSearched4.UserName}, Correo : {ClienteSearched4.Email}, EmployeeID: {ClienteSearched4.EmployeeId}");
                                                log.Info($"Se buscó el usuario {ClienteSearched4.UserName}, por el empleado{Consoleaccount}");
                                                Console.WriteLine("Press Enter...");
                                                Console.ReadLine();
                                                Thread.Sleep(2000);
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Usuario no encontrado,favor intente de nuevo");
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
                                    //Buscar lista de empleados1
                                    case "5":
                                        try
                                        {
                                            //TODO traer todos los empleados
                                            //var GetAllpetition = new EmployeeUserPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id,

                                            //};

                                            //var GetAllResponse = soapClient.GetAllEmployeeUsers(GetAllpetition);
                                            if (GetAllResponse.Approved)
                                            {
                                                foreach (var user in GetAllResponse.Data)
                                                {
                                                    Console.WriteLine($"Usuario: {user.UserName}, Correo: {user.Email}");
                                                }
                                                log.Info($"El usuario {Consoleuser} ha buscado la lista de empleados");
                                                Console.WriteLine("Press Enter...");
                                                Console.ReadLine();
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(GetAllResponse.Message);
                                                Console.WriteLine("Press Enter...");
                                                Console.ReadLine();
                                                Console.Clear();
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

                                    //Opcion incorrecta o salir de menu  
                                    default:
                                        Console.WriteLine("Saliendo de menú...");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                }
                                break;
                            #endregion
                            #region MENU TRANSACCIONES
                            case "5":
                                string answer0;
                                Console.WriteLine("Bienvenido al menú de transacciones!");
                                Console.WriteLine("Opciones:");
                                Console.WriteLine("1. Buscar listado de transacciones");
                                Console.WriteLine("2. Buscar por número de transacción");
                                Console.WriteLine("3. Filtrar transacciones por fecha");
                                Console.WriteLine("4. Buscar por Identiciacion del ordenante");
                                Console.WriteLine("5. Buscar por Identificacion del beneficiario");
                                Console.WriteLine("6. Salir de este menú");
                                Console.WriteLine("");
                                Console.Write("Inserte la opción que desea: ");
                                answer0 = Console.ReadLine();
                                Console.WriteLine("Loading...");
                                Thread.Sleep(2000);
                                Console.Clear();
                                switch (answer0)
                                {
                                    //BUSCAR LISTADO
                                    case "1":
                                        try
                                        {
                                            //TODO traer todas las transacciones
                                            //var GetAllpetition = new TransactionPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id,

                                            //};

                                            //var GetAllResponse = soapClient.GetAllTransactions(GetAllpetition);
                                            if (GetAllResponse.Approved)
                                            {
                                                foreach (var trans in GetAllResponse.Data)
                                                {
                                                    Console.WriteLine($"Numero: {trans.Number}, Identifacion del beneficiario: {trans.PayeeIdentification}, Identificacion del ordenante: {trans.PayerIdentification}, monto: {trans.Amount}, Concepto: {trans.Concept}");
                                                }
                                                log.Info($"El usuario {Consoleuser} ha buscado la lista de transacciones");
                                                Console.WriteLine("Press Enter...");

                                                Console.ReadLine();
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(GetAllResponse.Message);
                                                Console.WriteLine("Press Enter...");
                                                Console.ReadLine();
                                                Console.Clear();
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

                                    //Buscar por número de transaccion
                                    case "2":
                                        try
                                        {
                                            string Number;
                                            Console.WriteLine("Inserte el número de transacción");
                                            Number = Console.ReadLine();
                                            //TODO buscar por numero de transaccion
                                            //var TransactionSearchPetition = new TransactionPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id,
                                            //    Identification = Number
                                            //};
                                            //var TransactionSearchResponse = soapClient.GetTransactionByNumber(TransactionSearchPetition);
                                            if (TransactionSearchResponse.Approved)
                                            {
                                                var transac = TransactionSearchResponse.Data.FirstOrDefault();
                                                Console.WriteLine($"Numero: {transac.Number}, Identifacion del beneficiario: {transac.PayeeIdentification}, Identificacion del ordenante: {transac.PayerIdentification}, monto: {transac.Amount}, indole: {transac.Concept}");
                                                log.Info($"El empleado {Consoleaccount} buscó la transacción {Number}");
                                                Console.WriteLine("Press Enter...");
                                                Console.ReadLine();
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(TransactionSearchResponse.Message);
                                                Console.Clear();
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
                                    //Buscar por filtro de fecha
                                    case "3":
                                        try
                                        {
                                            DateTime? dateFrom;
                                            Console.WriteLine("Digite Fecha desde | formato dd/mm/yyyy");
                                            dateFrom = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                            DateTime? dateTo;
                                            Console.WriteLine("Digite Fecha hasta | formato dd/mm/yyyy");
                                            dateTo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                            //TODO Buscar por fecha la transaccion
                                            //var TransactionSearchPetition = new TransactionPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id,
                                            //    TransactionHistory = new TransactionHistory
                                            //    {
                                            //        CreationDateFrom = dateFrom,
                                            //        CreationDateTo = dateTo,
                                            //        IsTransactionType = false
                                            //    }
                                            //};
                                            // var TransactionSearchResponse = soapClient.FilterTransaction(TransactionSearchPetition);
                                            if (TransactionSearchResponse.Approved)
                                            {
                                                foreach (var trans in TransactionSearchResponse.Data)
                                                {
                                                    Console.WriteLine($"Numero: {trans.Number}, Identifacion del beneficiario: {trans.PayeeIdentification}, Identificacion del ordenante: {trans.PayerIdentification}, monto: {trans.Amount}, Concepto: {trans.Concept}");
                                                }
                                                log.Info($"El empleado {Consoleaccount} buscó la transacción de fecha entre {dateFrom} hasta {dateTo}");
                                                Console.WriteLine("Press Enter...");
                                                Console.ReadLine();
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(TransactionSearchResponse.Message);
                                                Console.Clear();
                                                break;
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");

                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            log.Info($"Error: {e.Message}");
                                            break;
                                        }
                                    //Buscar por ID del ordenante
                                    case "4":
                                        try
                                        {
                                            string identifi;
                                            Console.WriteLine("Inserte la identificación del ordenante");
                                            identifi = Console.ReadLine();
                                            //TODO buscar por identificacion 
                                            //var Cliente = new ClientPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id,
                                            //    Identification = identifi
                                            //};

                                            //var ClienteResponse = soapClient.GetClientByIdentification(Cliente);
                                            if (ClienteResponse.Approved)
                                            {
                                                //TODO Buscar lo buscado
                                                //var TransactionSearchPetition = new TransactionPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    Id = ClienteResponse.Data.FirstOrDefault().Id
                                                //};
                                                //var TransactionSearchResponse = soapClient.GetTransactionByPayer(TransactionSearchPetition);
                                                if (TransactionSearchResponse.Approved)
                                                {
                                                    foreach (var trans in TransactionSearchResponse.Data)
                                                    {
                                                        Console.WriteLine($"Numero: {trans.Number}, Identifacion del beneficiario: {trans.PayeeIdentification}, Identificacion del ordenante: {trans.PayerIdentification}, monto: {trans.Amount}, Concepto: {trans.Concept}");
                                                    }
                                                    log.Info($"El empleado {Consoleaccount} buscó la transacción del ordenante con id: {ClienteResponse.Data.FirstOrDefault().Id}");
                                                    Console.WriteLine("Press Enter...");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine(TransactionSearchResponse.Message);
                                                    Console.Clear();
                                                    break;
                                                }
                                            }
                                            break;

                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");

                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            log.Error($"Error: {e.Message}");
                                            break;
                                        }
                                    //Buscar por ID del beneficiario
                                    case "5":
                                        try
                                        {
                                            string identifi2;
                                            Console.WriteLine("Inserte la identificación del beneficiario");
                                            identifi2 = Console.ReadLine();
                                            //TODO buscar por beneficiario
                                            //var Cliente = new ClientPetitionHandler
                                            //{
                                            //    Origin = PetitionOrigin.CoreConsole,
                                            //    UserId = Consoleuser.Id,
                                            //    Identification = identifi2
                                            //};

                                            //var ClienteResponse = soapClient.GetClientByIdentification(Cliente);
                                            if (ClienteResponse.Approved)
                                            {
                                                //TODO Buscador transaccion
                                                //var TransactionSearchPetition = new TransactionPetitionHandler
                                                //{
                                                //    Origin = PetitionOrigin.CoreConsole,
                                                //    UserId = Consoleuser.Id,
                                                //    Id = ClienteResponse.Data.FirstOrDefault().Id
                                                //};
                                                //var TransactionSearchResponse = soapClient.GetTransactionByPayee(TransactionSearchPetition);
                                                if (TransactionSearchResponse.Approved)
                                                {
                                                    foreach (var trans in TransactionSearchResponse.Data)
                                                    {
                                                        Console.WriteLine($"Numero: {trans.Number}, Identifacion del beneficiario: {trans.PayeeIdentification}, Identificacion del ordenante: {trans.PayerIdentification}, monto: {trans.Amount}, Concepto: {trans.Concept}");
                                                    }
                                                    log.Info($"El empleado {Consoleaccount} buscó la transacción del ordenante con id: {ClienteResponse.Data.FirstOrDefault().Id}");
                                                    Console.WriteLine("Press Enter...");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine(TransactionSearchResponse.Message);
                                                    Console.Clear();
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Ha habido un error, comuniquese con el departamento de tecnologia!!");

                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            log.Error($"Error: {e.Message}");
                                            break;
                                        }
                                    //Opcion incorrecta o salir
                                    default:
                                        Console.WriteLine("Saliendo de menú...");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                }
                                break;
                            #endregion

                            #region OPCION INVALIDA
                            default:
                                Console.WriteLine("Opcion invalida!!");
                                Console.WriteLine("Intente de nuevo!");
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;
                                #endregion
                        }
                    }
                }
                #region Intentos fallidos
                else
                {
                    Console.WriteLine("Intento no valido!");
                    Console.WriteLine($"Intente de nuevo, le quedan {intentorestante} intentos");
                    Thread.Sleep(2000);
                    Console.Clear();
                    intento++;
                    intentorestante--;
                    log.Info($"El usuario {Consoleaccount} se intentó logear {intento} vez!");

                }
                #endregion
            }
        }
        #region Metodo para tagear y controlar contraseña
        static void CheckPassword(string EnterText)
        {
            try
            {
                Console.Write(EnterText);
                EnteredVal = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    // Backspace Should Not Work  
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
                                Console.WriteLine("Empty value not allowed.");
                                CheckPassword(EnterText);
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
        #region METODO PARA ESCRIBIR TITULO
        public static void WriteTitle(string text, string line)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(line);
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            foreach (char c in text)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(c);
                Thread.Sleep(100);
            }

            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
            Console.WriteLine(line);
            Thread.Sleep(3500);
            Console.ResetColor();
            Console.Clear();

        }
        #endregion
    }
}