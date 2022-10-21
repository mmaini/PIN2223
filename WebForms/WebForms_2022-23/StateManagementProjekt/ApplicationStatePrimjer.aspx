<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApplicationStatePrimjer.aspx.cs" Inherits="StateManagementProjekt.ApplicationStatePrimjer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
             <br />
            <br />
            <div>
            <asp:Label ID="lblApplicationState" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Home" />
        </div>

</asp:Content>
