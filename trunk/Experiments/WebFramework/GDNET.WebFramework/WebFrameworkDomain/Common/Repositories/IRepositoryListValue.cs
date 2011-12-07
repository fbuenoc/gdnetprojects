using System.Collections.Generic;
using GDNET.Common.Data;

namespace WebFrameworkDomain.Common.Repositories
{
    public interface IRepositoryListValue : IRepositoryBase<ListValue, long>
    {
        ListValue FindByName(string name);
        IList<ListValue> GetAllRootValues();
        IList<ListValue> GetAllValuesByParent(ListValue parent);
    }
}
