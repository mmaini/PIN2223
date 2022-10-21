using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsUvod
{
    public partial class _4_OsnovneKontrole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Dohvaćamo vrijednosti iz tbBroj1 i tbBroj2, zbrajamo ih te ih ubacujemo u lblRezultat
        protected void btnZbroj_Click(object sender, EventArgs e)
        {
            int x, y;
            //x = Int32.Parse(tbBroj1.Text); //pretvaramo tekst u broj
            //y = Int32.Parse(tbBroj2.Text);

            //sigurnija opcija
            if (Int32.TryParse(tbBroj1.Text, out x) && Int32.TryParse(tbBroj2.Text, out y))
            {
                lblRezultat.Text = (x + y).ToString();
            }
            else
            {
                //ukoliko nismo uspjeli pretvoriti tekst u broj (parsiranje)
                lblRezultat.Text = "Neispravan unos";
            }

        }

        //Dohvaćamo vrijednosti iz tbBroj1 i tbBroj2, zbrajamo ih te ih ubacujemo u lblRezultat
        protected void lbZbroji_Click(object sender, EventArgs e)
        {
            int x, y;
            //x = Int32.Parse(tbBroj1.Text); //pretvaramo tekst u broj
            //y = Int32.Parse(tbBroj2.Text);

            //sigurnija opcija
            if (Int32.TryParse(tbBroj1.Text, out x) && Int32.TryParse(tbBroj2.Text, out y))
            {
                lblRezultat.Text = (x + y).ToString();
            }
            else
            {
                //ukoliko nismo uspjeli pretvoriti tekst u broj (parsiranje)
                lblRezultat.Text = "Neispravan unos";
            }
        }

        //Dohvaćamo podatke o odabramo gradu iz grid-a
        protected void btnGrad_Click(object sender, EventArgs e)
        {
            string rezultat = "Index je: " + ddlGrad.SelectedIndex.ToString() + ". Odabrana opcija je: " +
                             ddlGrad.SelectedItem.ToString() + ". Odabrana vrijednost je: " +
                             ddlGrad.SelectedValue.ToString();
                 lblDdlRezultat.Text = rezultat;
        }

        //Dohvaćamo podatke o odabramo gradu iz grid-a samo sada kroz događaj na samoj kontroli
        protected void ddlGrad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rezultat = "Index je: " + ddlGrad.SelectedIndex.ToString() + ". Odabrana opcija je: " +
                              ddlGrad.SelectedItem.ToString() + ". Odabrana vrijednost je: " +
                              ddlGrad.SelectedValue.ToString();
            lblDdlRezultatDDL.Text = rezultat;
        }

        //Ispisujemo u labeli odabrane jezike
        protected void lbJezici_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ako je bilo što označeno
            //Metoda GetSelectedIndices vraća niz u kojem se nalaze indexi odabranih elemenata, ako je veličina niza > 0 znači da imamo nešto označeno
            if (lbJezici.GetSelectedIndices().Length > 0)
            {
                string s = "Odabrali ste: ";
                foreach (ListItem item in lbJezici.Items) //šetamo po elementima u ListBox
                {
                    if (item.Selected) //ako je neki označen
                    {
                        s += item.Text + " ";
                    }
                }

                lblLbRezultat.Text = s;
            }
            else
            {

                lblLbRezultat.Text = "Niste ništa odabrali";
            }

        }

        //Ispisujemo što je odabrano u CheckBoxListi
        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "Odabrali ste: ";
            foreach (ListItem item in CheckBoxList1.Items) //šetamo po elementima u CheckBoxList
            {
                if (item.Selected) //ako je neki označen
                {
                    s += item.Text + " ";
                }
            }

            lblCbListRezultat.Text = s;
        }
    }
}