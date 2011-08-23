using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDNET.Common.Domain;

namespace GoogleCode.Core.Domain
{
    public class ProjectLabelLink : DomainBase<long>
    {
        public virtual Project Project { get; set; }
        public virtual Label Label { get; set; }

        public virtual DateTime CreatedDate { get; set; }
    }
}
