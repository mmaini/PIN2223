<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HiddenFieldPrimjer.aspx.cs" Inherits="StateManagementProjekt.HiddenFieldPrimjer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <br />
            <br />

            <div>
            <asp:HiddenField ID="HiddenField1" runat="server" Value="10" />
            <br />
            Hidden field vrijednost: <asp:Label ID="lblHidden" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Home" />
            <br />
        </div>
</asp:Content>
