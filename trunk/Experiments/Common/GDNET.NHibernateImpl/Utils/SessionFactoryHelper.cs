using System;
using System.IO;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Event;
using NHibernate.Mapping.ByCode;

using GDNET.NHibernateImpl.Listeners;

namespace GDNET.NHibernateImpl.Utils
{
    public static class SessionFactoryHelper
    {
        private static ISaveOrUpdateEventListener[] _listeners;

        public static void SetListeners(ISaveOrUpdateEventListener[] listeners)
        {
            _listeners = listeners;
        }

        public static void BuildSessionFactory(string nhConfigPath, ModelMapper mapper, out ISessionFactory sessionFactory)
        {
            var configuration = new Configuration();
            if (File.Exists(nhConfigPath))
            {
                configuration.Configure(nhConfigPath);
            }
            if (_listeners != null)
            {
                configuration.EventListeners.SaveOrUpdateEventListeners = _listeners;
            }

            configuration.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), string.Empty);

            sessionFactory = configuration.BuildSessionFactory();
        }
    }
}
