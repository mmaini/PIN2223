<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="3_NavigacijaSaStranica.aspx.cs" Inherits="WebFormsUvod._3_NavigacijaSaStranic3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <br />
            <br />
            <br />
            <div>

            Kako se možemo prebaciti na neku drugu stranicu:<br />
            <br />
            1 - Pomoću hyperlink kontrole:
            <asp:HyperLink ID="hlDummyPage" runat="server" NavigateUrl="~/DummyStranica.aspx">HyperLink</asp:HyperLink>
            <br />
            <br />
            2 - <a href="DummyStranica.aspx">Pomoću alatne trake</a><br />
            <br />
            3 - Pomoću slike (ImageButton) - može se i obična slika dodati i dodijeliti joj link <br />
            <asp:ImageButton ID="imgLink" runat="server" Height="123px" ImageUrl="~/images/cvijet.jpg" OnClick="imgLink_Click" Width="182px" />
            <br />
            <br />
            <br />
            4 - Drag&nbsp; &amp; Drop stranice <a href="DummyStranica.aspx">DummyStranica.aspx</a>
            <br />
            5 - Pomoću Code Behind
            <asp:Button ID="btnDummy" runat="server" OnClick="btnDummy_Click" Text="Klikni me" />
            <br />
            <br />
            6 - Pomoću LinkButton kontrole:
            <asp:LinkButton ID="lbDummy" runat="server" OnClick="lbDummy_Click">LinkButton</asp:LinkButton>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
</asp:Content>
