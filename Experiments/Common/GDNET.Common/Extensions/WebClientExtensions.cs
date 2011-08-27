using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GDNET.Common.Extensions
{
    public static class WebClientExtensions
    {
        public static string DownloadAsString(this WebClient client, string url, string fileToSave)
        {
            string content = client.DownloadString(url);

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
