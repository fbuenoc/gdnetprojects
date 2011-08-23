using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.Domain;

namespace GoogleCode.Core.Domain
{
    public class Label : DomainBase<int>
    {
        public virtual string Name { get; set; }
        /// <summary>
        /// All projects use this label
        /// </summary>
        public virtual IList<ProjectLabelLink> Links { get; set; }

        public Label()
        {
            this.Links = new List<ProjectLabelLink>();
        }

        public virtual void AddLink(Project project)
        {
            ProjectLabelLink link = new ProjectLabelLink
            {
                CreatedDate = DateTime.Now,
                Project = project,
                Label = this,
            };
            this.AddLink(link);
        }
        public virtual void AddLink(ProjectLabelLink link)
        {
            this.Links.Add(link);
        }
    }
}
