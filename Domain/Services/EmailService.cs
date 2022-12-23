using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;

namespace DapperRentACar.Domain.Services
{
    public class EmailService
    {
        public static void SendEmail(string toGmail, string messageSubject, string message)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential("studentexamschool@gmail.com", "svlgybubckfekcln");
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.To.Add(toGmail);
                    mailMessage.From = new MailAddress("rhcardealership@gmail.com", "RH Car Dealership | Rent A Car");
                    mailMessage.Subject = messageSubject;
                    mailMessage.Body = message;
                    mailMessage.IsBodyHtml= true;

                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
