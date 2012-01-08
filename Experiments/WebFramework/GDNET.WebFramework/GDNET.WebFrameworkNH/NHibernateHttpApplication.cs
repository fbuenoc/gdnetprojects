using System;
using System.Web;
using System.Web.Hosting;
using GDNET.NHibernateImpl.Utils;
using NHibernate;
using NHibernate.Mapping.ByCode;
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
