using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ServiceBank.Models;

namespace ServiceBank.Services
{
    public class GetServices
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        public static Cliente GetClient(string username, string password)
        {
            Cliente client = new Cliente();
            Respuesta resp = new Respuesta();
            connection.Open();
            SqlCommand command = null;

            command = new SqlCommand("sp_GetClient", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            using (SqlDataReader dreader = command.ExecuteReader())
            {
                if (dreader.HasRows)
                {
                    while (dreader.Read())
                    {
                        client.ClienteID = (int)dreader["ClienteID"];
                        client.Cedula = (string)dreader["Cedula"];
                        client.Nombres = (string)dreader["Nombres"];
                        client.Apellidos = (string)dreader["Apellidos"];
                        client.Sexo = (string)dreader["Sexo"];
                        client.FechaNacimiento = (DateTime)dreader["FechaNacimiento"];
                        client.FechaIngreso = (DateTime)dreader["FechaIngreso"];
                        client.Direccion = (string)dreader["Direccion"];
                        client.Telefono = (string)dreader["Telefono"];
                    }
                    resp.Mensaje = $"Cliente encontrado {client.Cedula}";
                    resp.Codigo = 0;
                    log.Info(resp.Mensaje);
                }
                else
                {
                    resp.Mensaje = "Cliente no encontrado";
                    resp.Codigo = 2;
                    log.Info(resp.Mensaje);
                }
                connection.Close();

                return client;
            }
        }

        public static Empleado GetEmployee(string username, string password)
        {
            Empleado employee = new Empleado();
            Respuesta resp = new Respuesta();

            connection.Open();
            SqlCommand command = null;

            command = new SqlCommand("sp_GetEmployee", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            using (SqlDataReader dreader = command.ExecuteReader())
            {
                if (dreader.HasRows)
                {
                    while (dreader.Read())
                    {
                        employee.EmpleadoId = (int)dreader["EmpleadoId"];
                        employee.Cedula = (string)dreader["Cedula"];
                        employee.RoleId = (int)dreader["RoleId"];
                        employee.Nombres = (string)dreader["Nombres"];
                        employee.Apellidos = (string)dreader["Apellidos"];
                        employee.Sexo = (string)dreader["Sexo"];
                        employee.FechaNacimiento = (DateTime)dreader["FechaNacimiento"];
                        employee.FechaIngreso = (DateTime)dreader["FechaIngreso"];
                    }
                    resp.Mensaje = $"Empleado encontrado {employee.Cedula}";
                    resp.Codigo = 0;
                    log.Info(resp.Mensaje);
                }
                else
                {
                    resp.Mensaje = "Empleado no encontrado";
                    resp.Codigo = 2;
                    log.Info(resp.Mensaje);
                }
            }
            connection.Close();

            return employee;
        }

        public static List<Cuenta> GetAccount(int clienteid)
        {
            Respuesta resp = new Respuesta();
            List<Cuenta> result = new List<Cuenta>();
            connection.Open();
            SqlCommand command = null;

            command = new SqlCommand("sp_GetAccounts", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@clienteid", clienteid);

            using (SqlDataReader dreader = command.ExecuteReader())
            {
                if (dreader.HasRows)
                {
                    while (dreader.Read())
                    {
                        Cuenta account = new Cuenta();

                        account.CuentaId = (int)dreader["CuentaId"];
                        account.ClienteID = (int)dreader["ClienteID"];
                        account.TipoCuentaId = (int)dreader["TipoCuentaId"];
                        account.Balance = (double)dreader["Balance"];
                        account.FechaCreacion = (DateTime)dreader["FechaCreacion"];

                        result.Add(account);
                    }

                    resp.Mensaje = $"Cuenta encontrada - Cliente: {clienteid}";
                    resp.Codigo = 0;
                    log.Info(resp.Mensaje);
                }

                else
                {
                    resp.Mensaje = $"Cuenta no encontrada - Cliente: {clienteid}";
                    resp.Codigo = 2;
                    log.Info(resp.Mensaje);
                }
            }
            connection.Close();

            return result;
        }

        public static List<Transaccione> GetTrasactions(int cuenta)
        {
            Respuesta resp = new Respuesta();
            List<Transaccione> result = new List<Transaccione>();
            connection.Open();
            SqlCommand command = null;

            command = new SqlCommand("sp_GetTrasactions", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@cuenta", cuenta);

            using (SqlDataReader dreader = command.ExecuteReader())
            {
                if (dreader.HasRows)
                {
                    while (dreader.Read())
                    {
                        Transaccione transaccione = new Transaccione();

                        transaccione.ClienteId = (int)dreader["ClienteId"];
                        transaccione.CuentaId = (int)dreader["CuentaId"];
                        transaccione.TUsuarioCuenta = (int)dreader["TUsuarioCuenta"];
                        transaccione.TUsuarioCedula = (string)dreader["TUsuarioCedula"];
                        transaccione.Notas = (string)dreader["Notas"];
                        transaccione.TipoTransacId = (int)dreader["TipoTransacId"];
                        transaccione.TUsuarioBancoId = (int)dreader["TUsuarioBancoId"];
                        transaccione.TipoMonedaId = (int)dreader["TipoMonedaId"];
                        transaccione.Debito = (double)dreader["Debito"]; ;
                        transaccione.Credito = (double)dreader["Credito"];;
                        transaccione.FechaAprobacion = (DateTime)dreader["FechaAprobacion"];
                        transaccione.NoAprobacion = (string)dreader["NoAprobacion"];

                        result.Add(transaccione);
                    }

                    resp.Mensaje = $"Transacciones encontradas - Cuenta: {cuenta}";
                    resp.Codigo = 0;
                    log.Info(resp.Mensaje);
                }

                else
                {
                    resp.Mensaje = $"No hay transacciones con esta cuenta: {cuenta}";
                    resp.Codigo = 2;
                    log.Info(resp.Mensaje);
                }
            }
            connection.Close();

            return result;
        }
    }
}