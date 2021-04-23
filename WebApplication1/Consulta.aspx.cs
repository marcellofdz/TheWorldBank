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



	public partial class WebForm3 : System.Web.UI.Page
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		//cargamos los datos
		protected void Page_Load(object sender, EventArgs e)
		{
			outUser.Text = WebForm1.user;
			outCedula.Text = WebForm1.ced;
		}

		//boton menu
		protected void Unnamed5_Click3(object sender, EventArgs e)
		{
			Response.Redirect("https://localhost:44368/Menu.aspx");
		}

		//boton transferencia
		protected void Unnamed6_Click3(object sender, EventArgs e)
		{
			Response.Redirect("https://localhost:44368/Transferencia.aspx");
		}

		//boton contactenos
		protected void Unnamed2_Click(object sender, EventArgs e)
		{
			Response.Write("<script> window.alert('BancoInternacional@gmail.com'); window.location.href='https://localhost:44368/Consulta.aspx'</script");

		}

		//boton estado de cuenta
		protected void Button1_Click(object sender, EventArgs e)
		{

			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
			connection.Open();
			Console.WriteLine("connection State: " + connection.State);
			SqlCommand command = null;
			SqlDataReader dr = null;

			

			command = new SqlCommand("ppConsulta", connection);
			command.Parameters.AddWithValue("@nombre", WebForm1.user);
			command.Parameters.AddWithValue("@cedula", WebForm1.ced);
			command.Parameters.AddWithValue("@numeroCuenta", inCuenta.Text);
			command.CommandType = System.Data.CommandType.StoredProcedure;
			
			dr = command.ExecuteReader();

			if (dr.Read())
			{
				outMonto.Text = dr["monto"].ToString();
			}
			else
			{
				log.Error("Numero de  invalidos");
				Response.Write("<script> window.alert('numero de cuenta incorrecto'); window.location.href='https://localhost:44368/Consulta.aspx'</script");
			}

		}

			
	}
}