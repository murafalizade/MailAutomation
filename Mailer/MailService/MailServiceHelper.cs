using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Mailer.MailService
{
    class MailServiceHelper
    {
        public static void SendEmail(string mailAddress, string fullName)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("muradexample7@gmail.com");
            message.To.Add(new MailAddress(mailAddress));
            message.Subject = "Information";
            message.Body = $"Thank {fullName} for participate our forum.";
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("muradexample7@gmail.com", "Murad1979.");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}
