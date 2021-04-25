﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebServiceIntegracion.Models;
namespace WebServiceIntegracion.Services
{
    public class InsertServices
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        public static Respuesta InsertTransaction(TransaccioneCL transaccione)
        {
            Respuesta resp = new Respuesta();
            connection.Open();

            SqlTransaction trann = null;
            SqlCommand command = null;
            try
            {
                double? monto = (transaccione.Credito.HasValue) ? transaccione.Credito : transaccione.Debito * -1;

                trann = connection.BeginTransaction();
                command = new SqlCommand("sp_InsertTransaction", connection, trann);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@clienteid", transaccione.ClienteId);
                command.Parameters.AddWithValue("@cuentaid", transaccione.CuentaId);
                command.Parameters.AddWithValue("@notas", transaccione.Notas);

                if (transaccione.TUsuarioId.GetValueOrDefault(0) > 0)
                {
                    command.Parameters.AddWithValue("@tusuarioid", transaccione.TUsuarioId);
                    command.Parameters.AddWithValue("@tusuariocuenta", transaccione.CuentaId);
                }

                command.Parameters.AddWithValue("@tusuariobancoid", transaccione.TUsuarioBancoId);
                command.Parameters.AddWithValue("@tipotransacid", transaccione.TipoTransacId);
                command.Parameters.AddWithValue("@tipomonedaid", transaccione.TipoMonedaId);
                command.Parameters.AddWithValue("@debito", transaccione.Debito);
                command.Parameters.AddWithValue("@credito", transaccione.Credito);
                command.ExecuteNonQuery();

                command = new SqlCommand("sp_UpdateAccountBalance", connection, trann);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@clienteid", transaccione.ClienteId);
                command.Parameters.AddWithValue("@cuentaid", transaccione.CuentaId);
                command.Parameters.AddWithValue("@monto", monto);

                if (transaccione.TUsuarioId.GetValueOrDefault(0) > 0)
                {
                    command.Parameters.AddWithValue("@tusuarioid", transaccione.TUsuarioId);
                    command.Parameters.AddWithValue("@tusuariocuenta", transaccione.CuentaId);
                }
                command.ExecuteNonQuery();
                trann.Commit();

                resp.Mensaje = $"Transaccion con numero de aprobacion {transaccione.NoAprobacion} - guardada exitosamente";
                resp.Codigo = 0;
                log.Info(resp.Mensaje);
            }

            catch (Exception err)
            {
                trann.Rollback();
                resp.Mensaje = $"Error: en Transaccion con numero de aprobacion {transaccione.NoAprobacion} - {err}";
                resp.Codigo = 2;
                log.Error(resp.Mensaje);

            }
            connection.Close();

            return resp;
        }
    }
}