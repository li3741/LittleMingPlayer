using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace LittleMingPlayService
{
    public class HostingHelper
    {
        /// <summary>
        /// 开始用owin做容器提供web api
        /// </summary>
        public static IDisposable InitHosting()
        {
            IDisposable service = null;
            StartOptions options = new StartOptions();
            options.Urls.Add("http://localhost:" + ConfigHelper.MyConfigure.ApiPort);
            options.Urls.Add("http://127.0.0.1:" + ConfigHelper.MyConfigure.ApiPort);
            options.Urls.Add(string.Format("http://{0}:" + ConfigHelper.MyConfigure.ApiPort, Environment.MachineName));
            ConfigHelper.ApiIpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            options.Urls.Add(string.Format("http://{0}:" + ConfigHelper.MyConfigure.ApiPort, ConfigHelper.ApiIpAddress));
            service = WebApp.Start<StartUp>(options);
            return service;
        }
    }

    public class StartUp
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }

    }

}
