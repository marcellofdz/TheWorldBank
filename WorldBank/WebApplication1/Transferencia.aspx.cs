using ServiceBank.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
	public partial class WebForm4 : System.Web.UI.Page
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		//cargamos los datos
		protected void Page_Load(object sender, EventArgs e)
		{
			transUser.Text = WebForm1.user;

		}

		//boton menu
		protected void Unnamed2_Click1(object sender, EventArgs e)
		{
			Response.Redirect("https://localhost:44368/Menu.aspx");
		}

		//boton consulta
		protected void Unnamed3_Click1(object sender, EventArgs e)
		{
			Response.Redirect("https://localhost:44368/Consulta.aspx");
		}

		//boton contactenos
		protected void but1_Click(object sender, EventArgs e)
		{
			//Response.Write("<script> window.alert('BancoInternacional@gmail.com'); window.location.href='https://localhost:44368/Transferencia.aspx'</script");

		}

		//boton realizar transferencia
		protected void Button1_Click(object sender, EventArgs e)
		{

			//SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
			//connection.Open();
			//Console.WriteLine("connection State: " + connection.State);
			//SqlTransaction tran = null;
			//SqlCommand command = null;

			try
			{



				//tran = connection.BeginTransaction();
				if (transUser.Text == "" || transUser2.Text == "" || transAcc2.Text == "" || transMonto.Text == "" )
				{
					ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Rellene todos los campos del formulario');", true);

					Response.Write("<script> window.alert('Rellene todos los campos del formulario'); window.location.href='https://localhost:44368/Transferencia.aspx'</script");
				}
				else
				{

					//command = new SqlCommand("ppTran", connection, tran);
					//command.Parameters.AddWithValue("@nombre1", transUser.Text);
					//command.Parameters.AddWithValue("@cedula1", WebForm1.ced);
					//command.Parameters.AddWithValue("@numeroCuenta1", transACC.Text);
					//command.Parameters.AddWithValue("@nombre2", transUser2.Text);
					//command.Parameters.AddWithValue("@numeroCuenta2", transAcc2.Text);
					//command.Parameters.AddWithValue("@monto", transMonto.Text);
					//command.CommandType = System.Data.CommandType.StoredProcedure;


					integracionws.WorldBankWebServiceSoapClient soapClient = new integracionws.WorldBankWebServiceSoapClient();
					//ws.WebServiceBankSoapClient soapClient = new ws.WebServiceBankSoapClient();


					integracionws.Cuenta confirmacion = soapClient.GetTUserAccountResp(transCedd2.Text, int.Parse(transAcc2.Text));
					if (confirmacion.ClienteID != 0)
					{
						integracionws.Cuenta cuenta = soapClient.GetAccountResp(int.Parse(WebForm1.ced))[0];
						integracionws.TransaccioneCL trans = new integracionws.TransaccioneCL();

						trans.ClienteId = int.Parse(WebForm1.ced);
						trans.CuentaId = cuenta.CuentaId;
						trans.TUsuarioCuenta = int.Parse(transAcc2.Text);
						trans.TipoTransacId = 3;
						trans.TUsuarioBancoId = 1;
						trans.TipoMonedaId = int.Parse(moneda.SelectedValue);
						trans.Debito = int.Parse(transMonto.Text);
						trans.Credito = 0;


						//command.ExecuteNonQuery();
						integracionws.Respuesta respuesta = soapClient.InsertTransactionResp(trans);

						if (int.Parse(transMonto.Text) < cuenta.Balance) {
							if (respuesta.Codigo == 0)
							{
								log.Debug("La transaccion ha sido procesada");
								log.Info($"nombre del usuario:{WebForm1.user}, cedula del usuario:{WebForm1.ced}, nombre del transferido:{transUser.Text}, numero de cuenta del transferido:{transAcc2.Text}, monto a transferir{transMonto.Text} ");
								Response.Write("<script> window.alert('transaccion realizada correctamente'); window.location.href='https://localhost:44368/Transferencia.aspx'</script");

							}
							else
							{
								log.Error("Error en la transaccion");
								ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ha ocurrido un error durante su transaccion intentelo mas tarde');", true);
							}
						}
						else
						{
							ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Monto Insuficiente');", true);
						}

						
					}
					else
					{
						Response.Write("<script> window.alert('Cuenta Inexistente'); window.location.href='https://localhost:44368/Transferencia.aspx'</script");

					}

					//tran.Commit()
				}
				

	

			}
			catch (Exception)
			{
				log.Error("Error en la transaccion");
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ha ocurrido un error durante su transaccion intentelo mas tarde');", true);

				//Response.Write("<script> window.alert('Ha ocurrido un error durante su transaccion intentelo mas tarde'); window.location.href='https://localhost:44368/Transferencia.aspx'</script");
			}

		

		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			Response.Redirect("https://localhost:44368/historial.aspx");
		}
	}
}