using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using GDNET.NHibernate.Mapping;
using GDNET.Utils;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace GDNET.NHibernate.SessionManagement
{
    public class ApplicationNHibernateSessionManager : AbstractNHibernateSessionManager
    {
        protected static string HibernateConfiguration;
        protected static string MappingAssemblies;

        #region Singleton

        protected ApplicationNHibernateSessionManager()
        {
            HibernateConfiguration = Path.Combine(System.Environment.CurrentDirectory, "/App_Data/hibernate.cfg.xml");
            MappingAssemblies = Path.Combine(System.Environment.CurrentDirectory, "/App_Data/MappingAssemblies.txt");
        }

        private class Nested
        {
            public static readonly ApplicationNHibernateSessionManager instance = new ApplicationNHibernateSessionManager();
        }

        public new static ApplicationNHibernateSessionManager Instance
        {
            get { return Nested.instance; }
        }

        #endregion

        protected override Hashtable ContextSessions
        {
            get
            {
                if (CallContext.GetData(ContextSessionsKey) == null)
                {
                    CallContext.SetData(ContextSessionsKey, new Hashtable());
                }

                return (Hashtable)CallContext.GetData(ContextSessionsKey);
            }
        }

        protected override ISessionFactory BuildSessionFactory(params IInterceptor[] interceptors)
        {
            var mapper = this.BuildModelMapper(MappingAssemblies);
            base.Configuration = new Configuration();

            if (File.Exists(HibernateConfiguration))
            {
                base.Configuration.Configure(HibernateConfiguration);
            }

            if (mapper != null)
            {
                base.Configuration.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), string.Empty);
            }

            foreach (var interceptor in interceptors)
            {
                base.Configuration.SetInterceptor(interceptor);
            }

            return base.Configuration.BuildSessionFactory();
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
