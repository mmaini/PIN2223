<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="ADONET_Demo.Registracija" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
        <div>
            <h4>Registriraj se</h4>
    <br />
    <br />
            <asp:Label ID="lbl_kime" runat="server" Text="Korisničko ime:"></asp:Label>
            <asp:TextBox ID="tb_kime" runat="server">
            </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Korisničko ime je obavezan podatak!" ForeColor="Red" ControlToValidate="tb_kime">
            </asp:RequiredFieldValidator><br />
    <br />
    <br />
            <asp:Label ID="lbl_ime" runat="server" Text="Puno ime:"></asp:Label>
            <asp:TextBox ID="tb_punoime" runat="server"></asp:TextBox><br />
    <br />
    <br />
            <asp:Label ID="lbl_lozinka" runat="server" Text="Lozinka:"></asp:Label>
            <asp:TextBox ID="tb_lozinka" runat="server" TextMode="Password"></asp:TextBox><br />
    <br />
    <br />
            <asp:Label ID="lbl_ponovljena_lozinka" runat="server" Text="Ponovljena lozinka:"></asp:Label>
            <asp:TextBox ID="tb_lozinka2" runat="server" TextMode="Password"></asp:TextBox><br />
    <br />
    <br />
            <asp:Button ID="btnRegistracija" runat="server" Text="Registriraj" OnClick="btnRegistracija_Click" />

        </div>

</asp:Content>
