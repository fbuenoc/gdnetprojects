using System;
using GDNET.Common.DesignByContract;
using GDNET.Common.Security.Services;

namespace GDNET.Extensions
{
    public static class StringConverter
    {
        public static string ConvertToString(this object objectValue, Type objectType)
        {
            string result = null;
            ThrowException.ArgumentNullException(objectType, "objectType", "Type of object can not be null.");

            if (objectValue != null)
            {
                if (objectType.FullName == typeof(string).FullName)
                {
                    result = (string)objectValue;
                }
                else if (IsNumberic(objectType))
                {
                    result = objectValue.ToString();
                }
                else if (objectType.FullName == typeof(DateTime).FullName)
                {
                    result = ((DateTime)objectValue).ToBinary().ToString();
                }
                else if (objectType.FullName == typeof(EncryptionOption).FullName)
                {
                    result = objectValue.ToString();
                }
                else
                {
                    ThrowException.NotSupportedException(string.Format("The type '{0}' is not supported.", objectType.FullName));
                }
            }

            return result;
        }

        public static object ConvertFromString(this string objectString, Type objectType)
        {
            object result = null;
            ThrowException.ArgumentNullException(objectType, "objectType", "Type of object can not be null.");

            if (!string.IsNullOrEmpty(objectString))
            {
                if (objectType.FullName == typeof(string).FullName)
                {
                    result = (object)objectString;
                }
                else if (IsNumberic(objectType))
                {
                    result = Convert.ChangeType(objectString, objectType);
                }
                else if (objectType.FullName == typeof(DateTime).FullName)
                {
                    result = Convert.ChangeType(DateTime.FromBinary(long.Parse(objectString)), objectType);
                }
                else if (objectType.FullName == typeof(EncryptionOption).FullName)
                {
                    result = objectString.ParseEnum<EncryptionOption>();
                }
                else
                {
                    ThrowException.NotSupportedException(string.Format("The type '{0}' is not supported.", objectType.FullName));
                }
            }

            return result;
        }

        private static bool IsNumberic(Type objectType)
        {
            return (objectType.FullName == typeof(int).FullName || objectType.FullName == typeof(long).FullName || objectType.FullName == typeof(double).FullName);
        }
    }
}
