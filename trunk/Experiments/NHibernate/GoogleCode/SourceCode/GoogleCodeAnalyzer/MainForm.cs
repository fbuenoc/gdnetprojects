using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using GoogleCode.Core.Domain;
using Domain = GoogleCode.Core.Domain;
using GoogleCode.Data;
using GoogleCode.DataAnalyzer;

using GDNET.Common.Extensions;
using GDNET.Extensions.NHibernateImpl;

using TVN.LogHelper;

namespace GoogleCodeAnalyzer
{
    public partial class MainForm : Form
    {
        private const string HtmlFile = "googlecode.html";
        private int from, to, total;
        private int start, filter, projectsPerPage, projectCount;

        public MainForm()
        {
            InitializeComponent();
        }

        #region ProjectWorker methods

        private void bgProjectWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get stats
            using (WebClient client = new WebClient())
            {
                string htmlContent = string.Empty;
                try
                {
                    htmlContent = client.DownloadAsString(GoogleCodeHelper.RootUrl, HtmlFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                if (GoogleCodeHelper.GetStats(htmlContent, out this.from, out this.to, out this.total))
                {
                    this.projectsPerPage = this.to;
                    // Apply page selection
                    this.start = this.projectsPerPage * Convert.ToInt32(this.nudFromPage.Value);
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
                        using (var transaction = session.BeginTransaction())
                        {
                            try
                            {
                                var projectRepository = new ProjectRepository(session);
                                var labelRepository = new LabelRepository(session);

                                var dbProjects = projectRepository.FindByProperty(ProjectMeta.Name, GoogleCodeHelper.GetProjectNames(projects));
                                var dbLabels = labelRepository.FindByProperty(LabelMeta.Name, GoogleCodeHelper.GetProjectLabelNames(projects));

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
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                LogBase.LogError(MethodInfo.GetCurrentMethod(), ex);
                            }
                        }
                    }
                }

                this.start += this.projectsPerPage;
                this.bgProjectWorker.ReportProgress(0);
                if (this.start >= this.total)
                {
                    break;
                }
            }
            while (true);
        }

        private void bgProjectWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.txtTotalProjects.Text = this.total.ToString();
            this.txtCurrentProject.Text = this.start.ToString();
        }

        private void bgProjectWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnStart.Enabled = true;
            this.btnCancel.Enabled = false;
        }

        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.bgProjectWorker.IsBusy)
            {
                MessageBox.Show("Worker is busy, please wait some seconds.");
                return;
            }

            this.bgProjectWorker.RunWorkerAsync();
            this.btnStart.Enabled = false;
            this.btnCancel.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.bgProjectWorker.CancelAsync();
            this.btnStart.Enabled = true;
            this.btnCancel.Enabled = false;
        }
    }
}
