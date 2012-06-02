using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;

namespace GDNET.Extensions
{
    public static class AnonymousObjectAssistant
    {
        public static object FromDictionary(IDictionary<string, object> dict)
        {
            ExpandoObject objet = new ExpandoObject();
            foreach (var kvp in dict)
            {
                ((IDictionary<string, object>)objet).Add(kvp.Key, kvp.Value);
            }

            return (object)objet;
        }

        public static object FromCollection(NameValueCollection collection)
        {
            ExpandoObject objet = new ExpandoObject();
            foreach (var keyObject in collection.Keys)
            {
                if (keyObject != null)
                {
                    string key = keyObject.ToString();
                    ((IDictionary<string, object>)objet).Add(key, collection[key]);
                }
            }
            return (object)objet;
        }
    }
}
