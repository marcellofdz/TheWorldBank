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
		protected void Page_Load(object sender, EventArgs e)
		{
			transUser.Text = WebForm1.user;
			transCed.Text = WebForm1.ced;
		}


		protected void Unnamed2_Click1(object sender, EventArgs e)
		{
			Response.Redirect("https://localhost:44368/Menu.aspx");
		}

		protected void Unnamed3_Click1(object sender, EventArgs e)
		{
			Response.Redirect("https://localhost:44368/Consulta.aspx");
		}

		protected void but1_Click(object sender, EventArgs e)
		{
			Response.Write("<script> window.alert('BancoInternacional@gmail.com'); window.location.href='https://localhost:44368/Transferencia.aspx'</script");

		}

		protected void Button1_Click(object sender, EventArgs e)
		{

			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
			connection.Open();
			Console.WriteLine("connection State: " + connection.State);
			SqlTransaction tran = null;
			SqlCommand command = null;

			try
			{
				tran = connection.BeginTransaction();

				command = new SqlCommand("ppTran", connection, tran);
				command.Parameters.AddWithValue("@nombre1", transUser.Text);
				command.Parameters.AddWithValue("@cedula1", transCed.Text);
				command.Parameters.AddWithValue("@numeroCuenta1", transACC.Text);
				command.Parameters.AddWithValue("@nombre2", transUser2.Text);
				command.Parameters.AddWithValue("@numeroCuenta2", transAcc2.Text);
				command.Parameters.AddWithValue("@monto", transMonto.Text);
				command.CommandType = System.Data.CommandType.StoredProcedure;

				command.ExecuteNonQuery();

				tran.Commit();
				log.Debug("La transaccion ha sido procesada");
				log.Info($"nombre del usuario:{WebForm1.user}, cedula del usuario:{WebForm1.ced}, numero de cuenta del usuario:{transACC.Text}, nombre del transferido:{transUser.Text}, numero de cuenta del transferido:{transAcc2.Text}, monto a transferir{transMonto.Text} ");
				Response.Write("<script> window.alert('transaccion realizada correctamente'); window.location.href='https://localhost:44368/Transferencia.aspx'</script");
			}
			catch (Exception)
			{
				tran.Rollback();
				log.Error("Error en la transaccion");
				Response.Write("<script> window.alert('Ha ocurrido un error durante su transaccion intentelo mas tarde'); window.location.href='https://localhost:44368/Transferencia.aspx'</script");
			}

		

		}
	}
}