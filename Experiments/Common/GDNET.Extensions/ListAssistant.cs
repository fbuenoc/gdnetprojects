using System.Collections.Generic;

namespace GDNET.Extensions
{
    public static class ListAssistant
    {
        public static void AddRange<T>(this List<T> theList, params T[] elements)
        {
            theList.AddRange(elements);
        }

        public static List<T> Empty<T>()
        {
            return new List<T>();
        }
    }
}
