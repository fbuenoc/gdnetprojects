using System.Web;

namespace GDNET.Web.Helpers
{
    public static class HttpContextAssistant
    {
        /// <summary>
        /// Set item value into http context items if there is no item with current name or type of current object with give name is not the same.
        /// </summary>
        public static void TrySetItem(object itemName, object itemValue)
        {
            if (!HttpContext.Current.Items.Contains(itemName) || (HttpContext.Current.Items[itemName] == null) || !HttpContext.Current.Items.Contains(itemName).GetType().Equals(itemValue.GetType()))
            {
                HttpContext.Current.Items[itemName] = itemValue;
            }
        }

        /// <summary>
        /// Try to get item from http context items
        /// </summary>
        public static T TryGetItem<T>(object itemName)
        {
            T result = default(T);
            if (HttpContext.Current.Items.Contains(itemName) && (HttpContext.Current.Items[itemName] != null) && HttpContext.Current.Items[itemName].GetType().Equals(typeof(T)))
            {
                result = (T)HttpContext.Current.Items[itemName];
            }
            return result;
        }
    }
}