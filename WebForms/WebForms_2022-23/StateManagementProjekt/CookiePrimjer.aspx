<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CookiePrimjer.aspx.cs" Inherits="StateManagementProjekt.CookiePrimjer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <br />
 <br />

            <div>
            <asp:Label ID="lblCookie" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Home" />
            </div> 
</asp:Content>
