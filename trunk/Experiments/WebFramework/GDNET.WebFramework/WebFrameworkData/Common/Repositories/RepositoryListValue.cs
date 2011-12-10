using System;
using System.Collections.Generic;

using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

using GDNET.Extensions;
using GDNET.NHibernateImpl.Data;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryListValue : NHRepositoryBase<ListValue, long>, IRepositoryListValue
    {
        public RepositoryListValue(ISession session)
            : base(session)
        {
        }

        public ListValue FindByName(string name)
        {
            var results = this.FindByProperty(ListValueMeta.Name, name);
            return (results.Count == 0) ? null : results[0];
        }

        public IList<ListValue> GetAllRootValues()
        {
            var criteria = base.session.CreateCriteria(typeof(ListValue)).Add(Expression.IsNull(ListValueMeta.Parent));
            return criteria.List<ListValue>();
        }

        public IList<ListValue> GetAllValuesByParent(ListValue parent)
        {
            //try
            //{
            //    string hql = "select sv from {0} as lv left join lv.{1} as sv where lv.{2} = '{3}'";
            //    hql = string.Format(hql, typeof(ListValue).Name,
            //                             ExpressionHelper.GetPropertyName(() => parent.SubValues),
            //                             ExpressionHelper.GetPropertyName(() => parent.Id),
            //                             parent.Id.ToString());
            //}
            //catch (Exception ex)
            //{
            //}

            List<ListValue> listOfValues = new List<ListValue>();
            if (parent != null)
            {
                this.GetAllChildren(parent, listOfValues);
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
