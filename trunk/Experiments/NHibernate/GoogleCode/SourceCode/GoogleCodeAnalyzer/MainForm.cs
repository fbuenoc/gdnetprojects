using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using GoogleCode.DataAnalyzer;
using GDNET.Common.Extensions;
using GoogleCode.Core.Domain;
using GDNET.Extensions.NHibernateImpl;
using GoogleCode.Data;
using Domain = GoogleCode.Core.Domain;
using System.Threading;

namespace GoogleCodeAnalyzer
{
    public partial class MainForm : Form
    {
        private const string HtmlFile = "googlecode.html";
        private int from, to, total;
        private int start, filter, pageProjects, projectCount;

        public MainForm()
        {
            InitializeComponent();
        }

        private void bgProcessor_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get stats
            using (WebClient client = new WebClient())
            {
                var htmlContent = client.DownloadAsString(GoogleCodeHelper.RootUrl, HtmlFile);
                if (GoogleCodeHelper.GetStats(htmlContent, out this.from, out this.to, out this.total))
                {
                    this.pageProjects = this.to;
                }
                this.bgProjectWorker.ReportProgress(0);
            }

            do
            {
                if (this.bgProjectWorker.CancellationPending)
                {
                    break;
                }

                string htmlContent = null;
                using (WebClient client = new WebClient())
                {
                    htmlContent = client.DownloadAsString(string.Format(GoogleCodeHelper.ProjectsUrl, string.Empty, this.filter, this.start), HtmlFile);
                }

                IList<Project> projects;
                if (GoogleCodeHelper.GetProjects(htmlContent, out projects))
                {
                    using (var session = NHSessionManager.OpenSession())
                    {
                        var projectRepository = new ProjectRepository(session);
                        var labelRepository = new LabelRepository(session);

                        var dbProjects = projectRepository.FindByProperty(ProjectMeta.Name, GoogleCodeHelper.GetProjectNames(projects));
                        var dbLabels = labelRepository.FindByProperty(LabelMeta.Name, GoogleCodeHelper.GetProjectLabelNames(projects));

                        using (var transaction = session.BeginTransaction())
                        {
                            var newLabels = GoogleCodeHelper.GetProjectLabels(projects).ToList().FindAll(delegate(Domain.Label item)
                            {
                                return dbLabels.FirstOrDefault(l => l.Name == item.Name) == null;
                            });
                            labelRepository.SaveOrUpdate(newLabels);

                            var newProjects = projects.ToList().FindAll(delegate(Domain.Project item)
                            {
                                return dbProjects.FirstOrDefault(p => p.Name == item.Name) == null;
                            });

                            // Update label that already in database
                            GoogleCodeHelper.UpdateLabels(projects, dbLabels);

                            projectRepository.SaveOrUpdate(newProjects);

                            transaction.Commit();
                        }
                    }
                }

                this.start += this.pageProjects;
                this.bgProjectWorker.ReportProgress(0);
                if (this.start >= this.total)
                {
                    break;
                }
            }
            while (true);
        }

        private void bgProcessor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.txtTotalProjects.Text = this.total.ToString();
            this.txtCurrentProject.Text = this.start.ToString();
        }

        private void bgProcessor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnStart.Enabled = true;
            this.btnCancel.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.bgProjectWorker.RunWorkerAsync();
            this.btnStart.Enabled = false;
            this.btnCancel.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.bgProjectWorker.CancelAsync();

            while (this.bgProjectWorker.IsBusy)
            {
                Thread.Sleep(300);
            }

            this.btnStart.Enabled = true;
            this.btnCancel.Enabled = false;
        }
    }
}
