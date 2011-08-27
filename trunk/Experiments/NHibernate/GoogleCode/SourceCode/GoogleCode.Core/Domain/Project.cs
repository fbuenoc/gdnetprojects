using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.Domain;

namespace GoogleCode.Core.Domain
{
    public class ProjectMeta
    {
        public const string Name = "Name";
        public const string Homepage = "Homepage";
        public const string LogoUrl = "LogoUrl";
        public const string Activity = "Activity";
        public const string LastUpdate = "LastUpdate";
        public const string Description = "Description";
    }

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
            ProjectLabelLink link = new ProjectLabelLink
            {
                CreatedDate = DateTime.Now,
                Label = label,
                Project = this
            };

            this.AddLink(link);
        }

        public virtual void AddLink(ProjectLabelLink link)
        {
            this.Links.Add(link);
        }
    }
}
