using Quartz;
using Quartz.Impl;
using Quartz.Impl.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleMingPlayService
{
    public class QuartzHelper
    {
        public static void InitJobs(PlayerHelper player,string strtime)
        {
            try
            {
                var strtimes = strtime.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                scheduler.Start();

                for (int i = 0; i < strtimes.Length; i += 2)
                {
                    IJobDetail job = JobBuilder.Create<PlayMusicJob>().WithIdentity("job"+i.ToString(), "group1").Build();
                    job.JobDataMap.Add("playerHelper", player);
                    ITrigger trigger = TriggerBuilder.Create().WithIdentity("trigger"+i.ToString(), "group2").ForJob("job"+i.ToString(), "group1")
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(int.Parse(strtimes[i]),int.Parse(strtimes[i+1]))).Build();
                    scheduler.ScheduleJob(job, trigger);
                }
            }catch(Exception er)
            {
                throw er;
            }
        }
    }

     

    public class PlayMusicJob : IJob
    {
        private PlayerHelper playerHelper;
        public void Execute(IJobExecutionContext context)
        {
            playerHelper = context.MergedJobDataMap.Get("playerHelper") as PlayerHelper;
            if (playerHelper == null)
                throw new Exception("请传递正确的音乐播放器进来实例");
            if (playerHelper.PlayListIndex == -1)
            {
                playerHelper.Play(0);
            }
            else
            {
                playerHelper.Play();
            }
            playerHelper.SetPlayTime(ConfigHelper.MyConfigure.dailyPlayTimeSpan);
            System.Diagnostics.Debug.WriteLine("running");
        }
    }
}
