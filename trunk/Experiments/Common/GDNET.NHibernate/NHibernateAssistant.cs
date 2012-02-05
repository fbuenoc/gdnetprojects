using System.IO;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace GDNET.NHibernate
{
    public static class NHibernateAssistant
    {
        /// <summary>
        /// Build session factory with default settings.
        /// </summary>
        /// <returns></returns>
        public static ISessionFactory BuildSessionFactory()
        {
            return NHibernateAssistant.BuildSessionFactory(string.Empty, null);
        }

        /// <summary>
        /// Build session factory with a configuration file.
        /// </summary>
        /// <param name="nhConfigPath"></param>
        /// <returns></returns>
        public static ISessionFactory BuildSessionFactory(string nhConfigPath)
        {
            return NHibernateAssistant.BuildSessionFactory(nhConfigPath, null);
        }

        /// <summary>
        /// Build session factory with a configuration file and mapper model which contains all mapping classes.
        /// </summary>
        /// <param name="nhConfigPath"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public static ISessionFactory BuildSessionFactory(string nhConfigPath, ModelMapper mapper)
        {
            Configuration cfg = new Configuration();

            if (File.Exists(nhConfigPath))
            {
                cfg.Configure(nhConfigPath);
            }

            if (mapper != null)
            {
                cfg.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), string.Empty);
            }

            return cfg.BuildSessionFactory();
        }
    }
}
