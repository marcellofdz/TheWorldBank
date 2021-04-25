﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
	public partial class WebForm1 : System.Web.UI.Page
	{

		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		//variables globales
		public static string user = "", pass ="", ced ="", cedula = "";

		////boton contactenos
		protected void Button2_Click(object sender, EventArgs e)
		{
			//Response.Write("<script> window.alert('BancoInternacional@gmail.com'); window.location.href='https://localhost:44368/Login.aspx'</script");
		}

		//iniciar sesion
		protected void Button1_Click(object sender, EventArgs e)
		{
			//coneccion base de datos
			//SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
			//connection.Open();
			//Console.WriteLine("connection State: " + connection.State);
			//SqlCommand command = null;
			//SqlDataReader dr = null;

			user = txtUsuario.Text.ToString();
			cedula = txtCedula.Text.ToString();
			pass = txtPass.Text.ToString();


			//command = new SqlCommand("ppLogin", connection);
			//command.Parameters.AddWithValue("@nombre", user);
			//command.Parameters.AddWithValue("@cedula", ced);
			//command.Parameters.AddWithValue("@contraseña", pass);
			//command.CommandType = System.Data.CommandType.StoredProcedure;

			//	dr = command.ExecuteReader();
			ws.WebServiceBankSoapClient soapClient = new ws.WebServiceBankSoapClient();
			ws.Cliente cliente = soapClient.GetClientResp(user, pass);
			ced = cliente.ClienteID.ToString();
			//inicio de sesion
			if (!string.IsNullOrEmpty(cliente.Cedula))
				{

					Response.Redirect("https://localhost:44368/Menu.aspx");
				}
				else
				{
					log.Error("Datos invalidos");

					ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('datos invalidos');", true);
			}
				

			

		}

	}
}