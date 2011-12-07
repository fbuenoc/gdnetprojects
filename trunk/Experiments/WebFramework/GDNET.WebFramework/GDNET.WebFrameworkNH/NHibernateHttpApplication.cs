using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

using GDNET.NHibernateImpl.Utils;
using GDNET.Web.MultilingualControls;

using WebFrameworkMapping.Common;

namespace WebFrameworkNHibernate
{
    public abstract class NHibernateHttpApplication : HttpApplication
    {
        private static ISessionFactory _sessionFactory = null;

        static NHibernateHttpApplication()
        {
            NHibernateHttpApplication.BuildSessionFactory();
        }

        #region Properties

        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }

        public static ISession GetCurrentSession()
        {
            return _sessionFactory.GetCurrentSession();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Build NHibernate session factory
        /// </summary>
        private static void BuildSessionFactory()
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(new Type[] { 
                typeof(ContentAttributeMap), typeof(ContentItemMap), typeof(ContentItemAttributeValueMap), typeof(ContentTypeMap), 
                typeof(ApplicationMap), typeof(CultureMap), typeof(ListValueMap), typeof(TemporaryMap), typeof(TranslationMap) 
            });

            var nhConfigPath = HostingEnvironment.MapPath("~/App_Data/hibernate.cfg.xml");
            SessionFactoryHelper.BuildSessionFactory(nhConfigPath, mapper, out _sessionFactory);
        }

        #endregion

    }
}
