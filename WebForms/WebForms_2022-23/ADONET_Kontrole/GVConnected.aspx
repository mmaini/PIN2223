<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GVConnected.aspx.cs" Inherits="ADONET_Kontrole.GridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <br />
        <div>
            ID:<asp:TextBox ID="tbId" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ime:<asp:TextBox ID="tbIme" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Prezime:<asp:TextBox ID="tbPrezime" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Godina upisa:<asp:TextBox ID="tbGodina" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:GridView ID="gvStudents" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
            &nbsp; <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            &nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            &nbsp;<asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click" />
            &nbsp;<asp:Button ID="btnTotal" runat="server" Text="Total" OnClick="btnTotal_Click" />
            <br />
            <br />
            <asp:Label ID="lblTotal" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </div>

</asp:Content>
