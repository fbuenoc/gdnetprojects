using GDNET.Extensions;
using GDNET.NHibernate.SessionManagers;
using NHibernate;
using NHibernate.Mapping.ByCode;
using WebFrameworkMapping.Base;

namespace WebFrameworkNHibernate.SessionManagers
{
    public abstract class AbstractSessionManager : SessionManager
    {
        protected static ISessionFactory TheSessionFactory;

        protected static ModelMapper BuildModelMapper()
        {
            var listeMappingTypes = ReflectionAssistant.GetTypesImplementedInterfaceOnAssembly(typeof(INHibernateMapping), typeof(INHibernateMapping).Assembly);

            var mapper = new ModelMapper();
            mapper.AddMappings(listeMappingTypes);

            return mapper;
        }
    }
}
