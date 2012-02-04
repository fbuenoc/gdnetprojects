using System;
using System.IO;
using System.Net;
using System.Threading;

namespace GDNET.Extensions
{
    public static class NetAssistant
    {
        /// <summary>
        /// Download HTML content from a given URL, and retry 3 times if connection is failed.
        /// </summary>
        public static string DownloadAsString(this WebClient client, string url, string fileToSave)
        {
            return client.DownloadAsString(url, fileToSave, 3, 500);
        }

        /// <summary>
        /// Download HTML content from a given URL.
        /// </summary>
        /// <param name="retryTimes">Retry times if connection is failed.</param>
        /// <param name="delayTimes">Time to delay (in milli seconds) if any error occurs during getting content.</param>
        public static string DownloadAsString(this WebClient client, string url, string fileToSave, int retryTimes, int delayTimes)
        {
            string content = string.Empty;
            bool isOK = false;
            Exception errorException = null;

            // Download HTML content
            do
            {
                try
                {
                    content = client.DownloadString(url);
                    isOK = true;
                }
                catch (Exception ex)
                {
                    retryTimes -= 1;
                    errorException = ex;
                    Thread.Sleep(delayTimes);
                }
            }
            while (!isOK && (retryTimes > 0));

            // Throw errorException if we can not download content after a NB of retry times.
            if (!isOK)
            {
                throw errorException;
            }

            // Okie, continue saving HTML content and return its value.
            FileInfo htmlFile = new FileInfo(fileToSave);
            if (htmlFile.Exists)
            {
                htmlFile.Delete();
            }
            File.WriteAllText(fileToSave, content);

            return content;
        }
    }
}
