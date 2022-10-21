<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="2_Postback.aspx.cs" Inherits="WebFormsUvod._2_Postback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <br />
            <div>
            PostBack primjer<br />
                        - Želimo da se samo kod prvog učitavanja u Textbox upiše "Unesi svoje ime"
            <br />
            <p>
                        <asp:TextBox ID="tbTekst" runat="server"></asp:TextBox>
            </p>
            <p>
                        <asp:Button ID="btnKlikniMe" runat="server" OnClick="btnKlikniMe_Click" Text="Pošalji" />
            </p>
            <p>
                        <asp:Label ID="lblRezultat" runat="server"></asp:Label>
            </p>
            <br />
        </div>

</asp:Content>
