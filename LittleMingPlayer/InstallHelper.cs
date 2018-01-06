using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace LittleMingPlayer
{
    public class InstallHelper
    {
        public static void InstallServce()
        {
            using (Installer installer = new ProjectInstaller())
            {
                Hashtable dictionary = new Hashtable();
                installer.Install(dictionary);
            }
        }

        public static void UninstallServce()
        {
            using (ProjectInstaller installer = new ProjectInstaller())
            {
                IDictionary dictionary = new Hashtable();
                installer.Uninstall(dictionary);
            }

        }
        public static string Install(string filePath, string serviceName)
        {
            string msg = string.Empty;
            string[] args = { filePath };
            try
            {
                ServiceController svc = new ServiceController();
                if (!IsExistsService(serviceName))
                {
                    System.Configuration.Install.ManagedInstallerClass.InstallHelper(args);
                    msg = "安装服务" + serviceName + "成功！";
                }
            }
            catch (Exception er)
            {
                msg = er.ToString();
            }
            return msg;
        }
        public static string Uninstall(string filePath, string serviceName)
        {
            string msg = string.Empty;
            try
            {
                System.Configuration.Install.AssemblyInstaller myAssemblyInstaller = new System.Configuration.Install.AssemblyInstaller();
                myAssemblyInstaller.UseNewContext = true;
                myAssemblyInstaller.Path = filePath;
                myAssemblyInstaller.Uninstall(null);
                myAssemblyInstaller.Dispose();
                msg = "卸载服务" + serviceName + "成功！";
            }
            catch (Exception er)
            {
                msg = er.ToString();
            }
            return msg;
        }

        public static bool IsExistsService(string serviceName)
        {
            var services = ServiceController.GetServices();
            return services.FirstOrDefault(p => p.ServiceName == serviceName) != null;
        }

        public static string GetServiceState(string serviceName)
        {
            var services = ServiceController.GetServices();
            var theService = services.FirstOrDefault(p => p.ServiceName == serviceName);
            if (theService != null)
            {
                return theService.Status.ToString();
            }
            else
            {
                return "服务不存在！";
            }
        }
    }
}
