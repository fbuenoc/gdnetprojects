using System.Collections.Generic;
using System.Linq;

namespace GDNET.Extensions
{
    public static class DictionaryAssistant
    {
        public static IDictionary<object, object> BuildDictionary(params object[] keyValuePairs)
        {
            Dictionary<object, object> results = new Dictionary<object, object>();

            for (int index = 0; index < keyValuePairs.Count(); index += 2)
            {
                results.Add(keyValuePairs[index], keyValuePairs[index + 1]);
            }

            return results;
        }
    }
}
