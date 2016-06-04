﻿<%@ Page Title="Cajero" Language="C#" AutoEventWireup="true" CodeFile="Cambio de pin.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
	
	<title>Cajero Automatico</title>

<!--Este es el estilo de la pagina-->
	<style type="text/css">
	body
	{
		background: black;
		color: black;
		font: 150% arial;
		text-align: center;
	}	
	</style>
	
</head>

	<body>
        <form id="IngresoPin" runat="server">

		<!--este es in div para el fondo -->
		<div id="fondo">
			<img src="img/fondo.jpg">
		</div>


		<!--en este div se le pone la posicion para que este quede sobre el fondo -->
		<div id="inicio-de-secion" style="position:absolute; top:36px; left:381px; visibility:visible">

			<h1>Cambio de Pin</h1>

			<br/> <br/>

			ingrese su pin:..............<asp:TextBox ID="pintext" runat=server textmode="Password" />

            <br/>

            <asp:Label ID="pinInvalido"  backcolor="Red" Text="" runat="server"></asp:Label>
             <br/>

            ingrese el nuevo pin:.....<asp:TextBox ID="Pin1" runat=server textmode="Password" />

            <br/>

            Vuelva a ingresar el pin:<asp:TextBox ID="Pin2" runat=server textmode="Password" />

            <br/>

            <asp:Label ID="pines"  backcolor="Red" Text="" runat="server"></asp:Label>
			
			<br/> <br/> <br/>

            <asp:ImageButton id="Entrar" runat="server" ImageUrl="img/entrar.png"  onclick="Entrar_Click"/>
            <asp:ImageButton id="Cancelar" runat="server" ImageUrl="img/cancelar.png"  onclick="Cancelar_Click"/>
	

			
		</div>
             </form>
</body>
</html>