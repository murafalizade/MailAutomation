using Mailer.MailService;
using Mailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Controllers
{
    class MailController
    {
        public static async Task SendAllEmail()
        {
            List<MailModel> mails = DatabaseController.FindUnsendedEmail();
            foreach (MailModel mail in mails)
            {
                MailServiceHelper.SendEmail(mail.Email,mail.FullName);
                await DatabaseController.UpdateEmail(mail.Id);
                Console.WriteLine($"Mail is sended successfully to {mail.Email}");
            }
        }
    }
}
