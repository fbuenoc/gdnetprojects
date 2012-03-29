using System.Collections.Generic;
using GDNET.Common.Data;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.Repositories.Common
{
    public interface IListValueRepository : IRepositoryWithActiveBase<ListValue, long>
    {
        ListValue FindByName(string name);
        IList<ListValue> GetAllRootValues();
        /// <summary>
        /// Get all children of parent, without including parent
        /// </summary>
        IList<ListValue> GetAllValuesByParent(ListValue parent);
        /// <summary>
        /// Get all children of parent
        /// </summary>
        IList<ListValue> GetAllValuesByParent(ListValue parent, bool includeParent);
    }
}
