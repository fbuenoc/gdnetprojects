using System;
using System.Collections.Generic;
using System.Linq;

using GDNET.Common.DesignByContract;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Constants;
using WebFrameworkDomain.DefaultImpl;
using GDNET.Common.Security.Services;

namespace WebFrameworkBusiness.Base
{
    public abstract partial class ContentItemBase
    {
        private const string PropertyName = "Name";
        private const string PropertyDescription = "Description";
        private const string PropertyEncryptionOption = "EncryptionOption";

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

        #region Ctors

        public ContentItemBase()
            : this(EncryptionOption.None)
        {
        }

        public ContentItemBase(EncryptionOption encryption)
        {
            this.RegisterProperty(PropertyName, typeof(string));
            this.RegisterProperty(PropertyDescription, typeof(string));
            this.RegisterProperty(PropertyEncryptionOption, typeof(EncryptionOption));

            this.SetValue<EncryptionOption>(PropertyEncryptionOption, encryption);
        }

        #endregion

        #region Methods

        protected T GetValue<T>(string propertyName)
        {
            return this.propertiesValues.ContainsKey(propertyName) ? (T)this.propertiesValues[propertyName] : default(T);
        }

        protected void SetValue<T>(string propertyName, T propertyValue)
        {
            string msg1 = string.Format("Property '{0}' is not registered.", propertyName);
            ThrowException.InvalidOperationExceptionIfFalse(this.properties.ContainsKey(propertyName), msg1);

            string msg2 = string.Format("Type of property '{0}' must be '{1}'.", propertyName, this.properties[propertyName].FullName);
            ThrowException.InvalidOperationExceptionIfFalse(this.properties[propertyName].Equals(typeof(T)), msg2);

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

        #endregion
    }
}
