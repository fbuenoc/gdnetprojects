using System;
using GDNET.Domain.Common;
using GDNET.Domain.Entities.System;

namespace GDNET.Domain.Repositories.System
{
    public interface ICatalogRepository : IRepositoryBase<Catalog, Guid>
    {
        Catalog FindByCode(string code);
    }
}
