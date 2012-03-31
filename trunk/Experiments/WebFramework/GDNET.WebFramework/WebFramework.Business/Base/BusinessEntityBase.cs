using System;
using System.Collections.Generic;
using System.Linq;
using GDNET.Common.Base.Entities;
using GDNET.Common.Helpers;
using GDNET.Common.Security.Services;
using GDNET.Extensions;
using WebFramework.Domain.Common;

namespace WebFramework.Business.Base
{
    public abstract partial class BusinessEntityBase : EntityWithModification<long>
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

        protected BusinessEntityBase()
            : this(EncryptionOption.None)
        {
        }

        protected BusinessEntityBase(EncryptionOption encryption)
        {
            this.Encryption = encryption;
            this.RegisterProperties();
        }

        #endregion

        protected virtual IList<string> BaseProperties
        {
            get
            {
                List<string> baseProperties = new List<string>();
                baseProperties.Add(ExpressionAssistant.GetPropertyName(() => this.Id));
                baseProperties.Add(ExpressionAssistant.GetPropertyName(() => this.FieldNameEncryption));
                baseProperties.Add(ExpressionAssistant.GetPropertyName(() => this.FieldNameItemData));
                baseProperties.Add(ExpressionAssistant.GetPropertyName(() => this.FieldNameProperties));
                baseProperties.Add(ExpressionAssistant.GetPropertyName(() => this.QualifiedTypeName));
                baseProperties.Add(ExpressionAssistant.GetPropertyName(() => this.Name));
                baseProperties.Add(ExpressionAssistant.GetPropertyName(() => this.Description));
                baseProperties.Add(ExpressionAssistant.GetPropertyName(() => this.Position));
                baseProperties.Add(ExpressionAssistant.GetPropertyName(() => this.IsActive));
                baseProperties.Add(ExpressionAssistant.GetPropertyName(() => this.IsDeletable));
                baseProperties.Add(ExpressionAssistant.GetPropertyName(() => this.IsEditable));
                baseProperties.Add(ExpressionAssistant.GetPropertyName(() => this.Signature));
                return baseProperties;
            }
        }

        private void RegisterProperties()
        {
            var neededProperties = ReflectionAssistant.GetProperties(this.GetType()).Where(x => !this.BaseProperties.Contains(x.Key)).ToList();
            foreach (var kvp in neededProperties)
            {
                this.RegisterProperty(kvp.Key, kvp.Value);
            }
        }

    }
}
