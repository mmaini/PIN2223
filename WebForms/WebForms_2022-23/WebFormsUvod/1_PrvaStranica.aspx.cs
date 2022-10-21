using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsUvod
{
    public partial class _1_PrvaStranica : System.Web.UI.Page
    {
        //Imamo 3 "pogleda" na stranicu:
        //1 - Source: kod za dizajn
        //2 - Design: vizualni prikaz stranice
        //3 - Code behind (.cs datoteka): programska logika (rukovanje događajima, pomoćni kod za obradu podataka, komunikaciju sa serverom...)

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //ovo je metoda (događaj) koji će se okinuti kada kliknemo na button
        protected void btnKlikniMe_Click(object sender, EventArgs e)
        {
            //čitamo vrijednost iz textbox-a i postavljamo vrijednost labele
            LblRezultat.Text = tbTekst.Text;
        }
    }
}