<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm8.aspx.cs" Inherits="ProjectIASS.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form ID="form1" runat ="server">
        <asp:Label ID="labelLogare" runat="server" Font-Bold="True" Font-Size="10pt" style="margin-left:15%"></asp:Label>
        <br />
        <asp:Label ID="LabelEroare" runat="server" Font-Size="12pt" style="margin-left:15%"></asp:Label>
        <br /><br />
        <asp:Label runat="server" Text="Modificare stoc" Font-Size="13pt" style="margin-left:40%"></asp:Label>
        <br /><br />

        <div style="margin-left:35%">
           <asp:Label runat="server" Text="Introduceti noul stoc" Font-Size="11pt"></asp:Label>
           <asp:TextBox ID="TextBox1" runat="server" style="margin-left:12px"></asp:TextBox>
           <asp:Label ID="Label1" runat="server" Font-Size="11pt" style="margin-left:10px"></asp:Label>
        </div>
        <asp:Button Id="Buton1" runat="server" Text="Modifica" style="margin-left:46%" OnClick="Buton1_Click"/>
    </form>
</asp:Content>
