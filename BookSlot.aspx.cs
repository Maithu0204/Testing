using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task1
{
    public partial class BookSlot : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String Name=Session["NewUser"].ToString();
            string date,day, time;
            date = TextBox1.Text;
            day = DropDownList1.SelectedValue;
            time = DropDownList2.SelectedValue;
            string c = $"select count(*) from BookSlots where day='{day}' AND time='{time}'";
            SqlCommand cmd = new SqlCommand(c, conn);
            int count = (int)cmd.ExecuteScalar();
            if (count >= 2)
            {
                Response.Write("<script>alert('User is alredy exists!!!')</script>");
            }
            else
            {
                string q = $"exec SlotBook '{date}','{day}','{time}'";
                SqlCommand cmd1 = new SqlCommand(q, conn);
                cmd1.ExecuteNonQuery();
                Response.Write("<script>alert('Slot Book Successfully!!!')</script>");

            }
        }
       
    }
}