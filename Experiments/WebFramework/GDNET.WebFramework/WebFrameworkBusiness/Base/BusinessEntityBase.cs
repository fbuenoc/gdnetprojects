using System;
using System.Collections.Generic;
using GDNET.Common.Base.Entities;
using GDNET.Common.Helpers;
using GDNET.Common.Security.Services;
using GDNET.Extensions;
using WebFrameworkDomain.Common;

namespace WebFrameworkBusiness.Base
{
    public abstract partial class BusinessEntityBase : EntityWithModificationBase<long>
    {
        private Dictionary<string, Type> properties = new Dictionary<string, Type>();
        private Dictionary<string, object> propertiesValues = new Dictionary<string, object>();

        #region Field names

        public string FieldNameItemData
        {
            get { return ExpressionAssistant.GetPropertyName(() => this.ItemData); }
        }

        public string FieldNameEncryption
        {
            get { return ExpressionAssistant.GetPropertyName(() => this.Encryption); }
        }

        public string FieldNameProperties
        {
            get { return ExpressionAssistant.GetPropertyName(() => this.properties); }
        }

        #endregion

        #region Properties

        protected ContentItem ItemData
        {
            get;
            set;
        }

        public string QualifiedTypeName
        {
            get { return this.GetType().GetQualifiedTypeName(); }
        }

        protected EncryptionOption Encryption
        {
            get { return this.GetValue<EncryptionOption>(() => this.Encryption); }
            set { this.SetValue<EncryptionOption>(() => this.Encryption, value); }
        }

        public string Name
        {
            get { return this.ItemData.Name.Value; }
            set
            {
                if (this.ItemData.Name == null)
                {
                    this.ItemData.Name = Translation.Factory.Create(value);
                }
                this.ItemData.Name.Value = value;
            }
        }

        public string Description
        {
            get { return this.ItemData.Description.Value; }
            set
            {
                if (this.ItemData.Description == null)
                {
                    this.ItemData.Description = Translation.Factory.Create(value);
                }
                this.ItemData.Description.Value = value;
            }
        }

        public int Position
        {
            get { return this.ItemData.Position; }
            set { this.ItemData.Position = value; }
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
