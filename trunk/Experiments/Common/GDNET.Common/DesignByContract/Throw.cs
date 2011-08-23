using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GDNET.Common.DesignByContract
{
    public static class Throw
    {
        /// <summary>
        /// Throw an ArgumentNullException if object to test is null.
        /// </summary>
        /// <param name="objTest">The object to be tested</param>
        public static void ArgumentNullException(object objTest, string paramName, string message)
        {
            if (objTest == null)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        /// <summary>
        /// Throw an ArgumentException if object to test is null or empty.
        /// </summary>
        /// <param name="objTest">The object to be tested</param>
        public static void ArgumentExceptionIfNullOrEmpty(string objTest, string paramName, string message)
        {
            if (string.IsNullOrEmpty(objTest))
            {
                throw new ArgumentException(paramName, message);
            }
        }

        /// <summary>
        /// Throw an ArgumentOutOfRangeException if object to test is less than zero.
        /// </summary>
        /// <param name="objTest"></param>
        public static void ArgumentOutOfRangeExceptionIfNegative(decimal objTest, string paramName, string message)
        {
            if (objTest < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Throw a FileNotFoundException if file to test is not found.
        /// </summary>
        /// <param name="fileName">The file to test is exists or not.</param>
        public static void FileNotFoundException(string fileName, string message)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(message, fileName);
            }
        }

        /// <summary>
        /// Throw an InvalidOperationException if object to test is null.
        /// </summary>
        /// <param name="objTest">The object to be tested</param>
        public static void InvalidOperationExceptionIfNull(object objTest, string message)
        {
            if (objTest == null)
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Throw an InvalidOperationException if object to test is false.
        /// </summary>
        /// <param name="objTest">The object to be tested</param>
        public static void InvalidOperationExceptionIfFalse(bool objTest, string message)
        {
            if (!objTest)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
