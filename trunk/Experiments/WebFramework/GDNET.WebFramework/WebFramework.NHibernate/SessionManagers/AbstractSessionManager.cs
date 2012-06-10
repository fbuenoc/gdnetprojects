using System.IO;
using System.Linq;
using System.Reflection;
using GDNET.Extensions;
using GDNET.NHibernate.SessionManagers;
using NHibernate;
using NHibernate.Mapping.ByCode;
using WebFramework.Base.Mapping;

namespace WebFramework.NHibernate.SessionManagers
{
    public abstract class AbstractSessionManager : SessionManager
    {
        protected static ISessionFactory TheSessionFactory;

        protected static ModelMapper BuildModelMapper(string mappingAssembliesFile)
        {
            var mapper = new ModelMapper();
            if (File.Exists(mappingAssembliesFile))
            {
                foreach (string line in File.ReadAllLines(mappingAssembliesFile).Where(x => ValidatedLine(x)))
                {
                    var asm = Assembly.Load(line);
                    var listeMappingTypes = ReflectionAssistant.GetTypesImplementedInterfaceOnAssembly(typeof(INHibernateMapping), asm);
                    mapper.AddMappings(listeMappingTypes);
                }
            }

            return mapper;
        }

        private static bool ValidatedLine(string line)
        {
            return !(string.IsNullOrEmpty(line) || line.StartsWith("#"));
        }
    }
}
