<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="ProjectIASS.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #form1 {
            height: 391px;
            width: 1096px;
        }
        #TextArea1 {
            height: 56px;
            width: 363px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div style="height: 99px; width: 357px; margin-left: 280px">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click2" Text="Completeaza" />
            <br />
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="168px" TextMode="MultiLine" Width="355px"></asp:TextBox>
        </div>
    </form>
</asp:Content>
