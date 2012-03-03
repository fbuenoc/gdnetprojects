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
    }
}
