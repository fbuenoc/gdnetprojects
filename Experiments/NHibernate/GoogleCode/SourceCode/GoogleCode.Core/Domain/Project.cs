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
        public virtual IList<Label> Labels { get; set; }

        public Project()
        {
            this.Labels = new List<Label>();
        }

        public virtual void AddLabel(Label l)
        {
            this.Labels.Add(l);
        }
    }
}
