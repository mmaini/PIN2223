<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SessionStatePrimjer.aspx.cs" Inherits="StateManagementProjekt.SessionStatePrimjer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <br />
          <br />
            <div>
            <asp:Label ID="lblRezultat" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Home" />
            </div> 
</asp:Content>
