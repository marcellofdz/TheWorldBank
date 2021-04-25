using System;
using System.Configuration;
//using System.Data.Entity;
using System.Data.SqlClient;
using log4net;
using WebServiceIntegracion.Models;

namespace WebServiceIntegracion.Services
{
    public class UpsertServices
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        public static Respuesta UpsertAccount(CuentaCL cuenta )
        {
            Respuesta resp = new Respuesta();
            connection.Open();

            SqlTransaction trann = null;
            SqlCommand command = null;
            try
            {
                trann = connection.BeginTransaction();
                command = new SqlCommand("sp_UpsertAccount", connection, trann);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cuentaid", cuenta.CuentaId);
                command.Parameters.AddWithValue("@clienteid", cuenta.ClienteID);
                command.Parameters.AddWithValue("@tipocuentaid", cuenta.TipoCuentaId);
                command.Parameters.AddWithValue("@enabled", cuenta.Enabled);
                command.ExecuteNonQuery();
                trann.Commit();

                resp.Mensaje = $"Cuenta para cliente {cuenta.ClienteID} - guardada exitosamente";
                resp.Codigo = 0;
                log.Info(resp.Mensaje);
            }

            catch (Exception err)
            {
                trann.Rollback();
                resp.Mensaje = $"Error: en Cuenta de cliente {cuenta.ClienteID} - {err}";
                resp.Codigo = 2;
                log.Error(resp.Mensaje);

            }
            connection.Close();

            return resp;
        }

        public static Respuesta UpsertClient(ClienteCL cliente)
        {
            Respuesta resp = new Respuesta();
            connection.Open();

            SqlTransaction trann = null;
            SqlCommand command = null;
            try
            {
                trann = connection.BeginTransaction();
                command = new SqlCommand("sp_UpsertClient", connection, trann);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cedula", cliente.Cedula);
                command.Parameters.AddWithValue("@username", cliente.Username);
                command.Parameters.AddWithValue("@password", cliente.Password);
                command.Parameters.AddWithValue("@nombres", cliente.Nombres);
                command.Parameters.AddWithValue("@apellidos", cliente.Apellidos);
                command.Parameters.AddWithValue("@sexo", cliente.Sexo);
                command.Parameters.AddWithValue("@fechanacimiento", cliente.FechaNacimiento);
                command.Parameters.AddWithValue("@direccion", cliente.Direccion);
                command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Estado", cliente.Estado);
                command.ExecuteNonQuery();
                trann.Commit();

                resp.Mensaje = $"Cliente con cedula: {cliente.Cedula} - Guardado exitosamente";
                resp.Codigo = 0;
                log.Info(resp.Mensaje);
            }

            catch (Exception err)
            {
                trann.Rollback();
                resp.Mensaje = $"Error en Cliente con cedula: {cliente.Cedula} - {err}";
                resp.Codigo = 2;
                log.Error(resp.Mensaje);

            }
            connection.Close();

            return resp;
        }

        public static Respuesta UpsertEmployee(EmpleadoCL empleado)
        {
            Respuesta resp = new Respuesta();
            connection.Open();

            SqlTransaction trann = null;
            SqlCommand command = null;
            try
            {
                trann = connection.BeginTransaction();
                command = new SqlCommand("sp_UpsertEmployee", connection, trann);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cedula", empleado.Cedula);
                command.Parameters.AddWithValue("@username", empleado.Username);
                command.Parameters.AddWithValue("@password", empleado.Password);
                command.Parameters.AddWithValue("@roleid", empleado.RoleId);
                command.Parameters.AddWithValue("@nombres", empleado.Nombres);
                command.Parameters.AddWithValue("@apellidos", empleado.Apellidos);
                command.Parameters.AddWithValue("@sexo", empleado.Sexo);
                command.Parameters.AddWithValue("@fechanacimiento", empleado.FechaNacimiento);
                command.Parameters.AddWithValue("@Estado", empleado.Estado);
                command.ExecuteNonQuery();
                trann.Commit();

                resp.Mensaje = $"Empleado con cedula: {empleado.Cedula} - Guardado exitosamente";
                resp.Codigo = 0;
                log.Info(resp.Mensaje);
            }

            catch (Exception err)
            {
                trann.Rollback();
                resp.Mensaje = $"Error en Empleado con cedula: {empleado.Cedula} -{err}";
                resp.Codigo = 2;
                log.Error(resp.Mensaje);

            }
            connection.Close();

            return resp;
        }
    }
}