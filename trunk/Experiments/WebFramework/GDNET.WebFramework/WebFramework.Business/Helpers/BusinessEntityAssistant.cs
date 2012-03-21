using System;
using System.Collections.Generic;
using System.Linq;
using GDNET.Extensions;
using WebFramework.Business.Base;
using WebFramework.Domain;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;

namespace WebFramework.Business.Helpers
{
    public static class BusinessEntityAssistant
    {
        public static IList<TEntity> GetAll<TEntity>() where TEntity : BusinessEntityBase
        {
            return BusinessEntityAssistant.GetAll<TEntity>(int.MinValue, int.MinValue);
        }

        public static IList<TEntity> GetAllPaging<TEntity>(int pageIndex, int itemsPerPage) where TEntity : BusinessEntityBase
        {
            return BusinessEntityAssistant.GetAll<TEntity>(pageIndex * itemsPerPage, itemsPerPage);
        }

        public static IList<TEntity> GetAll<TEntity>(int fromIndex, int limitItems) where TEntity : BusinessEntityBase
        {
            List<TEntity> results = new List<TEntity>();
            return results;
        }

        public static TEntity GetById<TEntity>(long id) where TEntity : BusinessEntityBase
        {
            TEntity entity = (TEntity)Activator.CreateInstance(typeof(TEntity), true);
            if (entity.GetById(id))
            {
                return entity;
            }

            return default(TEntity);
        }

        public static IList<TEntity> GetAllByType<TEntity>() where TEntity : BusinessEntityBase
        {
            List<TEntity> listeEntities = new List<TEntity>();
            IList<ContentItem> listeContentItems = DomainRepositories.ContentItem.GetByContentType(typeof(TEntity));

            foreach (ContentItem item in listeContentItems)
            {
                TEntity entity = BusinessEntityAssistant.GetById<TEntity>(item.Id);
                if (entity != default(TEntity))
                {
                    listeEntities.Add(entity);
                }
            }

            return listeEntities;
        }

        /// <summary>
        /// Find content type, create new ContentType and its attributes if not found an expected content type.
        /// Returns NULL if any error when querying.
        /// </summary>
        public static ContentType EnsureContentType(BusinessEntityBase entity)
        {
            List<ContentAttributeInfo> attributesInfo = new List<ContentAttributeInfo>();
            return BusinessEntityAssistant.EnsureContentType(entity, attributesInfo);
        }

        /// <summary>
        /// Find content type, create new ContentType and its attributes if not found an expected content type.
        /// Attributes information are used to setup attribute.
        /// Returns NULL if any error when querying.
        /// </summary>
        public static ContentType EnsureContentType(BusinessEntityBase entity, IList<ContentAttributeInfo> attributesInfo)
        {
            ContentType contentType = DomainRepositories.ContentType.FindByTypeName(entity.QualifiedTypeName);

            if (contentType == null)
            {
                var objectProperties = ReflectionAssistant.GetFieldValue(entity, entity.FieldNameProperties, typeof(BusinessEntityBase));
                if (objectProperties != null)
                {
                    contentType = ContentType.Factory.Create(entity.GetType().Name, entity.QualifiedTypeName);
                    if (!DomainRepositories.ContentType.Save(contentType))
                    {
                        return null;
                    }

                    List<ContentAttribute> listOfAttributes = new List<ContentAttribute>();
                    Dictionary<string, Type> properties = (Dictionary<string, Type>)objectProperties;

                    foreach (var propertyName in properties.Keys)
                    {
                        var attrInfo = attributesInfo.FirstOrDefault(x => x.PropertyName == propertyName);
                        string contentDataType = (attrInfo == null) ? ListValueConstants.ContentDataTypes.TextSimpleTextBox : attrInfo.ContentDataType;
                        int position = (attrInfo == null) ? int.MaxValue : attrInfo.Position;

                        var dataType = DomainRepositories.ListValue.FindByName(contentDataType);
                        var attribute = ContentAttribute.Factory.Create(propertyName, propertyName, contentType, dataType, position);
                        listOfAttributes.Add(attribute);
                    }
                    contentType.AddContentAttributes(listOfAttributes);

                    if (!DomainRepositories.ContentType.Update(contentType))
                    {
                        return null;
                    }

                    DomainRepositories.RepositoryAssistant.Flush();
                }
            }

            return contentType;
        }

    }
}
