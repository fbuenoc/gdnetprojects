using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GDNET.Common.DesignByContract
{
    public static class ThrowException
    {
        /// <summary>
        /// Throw an ArgumentNullException if object to test is null.
        /// </summary>
        public static void ArgumentNullException(object testObject, string paramName, string message)
        {
            if (testObject == null)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        /// <summary>
        /// Throw an ArgumentException if object to test is null or empty.
        /// </summary>
        public static void ArgumentExceptionIfNullOrEmpty(string testObject, string paramName, string message)
        {
            if (string.IsNullOrEmpty(testObject))
            {
                throw new ArgumentException(message, paramName);
            }
        }

        #region ArgumentOutOfRangeException

        /// <summary>
        /// Throw an ArgumentOutOfRangeException if object to test is less than zero.
        /// </summary>
        public static void ArgumentOutOfRangeExceptionIfNegative(decimal testObject, string paramName, string message)
        {
            if (testObject < 0)
            {
                ThrowException.ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Throw an ArgumentOutOfRangeException if object to test is less than zero.
        /// </summary>
        public static void ArgumentOutOfRangeException(decimal testObject, decimal rangeFrom, decimal rangeTo, string paramName)
        {
            ThrowException.InvalidOperationExceptionIfFalse((rangeFrom <= rangeTo), string.Format("Range is invalid, from is '{0}', to is '{1}'.", rangeFrom, rangeTo));

            if (testObject < rangeFrom || testObject > rangeFrom)
            {
                string message = string.Format("Range is invalid, from is '{0}', to is '{1}' but was '{2}'.", rangeFrom, rangeTo, testObject);
                ThrowException.ArgumentOutOfRangeException("testObject", message);
            }
        }

        public static void ArgumentOutOfRangeException(string paramName, string message)
        {
            throw new ArgumentOutOfRangeException(paramName, message);
        }

        #endregion

        /// <summary>
        /// Throw a FileNotFoundException if file to test is not found.
        /// </summary>
        public static void FileNotFoundException(string testPath, string message)
        {
            if (!File.Exists(testPath))
            {
                throw new FileNotFoundException(message, testPath);
            }
        }

        #region InvalidOperationException

        /// <summary>
        /// Throw an InvalidOperationException if object to test is null.
        /// </summary>
        public static void InvalidOperationExceptionIfNull(object testObject, string message)
        {
            if (testObject == null)
            {
                ThrowException.InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Throw an InvalidOperationException if object to test is false.
        /// </summary>
        public static void InvalidOperationExceptionIfFalse(bool testObject, string message)
        {
            if (!testObject)
            {
                ThrowException.InvalidOperationException(message);
            }
        }

        public static void InvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }

        #endregion

        /// <summary>
        /// Throw a NotImplementedException
        /// </summary>
        public static void NotImplementedException(string message)
        {
            throw new NotImplementedException(message);
        }

        public static void NotSupportedException(string message)
        {
            throw new NotSupportedException(message);
        }
    }
}
