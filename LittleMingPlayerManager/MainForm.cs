using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleMingPlayerManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            string times = picTime.Value.ToString("HH:mm:")+txtPlayTime.Text;
            if (!cboTimeList.Items.Contains(times))
                cboTimeList.Items.Add(times);
        }

        private void btnDeleteTime_Click(object sender, EventArgs e)
        {
            if (cboTimeList.SelectedItem == null) return;
            if (cboTimeList.Items.Contains(cboTimeList.SelectedItem))
            {
                cboTimeList.Items.Remove(cboTimeList.SelectedItem);
            }
        }

        private void btnSelectFloder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowNewFolderButton = true;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtFloder.Text = folderBrowser.SelectedPath;
            }
        }

        string serviceName = "LittleMingPlayer";
        string configFileName = "LittleMingPlayService.exe";
        bool Install(bool isInstall)
        {
            try
            {
                TransactedInstaller installer = new TransactedInstaller();
                installer.Installers.Add(new ServiceProcessInstaller
                {
                    Account = ServiceAccount.LocalSystem
                });
                installer.Installers.Add(new ServiceInstaller
                {
                    DisplayName = "小明后台播放器",
                    ServiceName = serviceName,
                    Description = "小明后台播放器",
                    StartType = ServiceStartMode.Automatic,
                });
                installer.Context = new InstallContext();
                installer.Context.Parameters["assemblypath"] = AppDomain.CurrentDomain.BaseDirectory + "LittleMingPlayService.exe";
                if (isInstall)
                {
                    installer.Install(new Hashtable());
                }
                else
                {
                    installer.Uninstall(null);
                }
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

        private void btnServiceState_Click(object sender, EventArgs e)
        {
            if (btnServiceState.Text == "未安装")
            {
                if (Install(true))
                {

                }
            }
            else if (btnServiceState.Text == "已经停止")
            {
                RestartService();
            }
            CheckServiceState();
        }

        void CheckServiceState()
        {
            var ser = GetService(serviceName);
            if (ser == null)
            {
                btnServiceState.Text = "未安装";
            }
            else
            {
                switch (ser.Status)
                {
                    case ServiceControllerStatus.Running: btnServiceState.Text = "运行中。。。"; break;
                    case ServiceControllerStatus.Stopped: btnServiceState.Text = "已经停止"; break;
                    case ServiceControllerStatus.Paused: btnServiceState.Text = "已经暂停"; break;
                    default:
                        btnServiceState.Text = "状态改变中。。。稍等！";
                        break;
                }
            }
        }

        bool isExistService(string serviceName)
        {
            var ser = GetService(serviceName);
            return ser != null;
        }

        ServiceController GetService(string serviceName)
        {
            ServiceController[] service = ServiceController.GetServices();
            var ser = service.Where(p => p.ServiceName == serviceName).FirstOrDefault();
            return ser;
        }

        private void btnUnstall_Click(object sender, EventArgs e)
        {
            if (isExistService(serviceName))
            {
                Install(false);
                CheckServiceState();
            }
            else
            {
                MessageBox.Show("服务未安装，无需卸载！");
            }
        }


        private void Configure()
        {
            ConfigurationSaveMode saveMode;
            string configFile = AppDomain.CurrentDomain.BaseDirectory + configFileName;
            if (!System.IO.File.Exists(configFile))
            {
                saveMode = ConfigurationSaveMode.Modified;
            }
            else
            {
                saveMode = ConfigurationSaveMode.Full;
            }


            //System.Configuration.Configuration config =
            //               ConfigurationManager.OpenExeConfiguration(configFile);


            //      ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            //      fileMap.ExeConfigFilename = configFileName;



            //      config = ConfigurationManager.OpenMappedExeConfiguration(
            //fileMap, ConfigurationUserLevel.None);

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(configFileName);
            var playerSettings = (LittleMingPlayService.PlayerConfigure)config.GetSection("PlayerSettings");
            if (playerSettings == null)
            {
                playerSettings = new LittleMingPlayService.PlayerConfigure();
                config.Sections.Add("PlayerSettings", playerSettings);
            }

            playerSettings.dailyPlayTimeSpan = Convert.ToInt32(txtPlayTime.Text);
            playerSettings.ApiPort = txtPort.Text;
            playerSettings.FileFormat = txtFileFormat.Text;
            playerSettings.FilesFolder = txtFloder.Text;
            playerSettings.Name = configFileName;
            playerSettings.DailyPlayTime = GetDailyPlayTimes();

            config.Save(saveMode);
            //MessageBox.Show(config.AppSettings.Settings["dailyPlayTime"].Value);
            //var section = config.GetSection("appSettings");
            //if (section == null)
            //{
            //    config.Sections.Add("appSettings", new AppSettingsSection());
            //    section = config.GetSection("appSettings");
            //}
            //else
            //{

            //}
            //section = config.GetSection("appSettings");
            //MessageBox.Show(section.ToString());
            //config.SaveAs(configFileName, ConfigurationSaveMode.Modified);
        }

        private void LoadConfing()
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(configFileName);
            var playerSettings = (LittleMingPlayService.PlayerConfigure)config.GetSection("PlayerSettings");
            if (playerSettings == null)
            {
                MessageBox.Show("找不到默认的配置文件！需要配置好路径！");
                return;
            }
            txtPlayTime.Text = playerSettings.dailyPlayTimeSpan.ToString();
            txtPort.Text = playerSettings.ApiPort;
            txtFileFormat.Text = playerSettings.FileFormat;
            txtFloder.Text = playerSettings.FilesFolder;
            var times = playerSettings.DailyPlayTime.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (times == null || times.Length % 3 != 0)
            {
                MessageBox.Show("加载播放时间失败！请重新配置！");
            }
            else
            {
                for (int i = 0; i < times.Length; i += 3)
                {
                    cboTimeList.Items.Add(times[i] + ":" + times[i + 1] + ":" + times[i + 2]);
                }
            }
        }

        private string GetDailyPlayTimes()
        {
            if (cboTimeList.Items.Count <= 0)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in cboTimeList.Items)
            {
                if (sb.Length > 0)
                {
                    sb.Append(",");
                }
                sb.Append(item.ToString().Replace(":", ","));
            }
            return sb.ToString();
        }

        private void btnSaveConfigure_Click(object sender, EventArgs e)
        {
            Configure();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            initConfig();
        }

        private void initConfig()
        {
            LoadConfing();
            CheckServiceState();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            Configure();
            if (isExistService(serviceName))
            {
                RestartService();
            }
            else
            {
                Install(true);
            }
            CheckServiceState();
        }

        private void RestartService()
        {
            var ser = GetService(serviceName);
            if (ser != null)
            {
                try
                {
                    if (ser.Status != ServiceControllerStatus.Stopped)
                    {
                        if (ser.CanStop)
                            ser.Stop();
                    }

                    ser.Start();
                }
                catch (Exception er)
                {
                    MessageBox.Show("停止服务失败,请稍等!");
                    CheckServiceState();
                }
            }
            else
            {
                MessageBox.Show("服务未安装!");
            }
        }
    }
}
