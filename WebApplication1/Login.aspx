<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link href="StyleSheet1.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Internet Banking</title>
</head>
<body>
	<header>Internet Banking</header>          
    <form id="form1" runat="server">
                    <div class="input">
			<h3>Inicio de Sesion</h3>
						<br />
                        <!--campos-->
            <asp:TextBox  placeholder="nombre de usuario" runat="server" ID="txtUsuario"></asp:TextBox>
			<asp:TextBox  placeholder="Cedula" runat="server" ID="txtCedula" ></asp:TextBox>
            <asp:TextBox  placeholder="Contraseña" runat="server" TextMode="Password" ID="txtPass"></asp:TextBox>

        </div>
        <!--botones-->
		<div class="button">
            <asp:Button ID="Button1" runat="server" Text="Iniciar sesion" OnClick="Button1_Click" />
			<asp:Button ID="Button2" runat="server" Text="Contáctenos" OnClick="Button2_Click" />

		</div>
     
             
    </form>



</body>
</html>
