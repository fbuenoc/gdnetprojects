using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

using NHibernate;
using NHibernate.Context;
using NHibernate.Event;
using NHibernate.Mapping.ByCode;

using GDNET.NHibernateImpl.Utils;

using WebFrameworkData.Common.Listeners;
using WebFrameworkDomain;
using WebFrameworkDomain.DefaultImpl;
using WebFrameworkMapping.Common;

namespace WebFrameworkData.UnitTest
{
    public abstract class NUnitBase
    {
        private static ISessionFactory _sessionFactory = null;
        private static DomainRepositories _testRepositories = null;
        private static ISession _currentSession = null;
        private static TestSessionService _sessionService = null;

        public void Init()
        {
            NUnitBase.BuildSessionFactory();

            if (_testRepositories == null)
            {
                _testRepositories = new TestRepositories();
            }
            if (_sessionService == null)
            {
                _sessionService = new TestSessionService();
            }
        }

        /// <summary>
        /// Need to delete all data
        /// </summary>
        public void Clean()
        {
            if (_currentSession != null)
            {
                using (_currentSession)
                {
                    _currentSession.Close();
                }
                _currentSession = null;
            }

            if (_sessionFactory != null)
            {
                using (_sessionFactory)
                {
                    _sessionFactory.Close();
                }
                _sessionFactory = null;
            }
        }

        /// <summary>
        /// Build NHibernate session factory
        /// </summary>
        private static void BuildSessionFactory()
        {
            if (_sessionFactory != null)
            {
                return;
            }

            var mapper = new ModelMapper();
            mapper.AddMappings(new Type[] { 
                typeof(ContentAttributeMap), typeof(ContentItemMap), typeof(ContentItemAttributeValueMap), typeof(ContentTypeMap), 
                typeof(ApplicationMap), typeof(CultureMap), typeof(ListValueMap), typeof(TemporaryMap), typeof(TranslationMap) 
            });

            var hbmMapping = mapper.CompileMappingForAllExplicitlyAddedEntities().AsString();
            Debug.WriteLine(hbmMapping);

            var nhConfigPath = "App_Data/hibernate.cfg.xml";

            //SessionFactoryHelper.SetListeners(new ISaveOrUpdateEventListener[] { new WebFrameworkSaveEventListener() });
            SessionFactoryHelper.BuildSessionFactory(nhConfigPath, mapper, out _sessionFactory);
        }

        public static ISession GetCurrentSession()
        {
            if (_currentSession == null || !_currentSession.IsOpen)
            {
                _currentSession = _sessionFactory.OpenSession();
            }
            return _currentSession;
        }
    }
}
