using System;
using WebFramework.Domain;
using WebFramework.Domain.Common;

namespace WebFramework.Business.Base
{
    public abstract partial class BusinessEntityBase
    {
        public static BusinessEntityBaseFactory Factory
        {
            get { return new BusinessEntityBaseFactory(); }
        }

        public sealed class BusinessEntityBaseFactory
        {
            /// <summary>
            /// Create a new instance without initializing data item (ONLY USE TO LOAD OBJECT)
            /// </summary>
            public TEntity NewInstance<TEntity>() where TEntity : BusinessEntityBase
            {
                return (TEntity)Activator.CreateInstance(typeof(TEntity), true);
            }

            public TEntity Create<TEntity>() where TEntity : BusinessEntityBase
            {
                TEntity entity = (TEntity)Activator.CreateInstance(typeof(TEntity), true);

                var contentType = DomainRepositories.ContentType.FindByTypeName(entity.QualifiedTypeName);
                ((BusinessEntityBase)entity).ItemData = ContentItem.Factory.Create(typeof(TEntity).Name, string.Empty, contentType);

                return entity;
            }

            public TEntity Create<TEntity>(string name, string description) where TEntity : BusinessEntityBase
            {
                TEntity entity = this.Create<TEntity>();

                entity.ItemData.Name = Translation.Factory.Create(name);
                entity.ItemData.Description = Translation.Factory.Create(description);

                return entity;
            }
        }

    }
}
