using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GDNET.Web.Mvc.Helpers
{
    public static class FormCollectionAssistant
    {
        public static TId GetItemId<TId>(this FormCollection collection)
        {
            if (typeof(TId) == typeof(int) || typeof(TId) == typeof(long))
            {
                long itemId = long.Parse(collection[MvcConstants.FormItemId]);
                return (TId)Convert.ChangeType(itemId, typeof(TId));
            }

            return default(TId);
        }

        public static Dictionary<string, string> ToDictionary(this FormCollection collection)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();

            foreach (var key in collection.AllKeys)
            {
                results.Add(key, collection[key]);
            }

            return results;
        }

        /// <summary>
        /// Get values from a collection, only apply with the key in collection that start with given value.
        /// </summary>
        public static Dictionary<string, string> GetValuesFromCollection(this FormCollection collection, string keyStartWith)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            if (collection != null)
            {
                foreach (string key in collection.Keys)
                {
                    if (key.StartsWith(keyStartWith))
                    {
                        results.Add(key.Substring(keyStartWith.Length), collection[key]);
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Get value from a collection, only apply with the key in collection that start with given value.
        /// </summary>
        public static string GetValueFromCollection(this FormCollection collection, string variableName)
        {
            string localResult = string.Empty;

            foreach (string key in collection.Keys)
            {
                if (key == variableName)
                {
                    localResult = collection[key];
                    break;
                }
            }

            return localResult;
        }
    }
}
