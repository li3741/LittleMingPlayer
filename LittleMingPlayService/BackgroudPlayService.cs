using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Configuration;

namespace LittleMingPlayService
{
    partial class BackgroudPlayService : ServiceBase
    {
        public BackgroudPlayService()
        {
            InitializeComponent();
        }
        IDisposable service = null;
        protected override void OnStart(string[] args)
        {

            // TODO: Add code here to start your service.
            //try
            //{
            ConfigHelper.InitConfig();
            service = HostingHelper.InitHosting();
           
            //}
            //catch (Exception er)
            //{
            //    using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "webapierror.txt", true))
            //    {
            //        writer.WriteLine(er.StackTrace);
            //        writer.Flush();
            //    }
            //}
        }

        protected override void OnPause()
        {
            base.OnPause();
        }
        protected override void OnContinue()
        {
            base.OnContinue();
        }

        protected override void OnStop()
        {
            if (service != null)
                service.Dispose();
            PlayerHelper.Inst().Dispose();
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
