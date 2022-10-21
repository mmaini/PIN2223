using System;
using System.Web;
using System.Web.UI;

namespace StateManagementProjekt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Query string – uglavnom se koristi kada želimo podatke s jedne stranice proslijediti drugoj stranici.
        //Jednostavni su za korištenje.Rade na principu da se dodaju vrijednosti na kraju URL-a.
        //Prva se proslijeđena vrijednost navodi nakon ?, a sve ostale se odvajaju s &. 
        //Obzirom da se proslijeđene vrijednosti mogu vidjeti u adresnoj traci potrebno je pripaziti koji se podaci proslijeđuju.
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string queryString = "";
            queryString = "?ID=" + tbLogin.Text;
            queryString += "&Pass=" + tbPass.Text;
            Response.Redirect("QueryStringPrimjer.aspx" + queryString);
        }

        //Cookies – mala tekstualna datoteka koja se pohranjuje na korisnikovom računalu.
        //Koristi se kako bi pohranile neke informacije o korisniku.Postoje 2 vrste cookie-a: Persistent(imaju rok trajanja) i 
        //Non-Persistent(postoje sve dok korisnik ne zatvori browser).
        protected void btnCookie_Click(object sender, EventArgs e)
        {
            //https://www.digitalcitizen.life/cookies-location-windows-10/ - kako naći gdje je cookie spremljen
            //Chrome - kako vidjeti cookie https://www.digitalcitizen.life/view-and-remove-cookies-google-chrome/


            //kreiramo cookie, upišemo neki tekst u njega te mu postavimo da vrijedi jedan dan 
            HttpCookie mojCookie = new HttpCookie("MojCookie");
            mojCookie.Value = tbUnos.Text;
            mojCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(mojCookie);
            Response.Redirect("CookiePrimjer.aspx");
        }

        //Session State – kada korisnik pošalje prvi zahtjev on omogućava početak nove sesije.
        //Tijekom korištenja aplikacije korisnik obično obavlja više operacija (poziva). 
        //Kada se sesija pokrene može koristiti session objekt za pohranu informacija na serverskoj strani. 
        //Sesija omogućava pamćenje podataka preko više stranica unutar iste sesije (za razliku od ViewState). 
        //Session state varijable se pohranjuju na web serveru i nestaju kada dođe do timeout-a sesije.
        protected void btnLogin1_Click(object sender, EventArgs e)
        {

            Session["ID"] = tbLogin1.Text;
            Session["pass"] = tbPass1.Text;
            Response.Redirect("SessionStatePrimjer.aspx");
        }

        //Application state – podaci pohranjeni u application state su dostupni svim korisnicima aplikacije i može im se 
        //pristupiti od bilo kuda unutar aplikacije.
        protected void btnApplicationState_Click(object sender, EventArgs e)
        {
            Application["Tekst"] = tbUnos1.Text;
            Response.Redirect("ApplicationStatePrimjer.aspx");

        }
    }
}