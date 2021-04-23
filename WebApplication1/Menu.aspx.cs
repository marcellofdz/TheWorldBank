using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
	public partial class WebForm2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		//boton estado de cuenta
		protected void Unnamed3_Click1(object sender, EventArgs e)
		{
			Response.Redirect("https://localhost:44368/Consulta.aspx");
		}
		//boton transaccion
		protected void Unnamed4_Click1(object sender, EventArgs e)
		{
			Response.Redirect("https://localhost:44368/Transferencia.aspx");
		}
		//boton contactenos
		protected void but1_Click(object sender, EventArgs e)
		{
			Response.Write("<script> window.alert('BancoInternacional@gmail.com'); window.location.href='https://localhost:44368/Menu.aspx'</script");

		}
	}
}