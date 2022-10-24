using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADONET_Kontrole
{
    public partial class GVDisconnected : System.Web.UI.Page
    {
        public static int Count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            Count++;

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdoNetKontroleConnectionString"].ToString());
            SqlCommand command = new SqlCommand("SELECT * FROM Student", connection);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command);
            //otvara konekciju, sprema podatke u tablicu Emp i zatvara konekciju
            //nad tablicom Student možemo obavljati sve operacije koje želimo
            da.Fill(ds, "Student");


            //kreiramo novi redak
            DataRow row = ds.Tables["Student"].NewRow();
            row["Ime"] = "Ime" + Count;
            row["Prezime"] = "Prezime";
            row["GodinaUpisa"] = 2020;

            //dodajemo ga tablici
            ds.Tables["Student"].Rows.Add(row);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(da);

            //ažuriramo tablicu u bazi
            da.Update(ds, "Student");

            //ispraznimo sadržaj dataset-a
            ds.Clear();

            //ponovno učitamo
            da.Fill(ds, "Student");


            //ažuriramo neki podatak u tablici
            ds.Tables["Student"].Rows[1]["Ime"] = "Novo ime";
            da.Update(ds, "Student");

            //ispraznimo sadržaj dataset-a
            ds.Clear();

            //ponovno učitamo
            da.Fill(ds, "Student");


            //brišemo zadnji dodani redak
            int brojRedaka = ds.Tables["Student"].Rows.Count;

            //označi redak obrisanim
            ds.Tables["Student"].Rows[brojRedaka - 1].Delete();

            //ažuriraj bazu
            da.Update(ds, "Student");

            //ispraznimo sadržaj dataset - a
            ds.Clear();

            //ponovno učitamo
            da.Fill(ds, "Student");

            //povezujemo grid i tablicu
            gvStudents.DataSource = ds.Tables["Student"];
            gvStudents.DataBind();
        }
    }
}