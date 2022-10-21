<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StateManagementProjekt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

            <div>
            Linkovi na primjere:<br />
            <a href="ViewStatePrimjer.aspx">ViewState primjer</a><br />
            <a href="HiddenFieldPrimjer.aspx">Hidden Field primjer</a><br />
            <br />
            <hr />
            <br />
            Query string primjer:<br />
            Login:
            <asp:TextBox ID="tbLogin" runat="server"></asp:TextBox>
            Password:
            <asp:TextBox ID="tbPass" runat="server"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
            <br />
            <br />
            <hr />
            <br />
            Cookies primjer:<br />
            Neki tekst:
            <asp:TextBox ID="tbUnos" runat="server"></asp:TextBox>
            <asp:Button ID="btnCookie" runat="server" OnClick="btnCookie_Click" Text="Klikni me" />
            <br />
            <br />
            <hr />
            <br />
            Session state primjer:<br />
            Login:
            <asp:TextBox ID="tbLogin1" runat="server"></asp:TextBox>
            Password:
            <asp:TextBox ID="tbPass1" runat="server"></asp:TextBox>
            <asp:Button ID="btnLogin1" runat="server" OnClick="btnLogin1_Click" Text="Login" />
            <br />
            <br />
            <hr />
            <br />
            Application state primjer:<br />
            Neki tekst:
            <asp:TextBox ID="tbUnos1" runat="server"></asp:TextBox>
            <asp:Button ID="btnApplicationState" runat="server" OnClick="btnApplicationState_Click" Text="Klikni me" />
            <br />
            <br />
        </div>

</asp:Content>
