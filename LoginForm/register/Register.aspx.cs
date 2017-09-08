using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginForm
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string email = TextBox2.Text;
            string password = TextBox3.Text;
            string cfpassword = TextBox4.Text;


            SqlConnection con = new SqlConnection(@" Data Source=SUYPC116;Initial Catalog=Student;Persist Security Info=True;User ID=sa;Password=Suyati123");
            con.Open();
            SqlCommand com = new SqlCommand("insert into Login (USERNAME,EMAIL,PASSWORD)values(@Name,@email,@password)",con) ;
            com.Parameters.AddWithValue("@Name", TextBox1.Text);
            com.Parameters.AddWithValue("@email", TextBox2.Text);
            com.Parameters.AddWithValue("@password", TextBox3.Text);
            com.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/Login.aspx");



        }
    }
}