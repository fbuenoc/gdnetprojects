using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using GDNET.NHibernate.Mapping;
using GDNET.NHibernate.SessionManagement;
using GDNET.Utils;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace GDNET.Data.Base
{
    public class DataSessionManager : AbstractSessionManager
    {
        private static readonly string HibernateConfiguration = HostingEnvironment.MapPath("~/App_Data/hibernate.cfg.xml");
        private static readonly string MappingAssemblies = HostingEnvironment.MapPath("~/App_Data/MappingAssemblies.txt");

        #region Singleton

        private DataSessionManager() { }

        private class Nested
        {
            public static readonly DataSessionManager instance = new DataSessionManager();
        }

        public new static DataSessionManager Instance
        {
            get { return Nested.instance; }
        }

        #endregion

        protected override Hashtable ContextSessions
        {
            get
            {
                if (HttpContext.Current.Items[ContextSessionsKey] == null)
                {
                    HttpContext.Current.Items[ContextSessionsKey] = new Hashtable();
                }
                return (Hashtable)HttpContext.Current.Items[ContextSessionsKey];
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
