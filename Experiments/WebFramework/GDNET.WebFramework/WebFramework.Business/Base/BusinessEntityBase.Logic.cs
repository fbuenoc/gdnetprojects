using System;
using System.Linq;
using System.Linq.Expressions;
using GDNET.Common.DesignByContract;
using GDNET.Common.Encryption;
using GDNET.Common.Helpers;
using GDNET.Common.Security.Services;
using GDNET.Extensions;
using WebFramework.Business.Helpers;
using WebFramework.Domain;
using WebFramework.Domain.Common;

namespace WebFramework.Business.Base
{
    public abstract partial class BusinessEntityBase
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
        /// Get value of property by name, return default of Type if it was not setted
        /// </summary>
        protected T GetValue<T>(string propertyName)
        {
            return this.propertiesValues.ContainsKey(propertyName) ? (T)this.propertiesValues[propertyName] : default(T);
        }

        protected T GetValue<T>(Expression<Func<object>> expression)
        {
            return this.GetValue<T>(ExpressionAssistant.GetPropertyName(expression));
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
            this.SetValue<T>(ExpressionAssistant.GetPropertyName(expression), propertyValue);
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

        public virtual void AddRelationItem(BusinessEntityBase item)
        {
            if (item == this)
            {
                ThrowException.InvalidOperationException("Can not add an item to be its sub items.");
            }

            this.ItemData.AddRelationItem(item.ItemData);
        }

        public virtual void RemoveRelationItem(BusinessEntityBase item)
        {
            this.ItemData.RemoveRelationItem(item.ItemData);
        }

        public virtual void RemoveAllRelationItems()
        {
            this.ItemData.RemoveAllRelationItems();
        }

        public bool GetById(long id)
        {
            ContentItem contentItem = DomainRepositories.ContentItem.GetById(id);
            return this.BuildEntity(contentItem);
        }

        public bool BuildEntity(ContentItem contentItem)
        {
            this.ItemData = contentItem;

            if (this.ItemData == null)
            {
                return false;
            }

            // We always have Encryption attribute, so we have to retrieve it first, then use to decrypt other properties
            var encryptionAttribute = this.ItemData.AttributeValues.First(x => x.ContentAttribute.Code == ExpressionAssistant.GetPropertyName(() => this.Encryption));
            if (encryptionAttribute.Value == null)
            {
                this.Encryption = encryptionAttribute.ValueText.ParseEnum<EncryptionOption>();
            }
            else
            {
                this.Encryption = encryptionAttribute.Value.Value.ParseEnum<EncryptionOption>();
            }

            // Now we load other properties
            foreach (var kvp in this.properties.Where(x => x.Key != ExpressionAssistant.GetPropertyName(() => this.Encryption)))
            {
                var attributeValue = this.ItemData.AttributeValues.FirstOrDefault(x => x.ContentAttribute.Code == kvp.Key);
                if (attributeValue != null)
                {
                    string value = (attributeValue.Value == null) ? attributeValue.ValueText : attributeValue.Value.Value;
                    string decryptedValue = this.DecryptData(value);
                    this.PerformSetValue(kvp.Key, decryptedValue.ConvertFromString(kvp.Value));
                }
            }

            this.UpdateEntityInfo();

            // Okie now
            return true;
        }

        public bool Delete()
        {
            return DomainRepositories.ContentItem.Delete(this.Id);
        }

        public bool Save()
        {
            ContentType contentType = BusinessEntityAssistant.EnsureContentType(this);
            if (contentType == null)
            {
                ThrowException.InvalidOperationException(string.Format("Can not setup for type '{0}'", this.QualifiedTypeName));
            }
            else
            {
                this.ItemData = ContentItem.Factory.Create(this.Name, this.Description, contentType, this.Position);
            }

            // Save values
            if (!DomainRepositories.ContentItem.Save(this.ItemData))
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
                if (kvp.Key != ExpressionAssistant.GetPropertyName(() => this.Encryption))
                {
                    value = this.EncryptData(value);
                }

                var attributeValue = ContentItemAttributeValue.Factory.Create(contentAttribute, value);
                this.ItemData.AddAttributeValue(attributeValue);
            }

            if (!DomainRepositories.ContentItem.Update(this.ItemData))
            {
                return false;
            }

            DomainRepositories.RepositoryAssistant.Flush();
            this.UpdateEntityInfo();

            return true;
        }

        private void UpdateEntityInfo()
        {
            this.Id = this.ItemData.Id;
            this.IsActive = this.ItemData.IsActive;
            this.IsDeletable = this.ItemData.IsDeletable;
            this.IsEditable = this.ItemData.IsEditable;
        }

        #endregion
    }
}
