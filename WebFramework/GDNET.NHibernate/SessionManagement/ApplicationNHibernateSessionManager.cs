using System.IO;
using System.Linq;
using System.Reflection;
using GDNET.NHibernate.Interceptors;
using GDNET.NHibernate.Mapping;
using GDNET.Utils;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Mapping.ByCode;

namespace GDNET.NHibernate.SessionManagement
{
    public class ApplicationNHibernateSessionManager : AbstractNHibernateSessionManager, INHibernateSessionManager
    {
        protected string hibernateConfiguration;
        protected string mappingAssemblies;

        private const string DefaultHibernateConfigurationFile = "App_Data/hibernate.cfg.xml";
        private const string DefaultMappingAssembliesFile = "App_Data/MappingAssemblies.txt";

        #region Singleton

        private class Nested
        {
            public static readonly ApplicationNHibernateSessionManager instance = new ApplicationNHibernateSessionManager();
        }

        public new static ApplicationNHibernateSessionManager Instance
        {
            get { return Nested.instance; }
        }

        #endregion

        private ApplicationNHibernateSessionManager()
            : this(string.Empty, string.Empty)
        {
        }

        protected ApplicationNHibernateSessionManager(string hibernateConfigurationFile, string mappingAssembliesFile)
        {
            if (string.IsNullOrEmpty(hibernateConfigurationFile))
            {
                hibernateConfigurationFile = DefaultHibernateConfigurationFile;
            }
            if (string.IsNullOrEmpty(mappingAssembliesFile))
            {
                mappingAssembliesFile = DefaultMappingAssembliesFile;
            }

            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            hibernateConfiguration = Path.Combine(directory, hibernateConfigurationFile);
            mappingAssemblies = Path.Combine(directory, mappingAssembliesFile);

            this.BuildSessionFactory();
        }

        protected virtual void BuildSessionFactory()
        {
            this.BuildConfiguration(new EntityWithModificationInterceptor());
            _sessionFactory = base.Configuration.CurrentSessionContext<ThreadStaticSessionContext>().BuildSessionFactory();
        }

        protected virtual void BuildConfiguration(params IInterceptor[] interceptors)
        {
            var mapper = this.BuildModelMapper(mappingAssemblies);
            base.Configuration = new Configuration();

            if (File.Exists(hibernateConfiguration))
            {
                base.Configuration.Configure(hibernateConfiguration);
            }

            if (mapper != null)
            {
                base.Configuration.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), string.Empty);
            }

            foreach (var interceptor in interceptors)
            {
                base.Configuration.SetInterceptor(interceptor);
            }
        }

        private ModelMapper BuildModelMapper(string mappingAssembliesFile)
        {
            var mapper = new ModelMapper();
            if (File.Exists(mappingAssembliesFile))
            {
                foreach (string line in File.ReadAllLines(mappingAssembliesFile).Where(x => this.ValidatedLine(x)))
                {
                    var asm = Assembly.Load(line);
                    var listeMappingTypes = ReflectionAssistant.GetTypesImplementedInterfaceOnAssembly(typeof(IEntityMapping), asm);
                    mapper.AddMappings(listeMappingTypes);
                }
            }

            return mapper;
        }

        private bool ValidatedLine(string line)
        {
            return !(string.IsNullOrEmpty(line) || line.StartsWith("#"));
        }
    }
}
