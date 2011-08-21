using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;

using GoogleCode.Core.Data;
using GoogleCode.Core.Domain;

namespace GoogleCode.Data
{
    public class ProjectRepository : NHRepositoryBase<Project, long>
    {
        public ProjectRepository(ISession session)
            : base(session)
        {
        }
    }
}
