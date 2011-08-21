using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;

using GDNET.Common.DesignByContract;

namespace GDNET.Extensions.NHibernateImpl
{
    public static class SessionFactoryManager
    {
        /// <summary>
        /// The file contains configuration information.
        /// </summary>
        private const string HibernateCfgFile = "hibernate.cfg.xml";

        public static ISessionFactory BuildSessionFactory(HbmMapping mappings)
        {
            return BuildSessionFactory(mappings, HibernateCfgFile);
        }

        public static ISessionFactory BuildSessionFactory(HbmMapping mappings, string cfgFile)
        {
            Throw.ArgumentNullException(mappings, "mappings", "You must build mapping before build session factory.");
            Throw.FileNotFoundException(cfgFile, "The file must be exists.");

            try
            {
                // Initializes configuration
                Configuration config = new Configuration();
                config.Configure(cfgFile);
                config.AddDeserializedMapping(mappings, string.Empty);

                return config.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
