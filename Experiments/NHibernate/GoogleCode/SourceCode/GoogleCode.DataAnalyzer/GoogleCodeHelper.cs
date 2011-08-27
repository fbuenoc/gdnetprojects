using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using GDNET.Common.Extensions;
using GoogleCode.Core.Domain;

namespace GoogleCode.DataAnalyzer
{
    public static class GoogleCodeHelper
    {
        public const string RootUrl = "http://code.google.com/hosting/search?q=&filter=0&start=0";
        public const string ProjectsUrl = "http://code.google.com/hosting/search?q={0}&filter={1}&start={2}";

        public static bool GetProjects(string htmlContent, out IList<Project> projects)
        {
            bool result = true;
            projects = new List<Project>();

            try
            {
                string pagedProjectsPattern = "<div id=\\\"serp\\\">(.*?)</div>";
                Regex pagedProjectsRegex = new Regex(pagedProjectsPattern, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

                var pagedProjectsMatches = pagedProjectsRegex.Matches(htmlContent);
                if (pagedProjectsMatches.Count == 1)
                {
                    string pagedProjectsHtmlContent = pagedProjectsMatches[0].Groups[1].Value;
                    string projectPattern = "<table>(.*?)</table>";
                    Regex projectRegex = new Regex(projectPattern, RegexOptions.Multiline | RegexOptions.Singleline);

                    foreach (Match projectMatch in projectRegex.Matches(pagedProjectsHtmlContent))
                    {
                        string projectHtmlContent = projectMatch.Groups[1].Value;
                        string projectContentPattern = "<tr>(.*?)</tr>";
                        Regex projectContentRegex = new Regex(projectContentPattern, RegexOptions.Multiline | RegexOptions.Singleline);

                        var projectContentMatches = projectContentRegex.Matches(projectHtmlContent);
                        if (projectContentMatches.Count > 0)
                        {
                            Project projectItem = new Project();
                            projects.Add(projectItem);

                            projectHtmlContent = projectContentMatches[0].Groups[1].Value;
                            var deepContentMatches = Regex.Matches(projectHtmlContent, "<td .*?>(.*?)</td>", RegexOptions.Multiline | RegexOptions.Singleline);
                            if (deepContentMatches.Count == 2)
                            {
                                string generalContent = deepContentMatches[0].Groups[1].Value;
                                string detailContent = deepContentMatches[1].Groups[1].Value;

                                // Get project homepage & logo
                                //string generalInfoPattern = "<a href=\\\"(.*?)\\\">.*?<img .*? src=\\\"(.*?)\\\" .*?</a>";
                                string generalInfoPattern = "<a href=\\\"(.*?)\\\">.*?<img(.*?)src=\\\"(.*?)\\\"(.*?)>.*?</a>";
                                var generalInfoMatches = Regex.Matches(generalContent, generalInfoPattern, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

                                if (generalInfoMatches.Count > 0)
                                {
                                    if (generalInfoMatches[0].Groups.Count >= 3)
                                    {
                                        projectItem.Homepage = generalInfoMatches[0].Groups[1].Value.Trim();
                                        projectItem.LogoUrl = generalInfoMatches[0].Groups[3].Value.Trim();
                                    }
                                }

                                // Get project details
                                string projectNamePattern = "<a .*?>(.*?)</a>.*?<br/>.*?<span .*?>.*?Activity: <img .*?>(.*?)-.*?Updated: (.*?)</span><br/>(.*?)<br/>";
                                var projectNameMatches = Regex.Matches(detailContent, projectNamePattern, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);
                                if (projectNameMatches.Count > 0)
                                {
                                    DateTime defaultDate = new DateTime(2000, 1, 1);
                                    projectItem.Name = projectNameMatches[0].Groups[1].Value.Trim();
                                    projectItem.Activity = projectNameMatches[0].Groups[2].Value.TrimWithHtmlSpaces();
                                    projectItem.LastUpdate = projectNameMatches[0].Groups[3].Value.Parse(defaultDate);
                                    projectItem.Description = projectNameMatches[0].Groups[4].Value.Trim();
                                }

                                // Get project labels
                                string projectLabelsPattern = "<span class=\\\"labels\\\">(.*?)</span>";
                                var projectLabelsMatches = Regex.Matches(detailContent, projectLabelsPattern, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);
                                if (projectLabelsMatches.Count > 0)
                                {
                                    string projectLabelsContent = projectLabelsMatches[0].Groups[1].Value;
                                    string projectLabelPattern = "<a .*?>(.*?)</a>";

                                    foreach (Match labelMatch in Regex.Matches(projectLabelsContent, projectLabelPattern, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase))
                                    {
                                        string labelName = labelMatch.Groups[1].Value.Trim();
                                        projectItem.AddLink(new Label
                                        {
                                            Name = labelName
                                        });
                                    }
                                }
                            }
                            else
                            {
                                result = false;
                            }
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public static bool GetStats(string htmlContent, out int from, out int to, out int total)
        {
            bool result = false;
            from = to = total = 0;

            string statsPattern = "<table class=\\\"mainhdr\\\" .*?>(.*?)</table>";
            Regex statsRegex = new Regex(statsPattern, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

            var matches = statsRegex.Matches(htmlContent);
            if (matches.Count > 0)
            {
                string innerTableContent = matches[0].Groups[1].Value.StripHtmlTags();
                // Results 1 - 10 of 5731
                IList<Int32> numbers = innerTableContent.GetNumbers();
                if (numbers.Count >= 3)
                {
                    from = numbers[0];
                    to = numbers[1];
                    total = numbers[2];
                    result = true;
                }
            }

            return result;
        }

        public static string[] GetProjectNames(IList<Project> projects)
        {
            List<string> projectNames = new List<string>();
            foreach (var project in projects)
            {
                projectNames.Add(project.Name);
            }

            return projectNames.ToArray();
        }

        public static string[] GetProjectLabelNames(IList<Project> projects)
        {
            List<string> labelNames = new List<string>();
            foreach (var project in projects)
            {
                foreach (var link in project.Links)
                {
                    labelNames.Add(link.Label.Name);
                }
            }

            return labelNames.ToArray();
        }

        public static IList<Label> GetProjectLabels(IList<Project> projects)
        {
            List<Label> labelNames = new List<Label>();
            foreach (var project in projects)
            {
                foreach (var link in project.Links)
                {
                    labelNames.Add(link.Label);
                }
            }

            return labelNames;
        }

        public static void UpdateLabels(IList<Project> projects, IList<Label> dbLabels)
        {
            foreach (var project in projects)
            {
                foreach (var link in project.Links)
                {
                    if (link.Label.Id == 0)
                    {
                        var label = dbLabels.FirstOrDefault(item => item.Name == link.Label.Name);
                        link.Label = label;
                    }
                }
            }
        }
    }
}
