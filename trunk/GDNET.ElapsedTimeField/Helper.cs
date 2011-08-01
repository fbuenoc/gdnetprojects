using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GDNET.ElapsedTimeField.ViewModels;

namespace GDNET.ElapsedTimeField
{
    public static class Helper
    {
        /// <summary>
        /// Get value from an array of string by key
        /// </summary>
        /// <param name="values"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static uint GetValueByKey(this string[] values, string key)
        {
            uint result = 0;
            if (values != null && key != null)
            {
                int index = 0;
                foreach (string s in values)
                {
                    index += 1;
                    if (s.Trim().Equals(key) && values.Length >= index)
                    {
                        result = Convert.ToUInt32(values[index]);
                        break;
                    }
                }
            }
            return result;
        }

        public static ElapsedTimeFieldViewModel ParseValue(string elapsedTime)
        {
            string[] values = elapsedTime.Split(',', ':');

            ElapsedTimeFieldViewModel model = new ElapsedTimeFieldViewModel
            {
                Years = Helper.GetValueByKey(values, Constants.Years),
                Months = Helper.GetValueByKey(values, Constants.Months),
                Days = Helper.GetValueByKey(values, Constants.Days),
                Hours = Helper.GetValueByKey(values, Constants.Hours),
                Minutes = Helper.GetValueByKey(values, Constants.Minutes)
            };

            return model;
        }
    }
}