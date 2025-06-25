using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Task1
{
    public partial class JobApplicationForm : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            //refresh();
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 6)
            {
                Response.Write("<script>alert('You are not eligible')</script>");
                Button1.Enabled = false;
            }
            else
            {
                Button1.Enabled = true;
            }
        }


        //public void refresh()
        //{
        //    TextBox1.Text = " ";
        //    TextBox2.Text = " ";
        //    TextBox3.Text = " ";
        //    TextBox4.Text = "0";
        //    TextBox5.Text = "0";
        //    TextBox6.Text = "0";

        //}

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "Fresher")
            {
                TextBox4.Enabled = false;
                TextBox5.Enabled = false;
                TextBox6.Enabled = false;
            }
            else
            {
                TextBox4.Enabled = true;
                TextBox5.Enabled = true;
                TextBox6.Enabled = true;
            }
        }



        protected void Button1_Click1(object sender, EventArgs e)
        {
            string Stream = DropDownList1.Text;
            string Experience = DropDownList2.Text;
            string Name = TextBox1.Text;
            string Email = TextBox2.Text;
            string ConatctNo = TextBox3.Text;
            double CTC = double.Parse(TextBox4.Text);
            double ECTC = double.Parse(TextBox5.Text);
            int NoticePeriod = int.Parse(TextBox6.Text);
            string Resume;

            FileUpload1.SaveAs(Server.MapPath("Resumes/") + Path.GetFileName(FileUpload1.FileName));
            Resume = "Resumes/" + Path.GetFileName(FileUpload1.FileName);
            string check = $"select count(*) from Candidates where Name='{Name}' AND Email='{Email}'";
            SqlCommand cmdCheck = new SqlCommand(check, conn);
            int count = (int)(cmdCheck.ExecuteScalar());
            if (count > 0)
            {
                Response.Write("<script>alert('User already exist')</script>");
            }
            else
            {
                string q = $"exec InsertCandidateData '{Name}','{Email}','{ConatctNo}','{Stream}','{Experience}','{CTC}','{ECTC}','{NoticePeriod}','{Resume}'";
                SqlCommand cmd = new SqlCommand(q, conn); ;
                cmd.ExecuteNonQuery();


                if (DropDownList2.SelectedValue == "Experience")
                {
                    //send mail to hr for experience
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("maithilidukhande2004@gmail.com");
                    mail.To.Add("sayalibandal103@gmail.com");
                    mail.Subject = "Employee details for interview";
                    mail.Body = $" Employee Details:\n Stream is {Stream}\n Experience is {Experience}\nName is{Name}\n Email is {Email}\n Number is {ConatctNo}\n CTC is {CTC}\n ECTC is {ECTC}\n Notice period is {NoticePeriod}\n Resume  {Resume}";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Credentials = new NetworkCredential("maithilidukhande2004@gmail.com", "rkznfhyuucpzyvfm");
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    Response.Write("<script>alert('Mail send successfully') </script>");
                    //Send mail to yourself for experience
                    MailMessage mail1 = new MailMessage();
                    mail1.From = new MailAddress("maithilidukhande2004@gmail.com");
                    mail1.To.Add("sayalibandal103@gmail.com");
                    mail1.Subject = "Interview update";
                    mail1.Body = " We wil reach back to you soon";
                    SmtpClient smtp1 = new SmtpClient("smtp.gmail.com");
                    smtp1.Credentials = new NetworkCredential("maithilidukhande2004@gmail.com", "rkznfhyuucpzyvfm");
                    smtp1.Port = 587;
                    smtp1.EnableSsl = true;
                    smtp1.Send(mail1);
                }
                else
                {
                    //send mail to hr for fresher
                    MailMessage mail2 = new MailMessage();
                    mail2.From = new MailAddress("maithilidukhande2004@gmail.com");
                    mail2.To.Add("sayalibandal103@gmail.com");
                    mail2.Subject = "Employee details for interview";
                    mail2.Body = $" Employee Details are as follows:\n Stream is {Stream}\n Experience is {Experience}\nName is{Name}\n Email is {Email}\n Number is {ConatctNo}\n CTC is {CTC}\n ECTC is {ECTC}\n Notice period is {NoticePeriod}\n Resume  {Resume}";
                    SmtpClient smtp2 = new SmtpClient("smtp.gmail.com");
                    smtp2.Credentials = new NetworkCredential("maithilidukhande2004@gmail.com", "rkznfhyuucpzyvfm");
                    smtp2.Port = 587;
                    smtp2.EnableSsl = true;
                    smtp2.Send(mail2);
                    Session["MyUser"] = TextBox1.Text;
                    Response.Redirect("BookSlot.aspx");

                }

            }
        }
    }
}
