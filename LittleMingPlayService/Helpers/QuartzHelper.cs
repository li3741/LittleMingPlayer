using Quartz;
using Quartz.Impl;
using Quartz.Impl.Calendar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleMingPlayService
{
    public class QuartzHelper
    {
        public static void InitJobs(PlayerHelper player, string strtime)
        {
            try
            {
                var strtimes = strtime.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                scheduler.Start();

                for (int i = 0; i < strtimes.Length; i += 3)
                {
                    DateTime dateTime = new DateTime(2018, 1, 1, int.Parse(strtimes[i]), int.Parse(strtimes[i + 1]), 0);


                    IJobDetail job = JobBuilder.Create<PlayMusicJob>().WithIdentity("job" + i.ToString(), "group1").Build();
                    job.JobDataMap.Add("playerHelper", player);
                    ITrigger trigger = TriggerBuilder.Create().WithIdentity("trigger" + i.ToString(), "group2").ForJob("job" + i.ToString(), "group1")
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(dateTime.Hour, dateTime.Minute)).Build();
                    scheduler.ScheduleJob(job, trigger);

                    dateTime.AddMinutes(int.Parse(strtimes[i + 2]));

                    IJobDetail job2 = JobBuilder.Create<StopMusicJob>().WithIdentity("job2-" + i.ToString(), "group1").Build();
                    job2.JobDataMap.Add("playerHelper", player);
                    ITrigger trigger2 = TriggerBuilder.Create().WithIdentity("trigger2-" + i.ToString(), "group2").ForJob("job2-" + i.ToString(), "group1")
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(dateTime.Hour, dateTime.Minute)).Build();
                    scheduler.ScheduleJob(job2, trigger2);

                }
            }
            catch (Exception er)
            {
                using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "webapierror.txt", true))
                {
                    writer.WriteLine(er.Source);
                    writer.Flush();
                }
            }
        }
    }



    public class PlayMusicJob : IJob
    {
        private PlayerHelper playerHelper;
        public void Execute(IJobExecutionContext context)
        {
            playerHelper = context.MergedJobDataMap.Get("playerHelper") as PlayerHelper;
            int dailyPlayTimeSpan = ConfigHelper.MyConfigure.dailyPlayTimeSpan;
            int.TryParse(Convert.ToString(context.MergedJobDataMap.Get("dailyPlayTimeSpan")), out dailyPlayTimeSpan);
            if (playerHelper == null)
                throw new Exception("请传递正确的音乐播放器进来实例");
            if (playerHelper.PlayListIndex == -1)
            {
                playerHelper.Play(0, true);
            }
            else
            {
                playerHelper.Play(playerHelper.PlayListIndex, true);
            }
        }
    }
    public class StopMusicJob : IJob
    {
        private PlayerHelper playerHelper;
        public void Execute(IJobExecutionContext context)
        {
            playerHelper = context.MergedJobDataMap.Get("playerHelper") as PlayerHelper;

            if (playerHelper == null)
                throw new Exception("请传递正确的音乐播放器进来实例");
            playerHelper.StopSlowly();

        }
    }
}
