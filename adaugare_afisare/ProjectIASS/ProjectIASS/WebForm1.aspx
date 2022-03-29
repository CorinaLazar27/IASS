<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProjectIASS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="css/my.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="my.css">
  
</head>

    <body style="height: 660px" id="login">
        <form id="form1" runat="server">
             <br /> 
             <br />
             <br />
             <br />
             <br />
             <br />
          
        <div style="width: 290px; height: 345px; margin-left: 40%; margin-right:40%; margin-top:10%;"  id="div">

            <br />

            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="25pt" Text="Login" style="margin-left:40%; margin-right:50%;"></asp:Label>
            <br />
            <br />
            <br />

            <asp:Label ID="Label1" runat="server" Text="Utilizator"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="249px" style="margin-left: 13px">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Parola"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="20px" TextMode="Password" Width="243px" style="margin-left: 8px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Height="32px" Text="Autentificare" Width="250px" OnClick="Button1_Click" style="margin-left: 12px" />

        </div>
    </form>
    
</body>
</html>
