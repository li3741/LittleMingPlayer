using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace LittleMingPlayService
{
    public class ConfigHelper
    {
        public static void InitConfig()
        {
            var player = PlayerHelper.Inst();
            var playsection = (PlayerConfigure)ConfigurationManager.GetSection("PlayerSettings");
            MyConfigure = playsection;
            try
            {
                if (!string.IsNullOrEmpty(MyConfigure.FilesFolder))
                {
                    if (System.IO.Directory.Exists(MyConfigure.FilesFolder))
                    {
                        PlayerHelper.Inst().PlayList.AddRange(System.IO.Directory.GetFiles(MyConfigure.FilesFolder, MyConfigure.FileFormat, System.IO.SearchOption.AllDirectories));
                    }
                }
            }
            catch (Exception er)
            {
                using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "webapierror.txt", true))
                {
                    writer.WriteLine(er.StackTrace);
                    writer.Flush();
                }
            }
        }
        public static PlayerConfigure MyConfigure;
        //public static string ApiPort { get; set; }
        public static string ApiIpAddress { get; set; }
        //public static int DailyPlayTimeSpan { get; set; }
    }

    public class PlayerConfigure : ConfigurationSection
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
        [ConfigurationProperty("dailyPlayTime", DefaultValue = "12,30,13,30", IsRequired = true)]
        public string DailyPlayTime
        {
            get
            {
                return (string)this["dailyPlayTime"];
            }
            set
            {
                this["dailyPlayTime"] = value;
            }
        }
        [ConfigurationProperty("filesFolder", DefaultValue = "C:\\")]
        public string FilesFolder
        {
            get
            {
                return (string)this["filesFolder"];
            }
            set
            {
                this["filesFolder"] = value;
            }
        }
        [ConfigurationProperty("fileFormat", DefaultValue = "*.mp3")]
        public string FileFormat
        {
            get
            {
                return (string)this["fileFormat"];
            }
            set
            {
                this["fileFormat"] = value;
            }
        }
        [ConfigurationProperty("apiport", DefaultValue = "9898")]
        public string ApiPort
        {
            get
            {
                return (string)this["apiport"];
            }
            set
            {
                this["apiport"] = value;
            }
        }
        [ConfigurationProperty("dailyPlayTimeSpan", DefaultValue = "1")]
        public int dailyPlayTimeSpan
        {
            get
            {
                return (int)this["dailyPlayTimeSpan"];
            }
            set
            {
                this["dailyPlayTimeSpan"] = value;
            }
        }
    }
}
