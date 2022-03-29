<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ProjectIASS.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #form1 {
            height: 225px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Gen&amp;Trimitere" />
        <asp:ListBox ID="ListBox1" runat="server" Height="34px" Width="130px"></asp:ListBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Refresh" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cautare " />
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Stergere" />
        <asp:Button ID="Button5" runat="server" Text="Adaugare" />
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Gen XML" />
</form>
</asp:Content>
