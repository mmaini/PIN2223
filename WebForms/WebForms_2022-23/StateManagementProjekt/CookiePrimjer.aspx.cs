using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagementProjekt
{
    public partial class CookiePrimjer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cookie = Request.Cookies["MojCookie"].Value;
            lblCookie.Text = cookie;
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}