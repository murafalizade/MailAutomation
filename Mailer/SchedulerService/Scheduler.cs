using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.SchedulerService
{
    class Scheduler
    {
        public static async Task SchedulJob()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<SchedulerJob>()
               .WithIdentity("jobName", "jobGroup")
               .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("triggerName", " triggerGorup")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(1)
                    .RepeatForever())
                .Build();
            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
