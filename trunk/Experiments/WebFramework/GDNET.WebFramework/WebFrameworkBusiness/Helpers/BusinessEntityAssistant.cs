using System;
using System.Collections.Generic;
using System.Linq;
using GDNET.Common.Helpers;
using GDNET.Common.Security.Services;
using GDNET.Extensions;
using WebFrameworkBusiness.Base;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkBusiness.Helpers
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

        /// <summary>
        /// NOT COMPLETED
        /// </summary>
        public static TEntity GetById<TEntity>(long id) where TEntity : BusinessEntityBase
        {
            var contentItem = DomainRepositories.ContentItem.GetById(id);
            if (contentItem != null)
            {
                TEntity entity = (TEntity)Activator.CreateInstance(typeof(TEntity), true);
                if (ReflectionAssistant.SetFieldValue(entity, entity.FieldNameItemData, contentItem))
                {
                    // We always have Encryption attribute, so we have to retrieve it first, then use to decrypt other properties
                    var encryptionAttribute = contentItem.AttributeValues.First(x => x.ContentAttribute.Code == entity.FieldNameEncryption);
                    var encryptionOption = encryptionAttribute.Value.Value.ParseEnum<EncryptionOption>();

                    if (ReflectionAssistant.SetFieldValue(entity, entity.FieldNameEncryption, encryptionOption, typeof(BusinessEntityBase)))
                    {
                        // Now we load other properties
                        var objectProperties = ReflectionAssistant.GetFieldValue(entity, entity.FieldNameProperties, typeof(BusinessEntityBase));
                        if (objectProperties != null)
                        {
                            Dictionary<string, Type> properties = (Dictionary<string, Type>)objectProperties;
                            foreach (var kvp in properties.Where(x => x.Key != ExpressionAssistant.GetPropertyName(() => entity.FieldNameEncryption)))
                            {
                                var attributeValue = contentItem.AttributeValues.FirstOrDefault(x => x.ContentAttribute.Code == kvp.Key);
                                if (attributeValue != null)
                                {
                                    //var decryptedValue = this.DecryptData(attributeValue.Value.Value);
                                    //this.PerformSetValue(kvp.Key, decryptedValue.ConvertFromString(kvp.Value));
                                }
                            }
                        }
                    }
                }
            }

            return default(TEntity);
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
