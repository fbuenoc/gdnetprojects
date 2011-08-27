using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

using GDNET.Extensions.NHibernateImpl;
using GoogleCode.Data.Mapping;
using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace GoogleCodeWebApp
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// The file contains configuration information.
        /// </summary>
        private const string DefaultCfgFile = "hibernate.cfg.xml";

        protected void Application_Start(object sender, EventArgs e)
        {
            string cfgFile = base.Server.MapPath(string.Format("~/App_Data/{0}", DefaultCfgFile));
            NHSessionManager.Initialize(MappingUtil.GetHbmMapping(), cfgFile);
            NHibernateProfiler.Initialize();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            NHSessionManager.Release();
        }
    }
}