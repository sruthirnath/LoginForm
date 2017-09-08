using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginForm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (Membership.ValidateUser(TextBox1.Text, TextBox2.Text))
            //{
            //    FormsAuthentication.RedirectFromLoginPage("TextBox1.Text", CheckBox1.Checked);
            //}
            //else
            //{
            //    Label3.Text = "INVALID USER NAME AND PASSWORD";
            //}
            int attempts;
            attempts = Convert.ToInt32(ViewState["attempts"]);

            SqlConnection con = new SqlConnection("Data Source=SUYPC116;Initial Catalog=Student;Persist Security Info=True;User ID=sa;Password=Suyati123");
            con.Open();
           
            SqlCommand com = new SqlCommand("select PASSWORD from Login where USERNAME=@Name",con);
            com.Parameters.AddWithValue("@Name", TextBox1.Text);
            Session["name"] = TextBox1.Text;
            
            
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            string pass = Convert.ToString(sdr[0]);

                            if (TextBox2.Text == pass.TrimEnd())
                            {
                                Response.Redirect("~/Welcome.aspx");
                            }
                            else
                            {
                                Label3.Text = "Invalid username or password";
                            }
                        }
                    }
                }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/register/Register.aspx");
        }
    }








    
}