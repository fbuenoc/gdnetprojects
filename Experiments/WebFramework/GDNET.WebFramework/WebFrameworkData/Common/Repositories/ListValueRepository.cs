using System.Collections.Generic;
using System.Linq;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using NHibernate.Criterion;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;
using WebFramework.Domain.Repositories.Common;

namespace WebFramework.Data.Common.Repositories
{
    public class ListValueRepository : AbstractRepository<ListValue, long>, IListValueRepository
    {
        public ListValueRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        public ListValue FindByName(string name)
        {
            var results = this.FindByProperty(CommonConstants.ListValueMeta.Name, name);
            return (results.Count == 0) ? null : results[0];
        }

        public IList<ListValue> GetAllRootValues()
        {
            var criteria = base.sessionStrategy.Session.CreateCriteria(typeof(ListValue)).Add(Expression.IsNull(CommonConstants.ListValueMeta.Parent));
            return criteria.List<ListValue>();
        }

        public IList<ListValue> GetAllValuesByParent(ListValue parent)
        {
            return this.GetAllValuesByParent(parent, false);
        }

        public IList<ListValue> GetAllValuesByParent(ListValue parent, bool includeParent)
        {
            List<ListValue> listOfValues = new List<ListValue>();
            if (parent != null)
            {
                this.GetAllChildren(parent, listOfValues);

                if (includeParent == false)
                {
                    listOfValues.Remove(parent);
                }
            }

            return listOfValues;
        }

        private void GetAllChildren(ListValue parent, List<ListValue> children)
        {
            children.Add(parent);
            foreach (ListValue sub in parent.SubValues)
            {
                this.GetAllChildren(sub, children);
            }
        }
    }
}
