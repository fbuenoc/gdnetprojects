using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace GDNET.NHibernateImpl.Utils
{
    public static class SessionFactoryHelper
    {
        public static void BuildSessionFactory(string nhConfigPath, ModelMapper mapper, out ISessionFactory sessionFactory)
        {
            var configuration = new Configuration();
            if (File.Exists(nhConfigPath))
            {
                configuration.Configure(nhConfigPath);
            }

            configuration.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), string.Empty);

            sessionFactory = configuration.BuildSessionFactory();
        }
    }
}
