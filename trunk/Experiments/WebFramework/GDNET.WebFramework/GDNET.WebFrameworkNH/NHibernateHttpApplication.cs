using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;

using NHibernate;
using NHibernate.Cfg;

namespace GDNET.WebFrameworkNH
{
    public abstract class NHibernateHttpApplication : HttpApplication
    {
        private static readonly Configuration _configuration = null;
        private static readonly ISessionFactory _sessionFactory = null;

        public static Configuration Configuration
        {
            get { return _configuration; }
        }

        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }

        static NHibernateHttpApplication()
        {
            _configuration = new Configuration();
            _configuration.AddDirectory(new DirectoryInfo(HostingEnvironment.MapPath("~/App_Data/")));

            string nhConfigPath = HostingEnvironment.MapPath("~/App_Data/hibernate.cfg.xml");
            if (File.Exists(nhConfigPath))
            {
                _configuration.Configure(nhConfigPath);
            }

            _sessionFactory = _configuration.BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            return _sessionFactory.GetCurrentSession();
        }
    }
}
