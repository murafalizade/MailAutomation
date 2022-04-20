using Mailer.Controllers;
using Mailer.Data;
using Mailer.GoogleSheetService;
using Mailer.MailService;
using Mailer.Models;
using Mailer.SchedulerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mailer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //MailServiceHelper.SendEmail("muradaliyev2229@gmail.com");
            await Scheduler.SchedulJob();
            //await DatabaseController.DeleteAllData();
            Console.ReadLine();
        }
    }
}
