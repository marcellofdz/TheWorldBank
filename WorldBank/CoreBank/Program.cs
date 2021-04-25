using CoreBank.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        private static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
        private static int qtyReg = 0;
        private static string lineaMenu = "----------------------------------------------------------------------";

        static void Main(string[] args)
        {
            conn.Open();
            Console.WriteLine(conn.State);
            Console.CursorVisible = false;
            Console.SetWindowPosition(0, 0);
            string answer, userlogin;
            string texto = "THE WORLD BANK", linea = "-------------------------------------";
            WriteTitle(texto, linea);

            Console.Title = "CoreServer";

            Console.WriteLine("THE WORLD BANK");
            Console.WriteLine(lineaMenu);
            Console.WriteLine("Inicie sesión");
            Console.WriteLine(lineaMenu);
            Console.WriteLine("Inserte su usuario:");

            userlogin = Console.ReadLine();
            Console.WriteLine("Inserte su contraseña");
            string passwordlogin = Console.ReadLine();

            Console.Clear();

            SqlCommand command = new SqlCommand("sp_GetEmployee", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", userlogin);
            command.Parameters.AddWithValue("@password", passwordlogin);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine("Menu Principal");
                Console.WriteLine(lineaMenu);
                Console.WriteLine("1. Cliente");
                Console.WriteLine("2. Cuentas");
                Console.WriteLine("3. Empleado");
                Console.WriteLine("4. Transaccion");
                Console.WriteLine(lineaMenu);
                Console.Write("Inserte la opción que desea: ");
                answer = Console.ReadLine();
                Console.WriteLine("Loading...");
                Thread.Sleep(2000);
                Console.Clear();
                reader.Close();

                switch (answer)
                {
                    #region Cliente
                    case "1":
                        Console.WriteLine("Bienvenido al menú de cliente");
                        Console.WriteLine(lineaMenu);
                        Console.WriteLine("Opciones:");
                        Console.WriteLine(lineaMenu);
                        Console.WriteLine("1. Insertar un cliente");
                        Console.WriteLine("2. Actualizar un cliente");
                        Console.WriteLine("3. Salir de este menú");
                        Console.WriteLine(lineaMenu);
                        Console.Write("Inserte la opción que desea: ");
                        string respuesta = Console.ReadLine();
                        Console.WriteLine("Loading...");
                        Thread.Sleep(2000);
                        Console.Clear();

                        switch (respuesta)
                        {
                            #region Insertar cliente
                            case "1":
                                Console.WriteLine("INSERTAR NUEVO CLIENTE");
                                Console.WriteLine(lineaMenu);
                                Console.WriteLine("Inserte su nombre");
                                string name = Console.ReadLine();
                                Console.WriteLine("Inserte su apellido");
                                string lastname = Console.ReadLine();
                                Console.WriteLine("Inserte su usuario");
                                string user = Console.ReadLine();
                                Console.WriteLine("Inserte su contraseña");
                                string password = Console.ReadLine();
                                Console.WriteLine("Inserte la cedula");
                                string cedula = Console.ReadLine();
                                Console.WriteLine("Inserte su telefono");
                                string telefono = Console.ReadLine();
                                Console.WriteLine("Inserte su dirección");
                                string direccion = Console.ReadLine();
                                Console.WriteLine("Inserte su genero: M|F");
                                string genero = Console.ReadLine();
                                Console.WriteLine("Ingrese su fecha de nacimiento");
                                string fechaNacimiento = Console.ReadLine();
                                var ConvertFechaNacimiento = DateTime.Parse(fechaNacimiento);
                                Console.WriteLine("Ingrese el estado. Activo(1) | Inactivo(0)");
                                string estado = Console.ReadLine();
                                Console.WriteLine(lineaMenu);

                                SqlCommand clienteInsert = new SqlCommand("sp_UpsertClient", conn);
                                clienteInsert.CommandType = CommandType.StoredProcedure;
                                clienteInsert.Parameters.AddWithValue("@username", user);
                                clienteInsert.Parameters.AddWithValue("@password", password);
                                clienteInsert.Parameters.AddWithValue("@cedula", cedula);
                                clienteInsert.Parameters.AddWithValue("@nombres", name);
                                clienteInsert.Parameters.AddWithValue("@apellidos", lastname);
                                clienteInsert.Parameters.AddWithValue("@sexo", genero);
                                clienteInsert.Parameters.AddWithValue("@fechanacimiento", ConvertFechaNacimiento);
                                clienteInsert.Parameters.AddWithValue("@direccion", direccion);
                                clienteInsert.Parameters.AddWithValue("@Estado", estado);
                                clienteInsert.Parameters.AddWithValue("@telefono", telefono);
                                clienteInsert.ExecuteNonQuery();

                                qtyReg = clienteInsert.ExecuteNonQuery();
                                Console.WriteLine($"Registros afectados: {qtyReg}");
                                log.Info($"Cliente {user} fue creado");

                                break;
                            #endregion

                            #region Actualizar cliente
                            case "2":
                                Console.WriteLine("ACTUALIZAR CLIENTE");
                                Console.WriteLine(lineaMenu);
                                Console.WriteLine("Inserte su nombre:");
                                string name2 = Console.ReadLine();
                                Console.WriteLine("Inserte su apellido:");
                                string lastname2 = Console.ReadLine();
                                Console.WriteLine("Inserte su usuario:");
                                string user2 = Console.ReadLine();
                                Console.WriteLine("Inserte su contraseña:");
                                string password2 = Console.ReadLine();
                                Console.WriteLine("Inserte la cedula:");
                                string cedula2 = Console.ReadLine();
                                Console.WriteLine("Inserte su telefono:");
                                string telefono2 = Console.ReadLine();
                                Console.WriteLine("Inserte su dirección:");
                                string direccion2 = Console.ReadLine();
                                Console.WriteLine("Inserte su genero: M|F");
                                string genero2 = Console.ReadLine();
                                Console.WriteLine("Ingrese su fecha de nacimiento: (MM/dd/yyyy)");
                                string fechaNacimiento2 = Console.ReadLine();
                                var ConvertFechaNacimiento2 = DateTime.Parse(fechaNacimiento2);
                                Console.WriteLine("Ingrese el estado: Activo(1) | Inactivo(0)");
                                string estado2 = Console.ReadLine();
                                Console.WriteLine(lineaMenu);

                                SqlCommand clienteUpdate = new SqlCommand("sp_UpsertClient", conn);
                                clienteUpdate.CommandType = CommandType.StoredProcedure;
                                clienteUpdate.Parameters.AddWithValue("@username", user2);
                                clienteUpdate.Parameters.AddWithValue("@password", password2);
                                clienteUpdate.Parameters.AddWithValue("@cedula", cedula2);
                                clienteUpdate.Parameters.AddWithValue("@nombres", name2);
                                clienteUpdate.Parameters.AddWithValue("@apellidos", lastname2);
                                clienteUpdate.Parameters.AddWithValue("@sexo", genero2);
                                clienteUpdate.Parameters.AddWithValue("@fechanacimiento", ConvertFechaNacimiento2);
                                clienteUpdate.Parameters.AddWithValue("@direccion", direccion2);
                                clienteUpdate.Parameters.AddWithValue("@Estado", estado2);
                                clienteUpdate.Parameters.AddWithValue("@telefono", telefono2);

                                qtyReg = clienteUpdate.ExecuteNonQuery();
                                Console.WriteLine($"Registros afectados: {qtyReg}");
                                log.Info($"Cliente {user2} fue actualizado");

                                break;
                            #endregion

                            #region Salir
                            case "3":
                            default:
                                Console.WriteLine("Saliendo de menú...");
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;
                                #endregion
                        }
                        break;
                    #endregion

                    #region Cuenta
                    case "2":
                        string resp;
                        Console.WriteLine("Bienvneido al Menú de cuentas");
                        Console.WriteLine(lineaMenu);
                        Console.WriteLine("Opciones:");
                        Console.WriteLine("1. Crear una cuenta");
                        Console.WriteLine("2. Desactivar una cuenta");
                        Console.WriteLine("3. Salir de este menú");
                        Console.WriteLine(lineaMenu);
                        Console.Write("Inserte la opción que desea: ");
                        resp = Console.ReadLine();
                        Console.WriteLine(lineaMenu);
                        Console.WriteLine("Loading...");
                        Thread.Sleep(2000);
                        Console.Clear();

                        switch (resp)
                        {
                            #region Insertar cuenta
                            case "1":
                                Console.WriteLine("INSERTAR UNA CUENTA");
                                Console.WriteLine(lineaMenu);
                                Console.WriteLine("Inserte el tipo de cuenta: Ahorro(1) | Corriente(2)");
                                int tipoCuenta = int.Parse(Console.ReadLine());
                                Console.WriteLine("Inserte el estado: Activo(1)| Inactivo(0)");
                                string estado = Console.ReadLine();
                                Console.WriteLine("Ingrese el Id Cliente");
                                int clienteId = int.Parse(Console.ReadLine());
                                float balance = 0;
                                Console.WriteLine(lineaMenu);

                                SqlCommand cuentaInsert = new SqlCommand("sp_UpsertAccount", conn);
                                cuentaInsert.CommandType = CommandType.StoredProcedure;
                                cuentaInsert.Parameters.AddWithValue("@tipocuentaid", tipoCuenta);
                                cuentaInsert.Parameters.AddWithValue("@clienteid", clienteId);
                                cuentaInsert.Parameters.AddWithValue("@enabled", estado);
                                cuentaInsert.Parameters.AddWithValue("@balance", balance);

                                qtyReg = cuentaInsert.ExecuteNonQuery();
                                Console.WriteLine($"Registros afectados: {qtyReg}");
                                log.Info($"Se inserto la cuenta {clienteId}");

                                break;
                            #endregion

                            #region Actualizar estado cuenta
                            case "2":
                                Console.WriteLine("ACTUALIZAR ESTADO DE CUENTA");
                                Console.WriteLine(lineaMenu);
                                Console.WriteLine("Inserte el tipo de cuenta: Ahorro(1) | Corriente(2)");
                                int tipoCuenta2 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Inserte el estado: Activo(1)| Inactivo(0)");
                                string estado2 = Console.ReadLine();
                                Console.WriteLine("Ingrese el Id Cliente");
                                int clienteId2 = int.Parse(Console.ReadLine());
                                float balance2 = 0;

                                SqlCommand cuentaUpdate = new SqlCommand("sp_UpsertAccount", conn);
                                cuentaUpdate.CommandType = CommandType.StoredProcedure;
                                cuentaUpdate.Parameters.AddWithValue("@tipocuentaid", tipoCuenta2);
                                cuentaUpdate.Parameters.AddWithValue("@clienteid", clienteId2);
                                cuentaUpdate.Parameters.AddWithValue("@enabled", estado2);
                                cuentaUpdate.Parameters.AddWithValue("@balance", balance2);

                                qtyReg = cuentaUpdate.ExecuteNonQuery();
                                Console.WriteLine($"Registros afectados: {qtyReg}");
                                log.Info($"Se actualizo la cuenta {clienteId2}");

                                break;
                            #endregion

                            #region Salir
                            case "3":
                            default:
                                Console.WriteLine("Saliendo de menú...");
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;
                                #endregion
                        }
                        break;

                    #endregion

                    #region Empleado
                    case "3":
                        string respuemp;
                        Console.WriteLine("Bienvenido al menú de usuarios empleados");
                        Console.WriteLine(lineaMenu);
                        Console.WriteLine("Opciones:");
                        Console.WriteLine("1. Crear Empleados");
                        Console.WriteLine("2. Actualizar Empleados");
                        Console.WriteLine("3. Salir de este menú");
                        Console.WriteLine(lineaMenu);
                        Console.Write("Inserte la opción que desea: ");
                        respuemp = Console.ReadLine();
                        Console.WriteLine("Loading...");
                        Thread.Sleep(2000);
                        Console.Clear();

                        switch (respuemp)
                        {
                            #region Insertar Empleado
                            case "1":
                                Console.WriteLine("INSERTAR EMPLEADO");
                                Console.WriteLine(lineaMenu);
                                Console.WriteLine("Inserte su cedula:");
                                string cedulaemp = Console.ReadLine();
                                Console.WriteLine("Inserte su usuario:");
                                string useremp = Console.ReadLine();
                                Console.WriteLine("Inserte su contraseña:");
                                string paswordEmp = Console.ReadLine();
                                Console.WriteLine("Inserte su nombre:");
                                string nameEmp = Console.ReadLine();
                                Console.WriteLine("Inserte su apellido:");
                                string lastnameEmp = Console.ReadLine();
                                Console.WriteLine("Ingrese su genero: M|F");
                                string generoEmp = Console.ReadLine();
                                Console.WriteLine("Ingrese su rol: Admin(1) | Caja(2)");
                                int rolid = int.Parse(Console.ReadLine());
                                Console.WriteLine("Ingrese su fecha de nacimiento (MM/dd/yyyy)");
                                string fechaNacimientoEmp = Console.ReadLine();
                                var ConvertFechaNacimiento = DateTime.Parse(fechaNacimientoEmp);
                                Console.WriteLine("Inserte el estado del empleado: Activo(1) | Inactivo(0)");
                                int estadoEmp = int.Parse(Console.ReadLine());
                                Console.WriteLine(lineaMenu);

                                SqlCommand empleadoInsert = new SqlCommand("sp_UpsertEmployee", conn);
                                empleadoInsert.CommandType = CommandType.StoredProcedure;
                                empleadoInsert.Parameters.AddWithValue("@cedula", cedulaemp);
                                empleadoInsert.Parameters.AddWithValue("@username", useremp);
                                empleadoInsert.Parameters.AddWithValue("@password", paswordEmp);
                                empleadoInsert.Parameters.AddWithValue("@roleId", rolid);
                                empleadoInsert.Parameters.AddWithValue("@nombres", nameEmp);
                                empleadoInsert.Parameters.AddWithValue("@apellidos", lastnameEmp);
                                empleadoInsert.Parameters.AddWithValue("@sexo", generoEmp);
                                empleadoInsert.Parameters.AddWithValue("@fechanacimiento", ConvertFechaNacimiento);
                                empleadoInsert.Parameters.AddWithValue("@Estado", estadoEmp);

                                qtyReg = empleadoInsert.ExecuteNonQuery();
                                Console.WriteLine($"Registros afectados: {qtyReg}");
                                log.Info($"Se inserto el empleado {useremp}");


                                break;
                            #endregion

                            #region Actualizar empleado
                            case "2":
                                Console.WriteLine("ACTUALIZAR EMPLEADO");
                                Console.WriteLine(lineaMenu);
                                Console.WriteLine("Inserte su cedula:");
                                string cedulaemp2 = Console.ReadLine();
                                Console.WriteLine("Inserte su usuario:");
                                string useremp2 = Console.ReadLine();
                                Console.WriteLine("Inserte su contraseña:");
                                string paswordEmp2 = Console.ReadLine();
                                Console.WriteLine("Inserte su nombre:");
                                string nameEmp2 = Console.ReadLine();
                                Console.WriteLine("Inserte su apellido:");
                                string lastnameEmp2 = Console.ReadLine();
                                Console.WriteLine("Ingrese su genero: M|F");
                                string generoEmp2 = Console.ReadLine();
                                Console.WriteLine("Ingrese su rol: Admin(1) | Caja(2)");
                                int rolid2 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Ingrese su fecha de nacimiento: (MM/dd/yyyy)");
                                string fechaNacimientoEmp2 = Console.ReadLine();
                                var ConvertFechaNacimiento2 = DateTime.Parse(fechaNacimientoEmp2);
                                Console.WriteLine("Inserte el estado del empleado: Activo(1) | Inactivo(0)");
                                int estadoEmp2 = int.Parse(Console.ReadLine());
                                Console.WriteLine(lineaMenu);

                                SqlCommand empleadoUpdate = new SqlCommand("sp_UpsertEmployee", conn);
                                empleadoUpdate.CommandType = CommandType.StoredProcedure;
                                empleadoUpdate.Parameters.AddWithValue("@cedula", cedulaemp2);
                                empleadoUpdate.Parameters.AddWithValue("@username", useremp2);
                                empleadoUpdate.Parameters.AddWithValue("@password", paswordEmp2);
                                empleadoUpdate.Parameters.AddWithValue("@roleId", rolid2);
                                empleadoUpdate.Parameters.AddWithValue("@nombres", nameEmp2);
                                empleadoUpdate.Parameters.AddWithValue("@apellidos", lastnameEmp2);
                                empleadoUpdate.Parameters.AddWithValue("@sexo", generoEmp2);
                                empleadoUpdate.Parameters.AddWithValue("@fechanacimiento", ConvertFechaNacimiento2);
                                empleadoUpdate.Parameters.AddWithValue("@Estado", estadoEmp2);

                                qtyReg = empleadoUpdate.ExecuteNonQuery();
                                Console.WriteLine($"Registros afectados: {qtyReg}");
                                log.Info($"Se inserto el empleado {useremp2}");

                                break;
                            #endregion

                            #region Salir
                            case "3":
                            default:
                                Console.WriteLine("Saliendo de menú...");
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;
                                #endregion
                        }
                        break;
                    #endregion

                    #region Transaccion
                    case "4":
                        string answer0;
                        Console.WriteLine("Bienvenido al menú de transacciones!");
                        Console.WriteLine(lineaMenu);
                        Console.WriteLine("Opciones:");
                        Console.WriteLine("1. Listado de transacciones");
                        Console.WriteLine("2. Salir de este menú");
                        Console.WriteLine(lineaMenu);
                        Console.Write("Inserte la opción que desea: ");
                        answer0 = Console.ReadLine();
                        Console.WriteLine("Loading...");
                        Thread.Sleep(2000);
                        Console.Clear();

                        switch (answer0)
                        {
                            #region Mostrar transacciones
                            case "1":

                                Console.WriteLine("LISTAR TODAS LAS CUENTAS");
                                Console.WriteLine(lineaMenu);
                                Console.WriteLine("Inserte su Id Cuenta:");
                                int cuentaTransc = int.Parse(Console.ReadLine());

                                SqlCommand ShowTransaccion = new SqlCommand("sp_GetTrasactions", conn);
                                ShowTransaccion.CommandType = CommandType.StoredProcedure;
                                ShowTransaccion.Parameters.AddWithValue("@cuentaid", cuentaTransc);

                                SqlDataReader dataReader = ShowTransaccion.ExecuteReader();

                                while (dataReader.Read())
                                {
                                    Console.WriteLine($"{dataReader["ClienteId"]}\t{dataReader["CuentaId"]}\t{dataReader["TUsuarioCuenta"]}\t{dataReader["TUsuarioId"]}\t{dataReader["Notas"]}\t{dataReader["TipoTransacId"]}\t{dataReader["TUsuarioBancoId"]}\t{dataReader["TipoMonedaId"]}\t{dataReader["Debito"]}\t{dataReader["Credito"]}\t{dataReader["FechaAprobacion"]}\t{dataReader["NoAprobacion"]}");
                                }
                                dataReader.Close();
                                Console.WriteLine("Presiona Enter para salir");
                                Console.ReadLine();


                                break;
                            #endregion

                            #region Salir
                            case "2":
                            default:
                                Console.WriteLine("Saliendo de menú...");
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;
                                #endregion
                        }
                        break;
                        #endregion
                }
            }

            else
            {
                Console.WriteLine(userlogin);
                Console.WriteLine(passwordlogin);
                Console.WriteLine("Ingrese el usuario correcto");
                Console.ReadLine();
            }
        }

        public static string MaskPassword()
        {
            string psw = "";
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    psw += key.KeyChar;
                }
                else
                {
                    if (psw.Length > 0)
                    {
                        psw = psw.Remove(psw.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                key = Console.ReadKey(true);

            }
            Console.WriteLine();
            return psw;
        }

        public static void WriteTitle(string text, string line)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
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
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(line);
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            foreach (char c in text)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
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
    }
}