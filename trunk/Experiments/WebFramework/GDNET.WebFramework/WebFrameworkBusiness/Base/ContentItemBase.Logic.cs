using System;
using System.Collections.Generic;
using System.Linq;

using GDNET.Common.DesignByContract;
using GDNET.Common.Encryption;
using GDNET.Common.Security.Services;
using GDNET.Extensions;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Constants;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkBusiness.Base
{
    public abstract partial class ContentItemBase
    {
        private readonly IEncryptionService encryptor = new EncryptionService();

        private string EncryptData(string plainText)
        {
            var encryptionOption = (EncryptionOption)this.propertiesValues.First(x => x.Key == PropertyEncryptionOption).Value;
            return this.encryptor.Encrypt(plainText, encryptionOption);
        }

        private string DecryptData(string encryptedText)
        {
            var encryptionOption = (EncryptionOption)this.propertiesValues.First(x => x.Key == PropertyEncryptionOption).Value;
            return this.encryptor.Decrypt(encryptedText, encryptionOption);
        }

        /// <summary>
        /// Find content type, create new ContentType and its attributes if not found an expected CT
        /// </summary>
        private bool EnsureContentType(out ContentType contentType)
        {
            contentType = DomainRepositories.ContentType.FindByTypeName(this.TypeName);

            if (contentType == null)
            {
                contentType = ContentType.Factory.Create(this.GetType().Name, this.TypeName);
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

        #region Public Methods

        public bool LoadItemById(long id)
        {
            var contentItem = DomainRepositories.ContentItem.GetById(id);
            if (contentItem != null)
            {
                // We always have Encryption attribute, so we have to retrieve it first, then use to decrypt other properties
                var encryptionAttribute = contentItem.AttributeValues.First(x => x.ContentAttribute.Code == PropertyEncryptionOption);
                var encryptionOption = encryptionAttribute.Value.Value.ParseEnum<EncryptionOption>();
                this.SetValue<EncryptionOption>(PropertyEncryptionOption, encryptionOption);

                // Now we load other properties
                foreach (var kvp in this.properties.Where(x => x.Key != PropertyEncryptionOption))
                {
                    switch (kvp.Key)
                    {
                        case PropertyName:
                            this.SetValue<string>(kvp.Key, contentItem.Name.Value);
                            break;
                        case PropertyDescription:
                            this.SetValue<string>(kvp.Key, contentItem.Description.Value);
                            break;
                        default:
                            var attributeValue = contentItem.AttributeValues.FirstOrDefault(x => x.ContentAttribute.Code == kvp.Key);
                            if (attributeValue != null)
                            {
                                var decryptedValue = this.DecryptData(attributeValue.Value.Value);
                                this.PerformSetValue(kvp.Key, decryptedValue.ConvertFromString(kvp.Value));
                            }
                            break;
                    }
                }

                this.Id = contentItem.Id;
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
            if (this.EnsureContentType(out contentType) == false)
            {
                return false;
            }

            // Save values
            var contentItem = ContentItem.Factory.Create(this.Name, this.Description, contentType);
            if (!DomainRepositories.ContentItem.Save(contentItem))
            {
                return false;
            }

            foreach (var kvp in this.propertiesValues.Where(k => !k.Key.In(PropertyName, PropertyDescription)))
            {
                var contentAttribute = contentType.ContentAttributes.FirstOrDefault(x => (x.Code == kvp.Key));
                if (contentAttribute == null)
                {
                    ThrowException.InvalidOperationException(string.Format("Property '{0}' is not found, you must re-config this content type", kvp.Key));
                }

                string value = kvp.Value.ConvertToString(this.properties[kvp.Key]);
                if (kvp.Key != PropertyEncryptionOption)
                {
                    value = this.EncryptData(value);
                }

                var attributeValue = ContentItemAttributeValue.Factory.Create(contentAttribute, contentItem, value);
                contentItem.AddAttributeValue(attributeValue);
            }

            if (!DomainRepositories.ContentItem.Update(contentItem))
            {
                return false;
            }

            DomainRepositories.ContentItem.Synchronize();
            this.Id = contentItem.Id;

            return true;
        }

        #endregion
    }
}
