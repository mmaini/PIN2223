<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ADONET_Demo.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
        <div>
            <h4>Login</h4>
            <asp:Label ID="label_greska" runat="server" Text=""></asp:Label><br />
    <br />
    <br />  
            <asp:Label ID="lbl_kime" runat="server" Text="Korisničko ime:"></asp:Label>
            <asp:TextBox ID="tb_kime" runat="server"></asp:TextBox>
    <br />
    <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Korisničko ime je obavezan podatak!" ForeColor="Red" ControlToValidate="tb_kime">
            </asp:RequiredFieldValidator><br />
        
            <asp:Label ID="lbl_lozinka" runat="server" Text="Lozinka:"></asp:Label>
            <asp:TextBox ID="tb_lozinka" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />
            <asp:Button ID="btnPrijava" runat="server" Text="Prijava" OnClick="btnPrijava_Click" />
        </div>


</asp:Content>
