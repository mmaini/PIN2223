using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagementProjekt
{
    public partial class ViewStatePrimjer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //u ovom primjeru brojimo i prikazujemo koliko se puta dogodio postback

            if (IsPostBack)
            {
                if (ViewState["brojac"] != null)
                {
                    int brojac = Convert.ToInt32(ViewState["brojac"]) + 1;
                    lblBrojac.Text = brojac.ToString();
                    ViewState["brojac"] = brojac.ToString();
                }
                else
                {
                    ViewState["brojac"] = "1";
                }
            }
        }

        protected void btnKlikniMe_Click(object sender, EventArgs e)
        {
            lblBrojac.Text = ViewState["brojac"].ToString();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}