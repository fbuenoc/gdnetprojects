using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData
{
    public interface IDomainRepositories
    {
        IRepositoryCategory GetRepositoryCategory();
        IRepositoryTranslation GetRepositoryTranslation();
        IRepositoryTemporary GetRepositoryTemporary();
    }
}
