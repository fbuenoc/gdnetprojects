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
    }
}
