using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADONET_Demo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPrijava_Click(object sender, EventArgs e)
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MojConnectionString"].ConnectionString;
            //dodati using System.Data.SqlClient; da bi mogli pristupiti
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand comm = new SqlCommand("SELECT password, salt, fullname FROM Users WHERE username = @username", conn);
            comm.Parameters.AddWithValue("username", tb_kime.Text);
            try
            {
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    //Ponovi hashiranje i vidi da li se lozinke podudaraju
                    string sol = dr["salt"].ToString();
                    string spremljenaLozinka = dr["password"].ToString();
                    string hashLozinka = Utility.Hash(tb_lozinka.Text);
                    //dodaj salt i ponovno hashiraj 
                    string hashSlanaLozinka = Utility.Hash(hashLozinka + sol);
                    if (spremljenaLozinka == hashSlanaLozinka)
                    {
                        Session["ime"] = dr["fullname"].ToString();
                        Response.Redirect("Stranica.aspx");
                    }
                    else
                    {
                        label_greska.Text = "Nepostojeći korisnik!";
                    }

                }
                else
                {
                    label_greska.Text = "Nepostojeći korisnik!";
                }
            }
            catch (Exception ex)
            {
                //logiraj
            }
            finally
            {
                conn.Close();
            }
        }
    }
}