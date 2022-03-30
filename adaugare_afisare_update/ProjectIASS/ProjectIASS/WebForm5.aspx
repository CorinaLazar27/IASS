<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="ProjectIASS.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="labelLogare" runat="server" Font-Bold="True" Font-Size="10pt" style="margin-left:15%;"></asp:Label>
        <br /><br /><br />
        <asp:GridView ID="GridView1" runat="server" style="margin-left: 13px" Width="500px"></asp:GridView>
    </form>
</asp:Content>
