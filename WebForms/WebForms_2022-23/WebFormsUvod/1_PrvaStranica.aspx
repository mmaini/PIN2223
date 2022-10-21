<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="1_PrvaStranica.aspx.cs" Inherits="WebFormsUvod._1_PrvaStranica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <div>
            <h1>Moja prva stranica!</h1>
            <p>
                Unesi neki tekst:
                <asp:TextBox ID="tbTekst" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnKlikniMe" runat="server" OnClick="btnKlikniMe_Click" Text="Pošalji" />
            </p>
            <p>
                <asp:Label ID="LblRezultat" runat="server"></asp:Label>
            </p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
        </div>

</asp:Content>
