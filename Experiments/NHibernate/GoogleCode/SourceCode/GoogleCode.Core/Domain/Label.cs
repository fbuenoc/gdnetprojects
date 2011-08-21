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
        public virtual IList<Project> Projects { get; set; }

        public Label()
        {
            this.Projects = new List<Project>();
        }

        public virtual void AddProject(Project p)
        {
            this.Projects.Add(p);
        }
    }
}
