using System;
using System.Collections.Generic;
using System.Reflection;

namespace GDNET.Common.Utils
{
    public static class ReflectionUtil
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
    }
}
