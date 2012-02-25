using System;
using System.Collections.Generic;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkBusiness.Base
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

            ///// <summary>
            ///// Find content type, create new ContentType and its attributes if not found an expected content type.
            ///// Returns NULL if any error when querying.
            ///// </summary>
            //public ContentType EnsureContentType(BusinessEntityBase entity)
            //{
            //    ContentType contentType = DomainRepositories.ContentType.FindByTypeName(entity.QualifiedTypeName);

            //    if (contentType == null)
            //    {
            //        contentType = ContentType.Factory.Create(this.GetType().Name, entity.QualifiedTypeName);
            //        if (!DomainRepositories.ContentType.Save(contentType))
            //        {
            //            return null;
            //        }

            //        int position = 1;
            //        List<ContentAttribute> listOfAttributes = new List<ContentAttribute>();

            //        foreach (var propertyName in entity.properties.Keys)
            //        {
            //            var listeValue = DomainRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            //            var attribute = ContentAttribute.Factory.Create(propertyName, contentType, listeValue, position);
            //            listOfAttributes.Add(attribute);
            //            position += 1;
            //        }

            //        contentType.AddContentAttributes(listOfAttributes);

            //        if (!DomainRepositories.ContentType.Update(contentType))
            //        {
            //            return null;
            //        }

            //        DomainRepositories.RepositoryAssistant.Flush();
            //    }

            //    return contentType;
            //}
        }

    }
}
