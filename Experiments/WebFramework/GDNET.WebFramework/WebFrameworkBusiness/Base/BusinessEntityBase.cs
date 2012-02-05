using System;
using System.Collections.Generic;
using GDNET.Common.Base.Entities;
using GDNET.Common.Security.Services;
using GDNET.Extensions;
using WebFrameworkDomain.Common;

namespace WebFrameworkBusiness.Base
{
    public abstract partial class BusinessEntityBase : EntityWithFullInfoBase<long>
    {
        private Dictionary<string, Type> properties = new Dictionary<string, Type>();
        private Dictionary<string, object> propertiesValues = new Dictionary<string, object>();

        private ContentItem contentItem = null;

        #region Properties

        public string QualifiedTypeName
        {
            get
            {
                int firstIndex = this.GetType().AssemblyQualifiedName.IndexOf(",") + 1;
                return this.GetType().AssemblyQualifiedName.Substring(0, this.GetType().AssemblyQualifiedName.IndexOf(",", firstIndex));
            }
        }

        protected EncryptionOption Encryption
        {
            get { return this.GetValue<EncryptionOption>(() => this.Encryption); }
            set { this.SetValue<EncryptionOption>(() => this.Encryption, value); }
        }

        public string Name
        {
            get { return this.GetValue<string>(() => this.Name); }
            set { this.SetValue<string>(() => this.Name, value); }
        }

        public string Description
        {
            get { return this.GetValue<string>(() => this.Description); }
            set { this.SetValue<string>(() => this.Description, value); }
        }

        public int Position
        {
            get { return this.GetValue<int>(() => this.Position); }
            set { this.SetValue<int>(() => this.Position, value); }
        }

        #endregion

        #region Ctors

        public BusinessEntityBase()
            : this(EncryptionOption.None)
        {
        }

        public BusinessEntityBase(EncryptionOption encryption)
        {
            foreach (var kvp in ReflectionAssistant.GetProperties(this.GetType()))
            {
                this.RegisterProperty(kvp.Key, kvp.Value);
            }

            this.Encryption = encryption;
        }

        #endregion
    }
}
