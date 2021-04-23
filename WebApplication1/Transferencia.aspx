<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transferencia.aspx.cs" Inherits="WebApplication1.WebForm4" %>


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
            <li> <asp:Button class="hov" id="but1" runat="server" Text="Contactenos" OnClick="but1_Click" /></li>
            <li> <asp:Button class="hov" runat="server" Text="home" OnClick="Unnamed2_Click1"/> </li>
            <li> <asp:Button class="hov" runat="server" Text="Estado de cuenta" OnClick="Unnamed3_Click1"/> </li>
            <li> <asp:Button class="hov" runat="server" Text="Transaccion"/> </li>
          </ul>
      </nav>

	<div class="container">
		<div class="campos2">
			<h1 class="head">Transaccion Bancaria</h1>
			<asp:TextBox class="input" runat="server" ID="transUser" ReadOnly="True" ></asp:TextBox>
			<asp:TextBox class="input" runat="server" ID="transCed" ReadOnly="True" ></asp:TextBox> 
			<asp:TextBox class="input" runat="server" placeholder="numero de cuenta" ID="transACC"></asp:TextBox> 
			<asp:TextBox class="input" runat="server" placeholder="nombre del transferido" ID="transUser2"></asp:TextBox> 
			<asp:TextBox class="input" runat="server" placeholder="numero de cuenta del transferido" ID="transAcc2"></asp:TextBox> 
			<asp:TextBox class="input" runat="server" placeholder="monto a transferir" ID="transMonto"></asp:TextBox>

		<div class="button">
            <asp:Button ID="Button1" runat="server" Text="Confirmar Transaccion" OnClick="Button1_Click" />
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
