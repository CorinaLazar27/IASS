<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="ProjectIASS.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form ID="form1" runat ="server">
        <asp:Label ID="labelLogare" runat="server" Font-Bold="True" Font-Size="10pt" style="margin-left:15%"></asp:Label>
        <br />
        <asp:Label ID="LabelEroare" runat="server" Font-Size="12pt" style="margin-left:15%"></asp:Label>
        <br /><br />
        <asp:Label runat="server" Text="Adaugare pacient" Font-Size="13pt" style="margin-left:40%"></asp:Label>
        <br /><br />

        <div style="margin-left:35%">
           <asp:Label runat="server" Text="CNP" Font-Size="11pt"></asp:Label>
           <asp:TextBox ID="TextBox1" runat="server" style="margin-left:12px"></asp:TextBox>
           <asp:Label ID="Label1" runat="server" Text="CNP incorect!!" Font-Size="11pt" style="margin-left:10px"></asp:Label>
        </div>
        <div style="margin-left:35%">
           <asp:Label runat="server" Text="Nume" Font-Size="11pt"></asp:Label>
           <asp:TextBox ID="TextBox2" runat="server" style="margin-left:12px"></asp:TextBox>
        </div>
        <div style="margin-left:35%">
           <asp:Label runat="server" Text="Prenume" Font-Size="11pt"></asp:Label>
           <asp:TextBox ID="TextBox3" runat="server" style="margin-left:12px"></asp:TextBox>
        </div>
        <div style="margin-left:35%">
           <asp:Label runat="server" Text="Diagnostic" Font-Size="11pt"></asp:Label>
           <asp:TextBox ID="TextBox4" runat="server" style="margin-left:12px"></asp:TextBox>
        </div>
        <asp:Button Id="Buton1" runat="server" Text="Adauga" style="margin-left:46%" OnClick="Buton1_Click"/>
    </form>
</asp:Content>
