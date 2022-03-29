<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ProjectIASS.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:Label ID="labelLogare" runat="server" Font-Bold="True" Font-Size="10pt" style="margin-left:15%;"></asp:Label>
        <br /><br /><br />
        <div style="margin-left:20%">
            <asp:Label runat="server" Text="Numele cautat:"></asp:Label> 
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" Text="Cauta" runat="server" OnClick="Button1_Click"/> 
        </div>
        <asp:Label ID="LabelCautare" runat="server" style="margin-left:25%" Font-Size="15pt"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" style="margin-left: 13px" Width="500px"></asp:GridView>
        <br /><br /><br />
        <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="100px" style="margin-left: 30px"></asp:DropDownList>
        <br /><br /><br />

        <div style="margin-left:30%">
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <asp:Button ID="Button3" Text="Vezi reteta" runat="server" Enabled="false" OnClick="Button3_Click"/>
            <asp:Button ID="Button4" Text="Completeaza chestionar" runat="server" Enabled="false" OnClick="Button4_Click" />

        </div>
        <asp:Button ID="Button2" runat="server" text="Adauga pacient" OnClick="Button2_Click"/>
&nbsp;&nbsp;&nbsp;
</form>
</asp:Content>


