using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagementProjekt
{
    public partial class QueryStringPrimjer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //čitanje vrijednosti iz query stringa
                string login = Request.QueryString["ID"];
                string pass = Request.QueryString["Pass"];
                lblPodaci.Text = login + " " + pass;
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}