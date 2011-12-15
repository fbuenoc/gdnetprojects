using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using GDNET.Common.DesignByContract;

namespace MergingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToMerge = ConfigurationManager.AppSettings[Constants.PathToMerge];
            string fileExtensions = ConfigurationManager.AppSettings[Constants.FileExtensions];
            string resultFile = ConfigurationManager.AppSettings[Constants.ResultFile];
            string excludeFiles = ConfigurationManager.AppSettings[Constants.ExcludeFiles];

            if (Directory.Exists(pathToMerge) == false)
            {
                throw new DirectoryNotFoundException(string.Format("Directory {0} is not found", pathToMerge));
            }

            StringBuilder resultBuilder = new StringBuilder();
            DirectoryInfo dInfo = new DirectoryInfo(pathToMerge);
            var listOfFiles = dInfo.GetFiles().Where(file => fileExtensions.Contains(file.Extension) && !excludeFiles.Contains(file.Name)).ToList();

            foreach (var file in listOfFiles)
            {
                resultBuilder.Append("-- #####################");
                resultBuilder.AppendLine();

                resultBuilder.AppendFormat("-- {0}", file.Name);
                resultBuilder.AppendLine();

                resultBuilder.Append("-- #####################");
                resultBuilder.AppendLine();
                resultBuilder.AppendLine();

                var fileContent = file.OpenText().ReadToEnd();
                resultBuilder.Append(fileContent);
                resultBuilder.AppendLine();
            }

            if (File.Exists(resultFile))
            {
                File.Delete(resultFile);
            }

            FileInfo f = new FileInfo(resultFile);
            using (var fs = f.OpenWrite())
            {
                var bytes = Encoding.UTF8.GetBytes(resultBuilder.ToString());
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
        }
    }
}
