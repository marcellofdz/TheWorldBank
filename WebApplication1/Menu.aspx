<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="WebApplication1.WebForm2" %>

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
            <li> <asp:Button class="hov" runat="server" Text="home" /></li>
            <li> <asp:Button class="hov" runat="server" Text="Estado de cuenta" OnClick="Unnamed3_Click1"/> </li>
            <li> <asp:Button class="hov" runat="server" Text="Transaccion" OnClick="Unnamed4_Click1" /></li>
          </ul>
      </nav>
    
    

  </form>

	<div class="container1">
        <div class="frase">
		    <h1 class="texto">Banco Mundial</h1>
            <h1 class="texto">Nunca dependas de un sólo ingreso</h1>
		     <br />
		     <h2 class="texto">BancoInternacional@gmail.com</h2>
		     <h2 class="texto">(011) 4780-006</h2>

	    </div>
    </div>

	<footer>
		<a href="#"><img src="http://assets.stickpng.com/images/584ac2d03ac3a570f94a666d.png" /></a>
        <a href="#"><img src="http://assets.stickpng.com/images/580b57fcd9996e24bc43c521.png" /></a>
        <a href="#"><img src="http://assets.stickpng.com/images/58e9196deb97430e819064f6.png" /></a>

	</footer>

</body>

</html>
