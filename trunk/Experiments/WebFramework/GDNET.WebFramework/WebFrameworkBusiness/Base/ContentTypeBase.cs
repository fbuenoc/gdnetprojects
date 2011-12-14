using System;
using System.Collections.Generic;
using System.Linq;

using GDNET.Common.DesignByContract;
using GDNET.Extensions;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Constants;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkBusiness.Base
{
    public abstract class ContentTypeBase
    {
        private const string PropertyName = "Name";
        private const string PropertyDescription = "Description";

        private Dictionary<string, Type> properties = new Dictionary<string, Type>();
        private Dictionary<string, object> propertiesValues = new Dictionary<string, object>();

        #region Properties

        public string TypeName
        {
            get { return this.GetType().AssemblyQualifiedName; }
        }

        public long Id
        {
            get;
            private set;
        }

        public virtual string Name
        {
            get { return this.GetValue<string>(PropertyName); }
            set { this.SetValue<string>(PropertyName, value); }
        }

        public virtual string Description
        {
            get { return this.GetValue<string>(PropertyDescription); }
            set { this.SetValue<string>(PropertyDescription, value); }
        }

        #endregion

        public ContentTypeBase()
        {
            this.RegisterProperty(PropertyName, typeof(string));
            this.RegisterProperty(PropertyDescription, typeof(string));
        }

        #region Methods

        protected T GetValue<T>(string propertyName)
        {
            return this.propertiesValues.ContainsKey(propertyName) ? (T)this.propertiesValues[propertyName] : default(T);
        }

        protected void SetValue<T>(string propertyName, T propertyValue)
        {
            string msg1 = string.Format("Property '{0}' is not registered.", propertyName);
            Throw.InvalidOperationExceptionIfFalse(this.properties.ContainsKey(propertyName), msg1);

            string msg2 = string.Format("Type of property '{0}' must be '{1}'.", propertyName, this.properties[propertyName].FullName);
            Throw.InvalidOperationExceptionIfFalse(this.properties[propertyName].Equals(typeof(T)), msg2);

            this.PerformSetValue(propertyName, propertyValue);
        }

        protected void RegisterProperty(string propertyName, Type dataType)
        {
            this.properties.Add(propertyName, dataType);
        }

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

        #endregion

        #region Public Methods

        public bool LoadItemById(long id)
        {
            var contentItem = DomainRepositories.ContentItem.GetById(id);
            if (contentItem != null)
            {
                foreach (var kvp in this.properties)
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
                                object objet = attributeValue.Value.Value.ConvertFromString(kvp.Value);
                                this.PerformSetValue(kvp.Key, objet);
                            }
                            break;
                    }
                }

                return true;
            }

            return false;
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
                    Throw.InvalidOperationException(string.Format("Property '{0}' is not found, you must re-config this content type", kvp.Key));
                }

                var attributeValue = ContentItemAttributeValue.Factory.Create(contentAttribute, contentItem, kvp.Value.ConvertToString(this.properties[kvp.Key]));
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
