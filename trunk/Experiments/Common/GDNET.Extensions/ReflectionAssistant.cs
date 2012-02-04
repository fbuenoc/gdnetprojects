using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GDNET.Extensions
{
    public static class ReflectionAssistant
    {
        public static IDictionary<string, Type> GetProperties(Type type)
        {
            Dictionary<string, Type> infos = new Dictionary<string, Type>();
            foreach (PropertyInfo pi in type.GetProperties())
            {
                infos.Add(pi.Name, pi.PropertyType);
            }
            return infos;
        }

        public static IList<Type> GetTypesImplementedInterface(Type interfaceType, Assembly assembly)
        {
            List<Type> listOfTypes = new List<Type>();
            if ((interfaceType != null) && (assembly != null))
            {
                listOfTypes.AddRange(assembly.GetTypes().Where(x => x.GetInterface(interfaceType.Name) != null));
            }
            return listOfTypes;
        }
    }
}
