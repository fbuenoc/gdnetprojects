using System;

namespace GDNET.Extensions
{
    public static class EnumAssistant
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
