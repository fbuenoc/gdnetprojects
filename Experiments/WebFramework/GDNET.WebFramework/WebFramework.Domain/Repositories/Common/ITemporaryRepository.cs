using System;
using GDNET.Common.Data;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.Repositories.Common
{
    public interface ITemporaryRepository : IRepositoryWithActiveBase<Temporary, Guid>
    {
    }
}
