using GDNET.Common.Data;
using WebFramework.Domain.System;

namespace WebFramework.Domain.Repositories.System
{
    public interface IPageRepository : IRepositoryBase<Page, long>
    {
        Page GetByUniqueName(string uniqueName);
    }
}
