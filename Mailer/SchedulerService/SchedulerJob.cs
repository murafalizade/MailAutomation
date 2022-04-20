using Mailer.Controllers;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.SchedulerService
{
    class SchedulerJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Starting...");
            await GoogleSheetController.AddEmailFromAPI();
            await MailController.SendAllEmail();
            Console.WriteLine("Ended...");
        }
    }
}
