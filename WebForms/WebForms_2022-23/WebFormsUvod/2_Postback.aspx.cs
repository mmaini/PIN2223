using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsUvod
{
    public partial class _2_Postback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ukoliko je prvo učitavanje (znači nije PostBack)
            if (!IsPostBack)
            {
                tbTekst.Text = "Unesi svoje ime";
            }
        }

        protected void btnKlikniMe_Click(object sender, EventArgs e)
        {
            lblRezultat.Text = "Hello " + tbTekst.Text;
        }
    }
}