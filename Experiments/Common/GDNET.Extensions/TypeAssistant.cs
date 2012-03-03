using System;

namespace GDNET.Extensions
{
    public static class TypeAssistant
    {
        public static string GetQualifiedTypeName(this Type aType)
        {
            int firstIndex = aType.AssemblyQualifiedName.IndexOf(",") + 1;
            return aType.AssemblyQualifiedName.Substring(0, aType.AssemblyQualifiedName.IndexOf(",", firstIndex));
        }
    }
}
