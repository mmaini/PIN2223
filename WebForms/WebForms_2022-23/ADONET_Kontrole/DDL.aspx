<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DDL.aspx.cs" Inherits="ADONET_Kontrole.DDL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" 
        AutoPostBack="True" DataSourceID="SqlDataSource1" 
        DataTextField="Ime" DataValueField="Id" 
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AdoNetKontroleConnectionString %>" DeleteCommand="DELETE FROM [Student] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Student] ([Ime]) VALUES (@Ime)" SelectCommand="SELECT [Id], [Ime] FROM [Student]" UpdateCommand="UPDATE [Student] SET [Ime] = @Ime WHERE [Id] = @Id">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Ime" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Ime" Type="String" />
        <asp:Parameter Name="Id" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>

    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="lblIzbor" runat="server" Text=""></asp:Label>


</asp:Content>
