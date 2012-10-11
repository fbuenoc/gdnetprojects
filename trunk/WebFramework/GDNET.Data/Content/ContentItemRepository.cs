using System;
using System.Collections.Generic;
using GDNET.Base;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories.Content;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagement;
using NHibernate.Criterion;

namespace GDNET.Data.Content
{
    public class ContentItemRepository : AbstractRepository<ContentItem, Guid>, IContentItemRepository
    {
        private static readonly ContentItem DefaultContentItem = default(ContentItem);

        public ContentItemRepository(INHibernateRepositoryStrategy strategy)
            : base(strategy)
        {
        }

        public IList<ContentItem> GetTopWithActive(int limit)
        {
            var propertyCreatedAt = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.CreatedAt);
            var propertyIsActive = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.IsActive);

            return base.GetTopByProperty(limit, propertyCreatedAt, new List<string> { propertyIsActive }, new List<object> { true });
        }

        public IList<ContentItem> GetTopWithActiveByViews(int limit)
        {
            var propertyViews = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.Views);
            var propertyIsActive = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.IsActive);

            return base.GetAll(limit, Expression.Eq(propertyIsActive, true), new Order(propertyViews, false));
        }

        public IList<ContentItem> GetTopWithActiveByViews(int limit, Guid itemIdExclude)
        {
            var propertyViews = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.Views);
            var propertyId = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.Id);
            var propertyIsActive = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.IsActive);

            var criterions = new List<ICriterion>()
            { 
                Expression.Eq(propertyIsActive, true),
                Expression.Not(Expression.Eq(propertyId, itemIdExclude)),
            };
            var orders = new List<Order>() 
            {
                new Order(propertyViews, false)
            };

            return base.GetAll(limit, criterions, orders);
        }

        public IList<ContentItem> GetTopWithActiveByAuthor(int limit, string authorEmail)
        {
            var propertyCreatedBy = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.CreatedBy);
            var propertyIsActive = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.IsActive);
            var propertyCreatedAt = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.CreatedAt);
            var propertyLastModifiedAt = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.LastModifiedAt);

            var criterions = new List<ICriterion>()
            { 
                Expression.Eq(propertyIsActive, true),
                Expression.Eq(propertyCreatedBy, authorEmail),
            };
            var orders = new List<Order>() 
            {
                new Order(propertyCreatedBy, false),
                new Order(propertyLastModifiedAt, false)
            };

            return base.GetAll(limit, criterions, orders);
        }
    }
}
