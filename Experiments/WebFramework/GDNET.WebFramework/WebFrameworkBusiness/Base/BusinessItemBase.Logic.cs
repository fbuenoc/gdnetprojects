using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GDNET.Common.DesignByContract;
using GDNET.Common.Encryption;
using GDNET.Common.Security.Services;
using GDNET.Common.Utils;
using GDNET.Extensions;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Constants;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkBusiness.Base
{
    public abstract partial class BusinessItemBase
    {
        private readonly IEncryptionService encryptor = new EncryptionService();

        private string EncryptData(string plainText)
        {
            return this.encryptor.Encrypt(plainText, this.Encryption);
        }

        private string DecryptData(string encryptedText)
        {
            return this.encryptor.Decrypt(encryptedText, this.Encryption);
        }

        /// <summary>
        /// Find content type, create new ContentType and its attributes if not found an expected CT
        /// </summary>
        private bool EnsureContentType(out ContentType contentType)
        {
            contentType = DomainRepositories.ContentType.FindByTypeName(this.QualifiedTypeName);

            if (contentType == null)
            {
                contentType = ContentType.Factory.Create(this.GetType().Name, this.QualifiedTypeName);
                if (!DomainRepositories.ContentType.Save(contentType))
                {
                    return false;
                }

                List<ContentAttribute> listOfAttributes = new List<ContentAttribute>();
                foreach (var propertyName in this.properties.Keys)
                {
                    var attribute = ContentAttribute.Factory.Create(propertyName, contentType, ListValueConstants.ContentDataTypes_Text_SimpleTextBox);
                    listOfAttributes.Add(attribute);
                }
                contentType.AddContentAttributes(listOfAttributes);

                if (!DomainRepositories.ContentType.Update(contentType))
                {
                    return false;
                }

                DomainRepositories.ContentType.Synchronize();
            }

            return true;
        }

        /// <summary>
        /// Get value of property by name, return default of Type if it was not setted
        /// </summary>
        protected T GetValue<T>(string propertyName)
        {
            return this.propertiesValues.ContainsKey(propertyName) ? (T)this.propertiesValues[propertyName] : default(T);
        }

        protected T GetValue<T>(Expression<Func<object>> expression)
        {
            return this.GetValue<T>(ExpressionUtil.GetPropertyName(expression));
        }

        /// <summary>
        /// Set value for a Property, throw exception if property is not registered or invalid type of data
        /// </summary>
        protected void SetValue<T>(string propertyName, T propertyValue)
        {
            if (!this.properties.ContainsKey(propertyName))
            {
                this.RegisterProperty(propertyName, typeof(T));
            }

            if (this.properties[propertyName].Equals(typeof(T)))
            {
                this.PerformSetValue(propertyName, propertyValue);
            }
            else
            {
                string msg1 = string.Format("Property '{0}' is not registered.", propertyName);
                ThrowException.InvalidOperationExceptionIfFalse(this.properties.ContainsKey(propertyName), msg1);

                string msg2 = string.Format("Type of property '{0}' must be '{1}'.", propertyName, this.properties[propertyName].FullName);
                ThrowException.InvalidOperationExceptionIfFalse(this.properties[propertyName].Equals(typeof(T)), msg2);
            }
        }

        protected void SetValue<T>(Expression<Func<object>> expression, T propertyValue)
        {
            this.SetValue<T>(ExpressionUtil.GetPropertyName(expression), propertyValue);
        }

        /// <summary>
        /// Register a property with its data type
        /// </summary>
        protected void RegisterProperty(string propertyName, Type dataType)
        {
            if (!this.properties.ContainsKey(propertyName))
            {
                this.properties.Add(propertyName, dataType);
            }
            else
            {
                this.properties[propertyName] = dataType;
            }
        }

        /// <summary>
        /// Force set value for property, carefully when call this method
        /// </summary>
        private void PerformSetValue(string propertyName, object propertyValue)
        {
            if (this.propertiesValues.ContainsKey(propertyName))
            {
                this.propertiesValues[propertyName] = propertyValue;
            }
            else
            {
                this.propertiesValues.Add(propertyName, propertyValue);
            }
        }

        #region Public Methods

        public bool LoadItemById(long id)
        {
            this.contentItem = DomainRepositories.ContentItem.GetById(id);
            if (this.contentItem != null)
            {
                // We always have Encryption attribute, so we have to retrieve it first, then use to decrypt other properties
                var encryptionAttribute = this.contentItem.AttributeValues.First(x => x.ContentAttribute.Code == ExpressionUtil.GetPropertyName(() => this.Encryption));
                this.Encryption = encryptionAttribute.Value.Value.ParseEnum<EncryptionOption>();

                // Now we load other properties
                foreach (var kvp in this.properties.Where(x => x.Key != ExpressionUtil.GetPropertyName(() => this.Encryption)))
                {
                    var attributeValue = this.contentItem.AttributeValues.FirstOrDefault(x => x.ContentAttribute.Code == kvp.Key);
                    if (attributeValue != null)
                    {
                        var decryptedValue = this.DecryptData(attributeValue.Value.Value);
                        this.PerformSetValue(kvp.Key, decryptedValue.ConvertFromString(kvp.Value));
                    }
                }

                this.UpdateEntityInfo();
                return true;
            }

            return false;
        }

        public bool Delete()
        {
            return DomainRepositories.ContentItem.Delete(this.Id);
        }

        public bool Save()
        {
            ContentType contentType = null;
            if (this.EnsureContentType(out contentType))
            {
                this.contentItem = ContentItem.Factory.Create(this.Name, this.Description, contentType, this.Position);
            }
            else
            {
                ThrowException.InvalidOperationException(string.Format("Can not setup for type '{0}'", this.QualifiedTypeName));
            }

            // Save values
            if (!DomainRepositories.ContentItem.Save(this.contentItem))
            {
                return false;
            }

            foreach (var kvp in this.propertiesValues)
            {
                var contentAttribute = contentType.ContentAttributes.FirstOrDefault(x => (x.Code == kvp.Key));
                if (contentAttribute == null)
                {
                    ThrowException.InvalidOperationException(string.Format("Property '{0}' is not found, you must re-config this content type", kvp.Key));
                }

                string value = kvp.Value.ConvertToString(this.properties[kvp.Key]);
                if (kvp.Key != ExpressionUtil.GetPropertyName(() => this.Encryption))
                {
                    value = this.EncryptData(value);
                }

                var attributeValue = ContentItemAttributeValue.Factory.Create(contentAttribute, contentItem, value);
                contentItem.AddAttributeValue(attributeValue);
            }

            if (!DomainRepositories.ContentItem.Update(this.contentItem))
            {
                return false;
            }

            DomainRepositories.ContentItem.Synchronize();
            this.UpdateEntityInfo();

            return true;
        }

        private void UpdateEntityInfo()
        {
            this.Id = this.contentItem.Id;
            this.CreatedAt = this.contentItem.CreatedAt;
            this.CreatedBy = this.contentItem.CreatedBy;
            this.IsActive = this.contentItem.IsActive;
            this.IsDeletable = this.contentItem.IsDeletable;
            this.IsEditable = this.contentItem.IsEditable;
            this.IsViewable = this.contentItem.IsViewable;
            this.LastModifiedAt = this.contentItem.LastModifiedAt;
            this.LastModifiedBy = this.contentItem.LastModifiedBy;
        }

        #endregion
    }
}
