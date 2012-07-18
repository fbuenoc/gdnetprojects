using System.Collections;
using System.Web;
using System.Web.Hosting;

namespace GDNET.NHibernate.SessionManagement
{
    public class WebNHibernateSessionManager : ApplicationNHibernateSessionManager
    {
        #region Singleton

        private WebNHibernateSessionManager()
        {
            HibernateConfiguration = HostingEnvironment.MapPath("~/App_Data/hibernate.cfg.xml");
            MappingAssemblies = HostingEnvironment.MapPath("~/App_Data/MappingAssemblies.txt");
        }

        private class Nested
        {
            public static readonly WebNHibernateSessionManager instance = new WebNHibernateSessionManager();
        }

        public new static WebNHibernateSessionManager Instance
        {
            get { return Nested.instance; }
        }

        #endregion

        protected override Hashtable ContextSessions
        {
            get
            {
                if (HttpContext.Current.Items[ContextSessionsKey] == null)
                {
                    HttpContext.Current.Items[ContextSessionsKey] = new Hashtable();
                }
                return (Hashtable)HttpContext.Current.Items[ContextSessionsKey];
            }
        }
    }
}
