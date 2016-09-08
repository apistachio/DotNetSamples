using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Reflection;
using System.IO;
using System.Net;


namespace WSvc
{
    public class Svc : ServiceBase
    {
        public static string Name = "A_General_Service";
        public static string Description = "Service Description";
        public ServiceHost serviceHost = null;

        public Svc()
        {
            ServiceName = Name;
        }
        public static void Main()
        {
            ServiceBase.Run(new Svc());
        }
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            serviceHost = new ServiceHost(typeof(GEN));
            serviceHost.Open();
        }
        protected override void OnStop()
        {
            base.OnStop();
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceInstaller service;
        private ServiceProcessInstaller process;

        private ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalService;
            service = new ServiceInstaller();
            service.ServiceName = Svc.Name;
            service.Description = Svc.Description;
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
