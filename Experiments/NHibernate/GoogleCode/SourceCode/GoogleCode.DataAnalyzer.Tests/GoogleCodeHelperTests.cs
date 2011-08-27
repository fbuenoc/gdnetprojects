using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using System.Net;
using GDNET.Common.Extensions;
using GoogleCode.Core.Domain;

namespace GoogleCode.DataAnalyzer.Tests
{
    [TestFixture]
    public class GoogleCodeHelperTests
    {
        private const string HtmlFile = "googlecode.html";

        [Test]
        public void GetStatsTest()
        {
            int from, to, total;
            using (WebClient client = new WebClient())
            {
                var htmlContent = client.DownloadAsString(GoogleCodeHelper.RootUrl, HtmlFile);
                bool result = GoogleCodeHelper.GetStats(htmlContent, out from, out to, out total);
                Assert.IsTrue(result);
            }
        }

        [Test]
        public void GetProjectsTest()
        {
            int from = 0, start = 0;
            IList<Project> projects = null;

            using (WebClient client = new WebClient())
            {
                var htmlContent = client.DownloadAsString(string.Format(GoogleCodeHelper.ProjectsUrl, string.Empty, from, start), HtmlFile);
                bool result = GoogleCodeHelper.GetProjects(htmlContent, out projects);
                Assert.IsTrue(result);
            }
        }
    }
}
