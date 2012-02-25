using WebFrameworkNHibernate;
using System;
using System.Web.Routing;

namespace WebFramework
{
    public class Global : NHibernateHttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            this.RegisterRoutes(RouteTable.Routes);
        }

        public void RegisterRoutes(RouteCollection routes)
        {
        }
    }
}
