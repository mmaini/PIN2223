<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GVDisconnected.aspx.cs" Inherits="ADONET_Kontrole.GVDisconnected" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <div>
            <asp:GridView ID="gvStudents" runat="server">
            </asp:GridView>
            <br />
            &nbsp;<asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click" Width="70px" />
            &nbsp;<br />
            &nbsp;&nbsp;&nbsp;<br />
        </div>
</asp:Content>
