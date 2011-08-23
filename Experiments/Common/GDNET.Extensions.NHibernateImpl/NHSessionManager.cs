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
    public static class NHSessionManager
    {
        /// <summary>
        /// The file contains configuration information.
        /// </summary>
        private const string DefaultCfgFile = "hibernate.cfg.xml";

        private static bool _isInitialized = false;
        private static ISessionFactory _sessionFactory = null;
        private static HbmMapping _mappings = null;
        private static string _cfgFile = null;

        /// <summary>
        /// Provides information to initialize session manager.
        /// </summary>
        public static void Initialize(HbmMapping mappings)
        {
            Initialize(mappings, DefaultCfgFile);
        }

        /// <summary>
        /// Provides information to initialize session manager.
        /// </summary>
        public static void Initialize(HbmMapping mappings, string cfgFile)
        {
            Throw.ArgumentNullException(mappings, "mappings", "You must build mapping before build session factory.");
            Throw.FileNotFoundException(cfgFile, "The file must be exists.");

            _mappings = mappings;
            _cfgFile = cfgFile;
            _isInitialized = true;
        }

        /// <summary>
        /// Releases resources.
        /// </summary>
        public static void Release()
        {
            if (_sessionFactory != null)
            {
                if (!_sessionFactory.IsClosed)
                {
                    _sessionFactory.Close();
                }

                _sessionFactory.Dispose();
                _sessionFactory = null;
            }

            _isInitialized = false;
        }

        /// <summary>
        /// Opens a NHibernate session. If session factory is invalid in any case, it will build a brand new one.
        /// </summary>
        /// <returns></returns>
        public static ISession OpenSession()
        {
            AutoBuildSessionFactory();

            // From now, session factory is built and ready to use.
            return _sessionFactory.OpenSession();
        }

        /// <summary>
        /// Build session factory from mapping information.
        /// </summary>
        private static void AutoBuildSessionFactory()
        {
            Throw.InvalidOperationExceptionIfFalse(_isInitialized, "Session manager is not initialized.");

            try
            {
                if ((_sessionFactory != null) && _sessionFactory.IsClosed)
                {
                    _sessionFactory.Dispose();
                    _sessionFactory = null;
                }

                if (_sessionFactory == null)
                {
                    // Initializes configuration
                    Configuration config = new Configuration();
                    config.Configure(_cfgFile);
                    config.AddDeserializedMapping(_mappings, string.Empty);

                    _sessionFactory = config.BuildSessionFactory();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
