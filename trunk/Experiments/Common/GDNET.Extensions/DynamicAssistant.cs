using System.Collections.Generic;
using System.Reflection;

namespace GDNET.Extensions
{
    public static class DynamicAssistant
    {
        public static object Merge(object object1, object object2)
        {
            Dictionary<string, object> members = new Dictionary<string, object>();

            foreach (PropertyInfo fi in object1.GetType().GetProperties())
            {
                members[fi.Name] = fi.GetValue(object1, null);
            }
            foreach (PropertyInfo fi in object2.GetType().GetProperties())
            {
                members[fi.Name] = fi.GetValue(object2, null);
            }

            return members;
        }
    }
}
