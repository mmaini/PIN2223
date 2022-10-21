<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="4_OsnovneKontrole.aspx.cs" Inherits="WebFormsUvod._4_OsnovneKontrole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <br />
            <br />
            <div>
            <asp:Label ID="lblBroj1" runat="server" Text="Broj 1: "></asp:Label>
            <asp:TextBox ID="tbBroj1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblBroj2" runat="server" Text="Broj 2:"></asp:Label>
            <asp:TextBox ID="tbBroj2" runat="server"></asp:TextBox>
            <br />
            <br />
            (Na klik buttona pročitamo vrijednosti iz textbox-eva i zbroj upišemo u lblRezultat)<br />
            <br />
            <asp:Button ID="btnZbroj" runat="server" OnClick="btnZbroj_Click" Text="Zbroji" />
            <br />
            <br />
            <asp:Label ID="lblRezultat" runat="server"></asp:Label>
            <br />
            <br />
            (Isto kao na klik buttona Zbroji)<br />
            <asp:LinkButton ID="lbZbroji" runat="server" OnClick="lbZbroji_Click">Zbroji s LinkButton</asp:LinkButton>
            <br />
            <br />
            <br />
            Na klik button-a dohvatimo index, vrijednost i tekst iz DropDownList<br />
            <br />
            <asp:DropDownList ID="ddlGrad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGrad_SelectedIndexChanged" style="height: 22px">
                <asp:ListItem Value="0">Odaberi grad</asp:ListItem>
                <asp:ListItem Value="10">Zagreb</asp:ListItem>
                <asp:ListItem Value="20">Split</asp:ListItem>
                <asp:ListItem Value="30">Osijek</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnGrad" runat="server" OnClick="btnGrad_Click" Text="Button" />
            <br />
            <br />
            <asp:Label ID="lblDdlRezultat" runat="server"></asp:Label>
                 Rezultat zbog button click-a<br />
            <br />
            <asp:Label ID="lblDdlRezultatDDL" runat="server"></asp:Label>
                 Rezultat zbog eventa na DDL (Postaviti Enable AutoPostBack)<br />
            <br />
            ListBox kontrola (omogućava odabir više opcija postavljanjem SelectionMode na Multiple)<br />
            <br />
            <asp:ListBox ID="lbJezici" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbJezici_SelectedIndexChanged" SelectionMode="Multiple">
                <asp:ListItem Value="10">C</asp:ListItem>
                <asp:ListItem Value="20">C++</asp:ListItem>
                <asp:ListItem Value="30">C#</asp:ListItem>
                <asp:ListItem Value="40">JavaScript</asp:ListItem>
            </asp:ListBox>
            <br />
            <br />
            <asp:Label ID="lblLbRezultat" runat="server"></asp:Label>
            <br />
            <br />
            CheckBoxList kontrola
            <br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" Height="102px" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" Width="126px">
                <asp:ListItem Value="1">Pizza</asp:ListItem>
                <asp:ListItem Value="2">Salata</asp:ListItem>
                <asp:ListItem Value="3">Tjestenina</asp:ListItem>
                <asp:ListItem Value="4">Odrezak</asp:ListItem>
            </asp:CheckBoxList>
            <br />
            <asp:Label ID="lblCbListRezultat" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            RadioButton (za odabir samo jednog potrebno postaviti GroupName)
            <p>
                <asp:RadioButton ID="rbMarketing" runat="server" GroupName="Odjel" Text="Marketing" />
                <asp:RadioButton ID="rbRacunovodstvo" runat="server" GroupName="Odjel" Text="Računovodstvo" />
                <asp:RadioButton ID="rbInformatika" runat="server" GroupName="Odjel" Text="Informatika" />
            </p>


        </div>

</asp:Content>
