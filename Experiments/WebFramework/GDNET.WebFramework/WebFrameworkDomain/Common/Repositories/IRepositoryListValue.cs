﻿using System.Collections.Generic;
using GDNET.Common.Data;

namespace WebFrameworkDomain.Common.Repositories
{
    public interface IRepositoryListValue : IRepositoryBase<ListValue, long>
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
