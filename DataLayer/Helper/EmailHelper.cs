using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace DataLayer.Helper
{
    public class EmailHelper
    {
        public void SendAppointmentEmail(User user)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                try
                {
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                    mailMessage.Subject = "Appointment setup completed";
                    mailMessage.Body = "Hi " + user.Name + ", Your appointment is been set up successfully....";
                    mailMessage.IsBodyHtml = false;
                    mailMessage.To.Add(new MailAddress(user.Email));
                    mailMessage.CC.Add(new MailAddress("shiv.rajaram07@gmail.com"));
                    mailMessage.Bcc.Add(new MailAddress("anurag.dealstodo@gmail.com"));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["Host"];
                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"]; //reading from web.config  
                    NetworkCred.Password = ConfigurationManager.AppSettings["Password"]; //reading from web.config  
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); //reading from web.config  
                    smtp.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/Logs/logdata.txt"));
                    file.WriteLine(ex.Message);
                    file.Dispose();
                }
            }

        }
    }
}
