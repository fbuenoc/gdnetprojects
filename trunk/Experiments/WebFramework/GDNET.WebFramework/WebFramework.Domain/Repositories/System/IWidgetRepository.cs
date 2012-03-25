using GDNET.Common.Data;
using WebFramework.Domain.System;

namespace WebFramework.Domain.Repositories.System
{
    public interface IWidgetRepository : IRepositoryBase<Widget, long>
    {
        Widget GetByCode(string p);
    }
}
