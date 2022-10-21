<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewStatePrimjer.aspx.cs" Inherits="StateManagementProjekt.ViewStatePrimjer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <br />
            <br />
            <div>
            Broj poziva:
            <asp:Label ID="lblBrojac" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnKlikniMe" runat="server" OnClick="btnKlikniMe_Click" Text="Klikni me" />
            <br />
            <br />
            <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Home" />
            <br />
        </div>
</asp:Content>
