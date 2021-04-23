<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="StyleSheet2.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <nav>
	    <asp:Label Text="Internet Banking" runat="server" />
          <ul>
            <li> <asp:Button class="hov" runat="server" Text="Contactenos" OnClick="Unnamed2_Click"  /></li>
            <li> <asp:Button class="hov" runat="server" Text="home" OnClick="Unnamed5_Click3" /></li>
            <li> <asp:Button class="hov" runat="server" Text="Estado de cuenta"/> </li>
            <li> <asp:Button class="hov" runat="server" Text="Transaccion" OnClick="Unnamed6_Click3"/> </li>
          </ul>
      </nav>

	<div class="container">
		<div class="campos1">
			<h1 class="h1">Estado de Cuenta</h1>
			<asp:TextBox class="input" runat="server" ID="outUser" ReadOnly="True"></asp:TextBox> 
			<asp:TextBox class="input" runat="server" ID="outCedula" ReadOnly="True"></asp:TextBox>
			<asp:TextBox class="input" runat="server" ID="inCuenta" placeholder="Ingrese su numero de cuenta"></asp:TextBox> 
			<asp:TextBox class="input" runat="server" ID="outMonto" placeholder="monto actual" ReadOnly="True"></asp:TextBox> 
		<div class="button">
            <asp:Button ID="Button1" runat="server" Text="Estado de Cuenta" OnClick="Button1_Click"  />
		</div>
		</div>
	
	</div>
		



  </form>

	<footer>
		<a href="#"><img src="http://assets.stickpng.com/images/584ac2d03ac3a570f94a666d.png" /></a>
        <a href="#"><img src="http://assets.stickpng.com/images/580b57fcd9996e24bc43c521.png" /></a>
        <a href="#"><img src="http://assets.stickpng.com/images/58e9196deb97430e819064f6.png" /></a>

	</footer>

</body>

</html>
