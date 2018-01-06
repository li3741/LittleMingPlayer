using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LittleMingPlayer
{
    public class ConfigHelper
    {
        public static void InitConfig()
        {
            var player = PlayerHelper.Inst();
            var format = ConfigurationManager.AppSettings["fileFormat"].ToString();
            if (string.IsNullOrEmpty(format))
            {
                format = "*.mp3";
            }
            var folder = ConfigurationManager.AppSettings["filesFolder"].ToString();
            if (!string.IsNullOrEmpty(folder))
            {
                if (System.IO.Directory.Exists(folder))
                {
                    PlayerHelper.Inst().PlayList.AddRange(System.IO.Directory.GetFiles(folder, format, System.IO.SearchOption.AllDirectories));
                }
            }
            var dailyPlayTime = ConfigurationManager.AppSettings["dailyPlayTime"].ToString();
            if (!string.IsNullOrEmpty(dailyPlayTime))
            {
                QuartzHelper.InitJobs(player, dailyPlayTime);
            }
            var apiport = ConfigurationManager.AppSettings["apiport"].ToString();
            ApiPort = string.IsNullOrEmpty(apiport) ? "9898" : apiport;
            var dailyPlayTimeSpan = 15;
            int.TryParse(ConfigurationManager.AppSettings["dailyPlayTimeSpan"].ToString(), out dailyPlayTimeSpan);
            DailyPlayTimeSpan = dailyPlayTimeSpan;
        }

        public static string ApiPort { get; set; }
        public static string ApiIpAddress { get; set; }
        public static int DailyPlayTimeSpan { get; set; }
    }
}
