using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace GDNET.Web.Helpers
{
    /// <summary>
    /// Provides helper methods for <typeparamref name="Control"/>
    /// </summary>
    public static class ControlHelper
    {
        /// <summary>
        /// Find first sub control by given type. Returns default of <typeparamref name="T"/> if no control found.
        /// </summary>
        public static T FindControlByType<T>(this Control parentControl) where T : Control
        {
            return parentControl.FindControlByType<T>(string.Empty);
        }

        /// <summary>
        /// Find first sub control by given type. Returns default of <typeparamref name="T"/> if no control found.
        /// </summary>
        /// <param name="serverId">If serverId is null or empty, the first control of T is returned.</param>
        public static T FindControlByType<T>(this Control parentControl, string serverId) where T : Control
        {
            if (parentControl != null)
            {
                if (CheckControl<T>(parentControl, serverId))
                {
                    return (T)parentControl;
                }
                foreach (Control childControl in parentControl.Controls)
                {
                    T result = FindControlByType<T>(childControl, serverId);
                    if (result != default(T))
                    {
                        return result;
                    }
                }
            }

            return default(T);
        }

        /// <summary>
        /// Find first sub control. Returns default of <typeparamref name="Control"/> if no control found.
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public static Control FindControlById(this Control parentControl, string serverId)
        {
            return parentControl.FindControlByType<Control>(serverId);
        }

        private static bool CheckControl<T>(Control controlItem, string serverId)
        {
            if ((controlItem != null) && (controlItem is T))
            {
                if (string.IsNullOrEmpty(serverId) || serverId.Equals(controlItem.ID))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Find all sub controls by given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parentControl"></param>
        /// <returns>
        /// The parent control
        /// </returns>
        public static IEnumerable<T> FindControlsByType<T>(this Control parentControl)
        {
            if ((parentControl != null) && (parentControl.Controls.Count > 0))
            {
                foreach (var sc in parentControl.Controls)
                {
                    if (sc is T)
                    {
                        yield return (T)sc;
                    }
                }
            }
        }

        /// <summary>
        /// Add to current sub controls
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="subControls"></param>
        /// <returns>
        /// The parent control
        /// </returns>
        public static Control AddSubControls(this Control parentControl, IList<Control> subControls)
        {
            if (subControls != null)
            {
                foreach (var c in subControls)
                {
                    parentControl.Controls.Add(c);
                }
            }

            return parentControl;
        }

        /// <summary>
        /// Add to current sub controls
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="subControls"></param>
        /// <returns></returns>
        public static Control AddSubControls(this Control parentControl, params Control[] subControls)
        {
            return parentControl.AddSubControls(new List<Control>(subControls));
        }

        /// <summary>
        /// Add to current sub controls
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="subControls"></param>
        /// <returns>
        /// The parent control
        /// </returns>
        public static Control AddSubControls(this Control parentControl, ControlCollection subControls)
        {
            return parentControl.AddSubControls(subControls.ToList());
        }

        private static IList<Control> ToList(this ControlCollection controls)
        {
            List<Control> listOfControls = new List<Control>();
            foreach (Control controlItem in controls)
            {
                listOfControls.Add(controlItem);
            }
            return listOfControls;
        }
    }
}
