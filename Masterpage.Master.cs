using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Loginpage
{
    public partial class Masterpage : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(@"Data Source= devops.aapnainfotech.com;SqlAuthenticationInitializer Catalog = apnsa; integrated Security = true; password:W98rd41lMravjL5;"))
            {
                sqlcon.Open();
                String query = "SELECT COUNT(1) FROM dbo.tblUser WHERE USERNAME =@username AND PASSWORD =@password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                sqlCmd.Parameters.AddWithValue("@username",txtUsername.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password",txtPassword.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if(count==1)
                {
                    Session["username"]=txtUsername.Text.Trim();
                    Response.Redirect("Dashboard.aspx");
                }
                else { lblErrorMessage.Visible = true; }




            }
        }

       
    }
}