using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.Domain;

namespace GoogleCode.Core.Domain
{
    public class Project : DomainBase<long>
    {
        public virtual string Name { get; set; }
        public virtual string Homepage { get; set; }
        public virtual string LogoUrl { get; set; }
        public virtual string Activity { get; set; }
        public virtual DateTime LastUpdate { get; set; }
        public virtual string Description { get; set; }

        /// <summary>
        /// All labels attached to this project
        /// </summary>
        public virtual IList<ProjectLabelLink> Links { get; set; }

        public Project()
        {
            this.Links = new List<ProjectLabelLink>();
        }

        public virtual void AddLink(Label label)
        {
            this.AddLink(new ProjectLabelLink
            {
                Project = this,
                Label = label,
                CreatedDate = DateTime.Now
            });
        }

        public virtual void AddLink(ProjectLabelLink link)
        {
            this.Links.Add(link);
        }
    }
}
