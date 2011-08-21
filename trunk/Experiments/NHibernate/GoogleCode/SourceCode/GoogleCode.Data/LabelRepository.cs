using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;

using GoogleCode.Core.Data;
using GoogleCode.Core.Domain;

namespace GoogleCode.Data
{
    public class LabelRepository : NHRepositoryBase<Label, int>, ILabelRepository
    {
        public LabelRepository(ISession session)
            : base(session)
        {
        }
    }
}
