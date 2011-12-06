using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GDNET.Web.Helpers
{
    public static class HttpContextHelper
    {
        /// <summary>
        /// Set item value into http context items if there is no item with current name or type of current object with give name is not the same.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemValue"></param>
        public static void TrySetItem(object itemName, object itemValue)
        {
            if (!HttpContext.Current.Items.Contains(itemName) || HttpContext.Current.Items.Contains(itemName).GetType() != itemValue.GetType())
            {
                HttpContext.Current.Items[itemName] = itemValue;
            }
        }

        /// <summary>
        /// Try to get item from http context items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public static T TryGetItem<T>(object itemName)
        {
            T result = default(T);
            if (HttpContext.Current.Items.Contains(itemName) && HttpContext.Current.Items[itemName].GetType() == typeof(T))
            {
                result = (T)HttpContext.Current.Items[itemName];
            }
            return result;
        }
    }
}