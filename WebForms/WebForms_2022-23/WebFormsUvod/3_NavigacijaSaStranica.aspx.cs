using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsUvod
{
    public partial class _3_NavigacijaSaStranic3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgLink_Click(object sender, ImageClickEventArgs e)
        {
            //preusmjeravanje na neku drugu stranicu, paziti na putanju
            Response.Redirect("DummyStranica.aspx");
        }

        protected void btnDummy_Click(object sender, EventArgs e)
        {
            //preusmjeravanje na neku drugu stranicu, paziti na putanju
            Response.Redirect("DummyStranica.aspx");
        }

        protected void lbDummy_Click(object sender, EventArgs e)
        {
            //preusmjeravanje na neku drugu stranicu, paziti na putanju
            Response.Redirect("DummyStranica.aspx");
        }
    }
}