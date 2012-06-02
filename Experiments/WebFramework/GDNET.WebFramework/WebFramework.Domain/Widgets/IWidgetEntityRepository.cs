using System.Collections.Generic;
using WebFramework.Domain.System;

namespace WebFramework.Domain.Widgets
{
    /// <summary>
    /// Marked interface, so no nothing here
    /// </summary>
    public interface IWidgetEntityRepository
    {
    }

    public interface IWidgetEntityRepository<TEntity> : IWidgetEntityRepository
    {
        IList<TEntity> GetAllByRegion(Region region);
    }
}
