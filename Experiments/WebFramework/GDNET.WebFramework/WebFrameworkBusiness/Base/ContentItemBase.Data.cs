using System;
using System.Collections.Generic;

using GDNET.Common.Security.Services;

using WebFrameworkDomain.Common;

namespace WebFrameworkBusiness.Base
{
    public abstract partial class ContentItemBase : ContentItem
    {
        private const string PropertyEncryptionOption = "EncryptionOption";
        private const string PropertyName = "Name";
        private const string PropertyDescription = "Description";
        private const string PropertyPosition = "Position";

        private Dictionary<string, Type> properties = new Dictionary<string, Type>();
        private Dictionary<string, object> propertiesValues = new Dictionary<string, object>();

        #region Properties

        public string QualifiedTypeName
        {
            get
            {
                int firstIndex = this.GetType().AssemblyQualifiedName.IndexOf(",") + 1;
                return this.GetType().AssemblyQualifiedName.Substring(0, this.GetType().AssemblyQualifiedName.IndexOf(",", firstIndex));
            }
        }

        #endregion

        #region Ctors

        public ContentItemBase(string name, string description)
            : this(name, description, int.MinValue)
        {
        }

        public ContentItemBase(string name, string description, int position)
            : this(name, description, position, EncryptionOption.None)
        {
        }

        public ContentItemBase(string name, string description, EncryptionOption encryption)
            : this(name, description, int.MinValue, encryption)
        {
        }

        public ContentItemBase(string name, string description, int position, EncryptionOption encryption)
        {
            this.RegisterProperty(PropertyName, typeof(string));
            this.RegisterProperty(PropertyDescription, typeof(string));
            this.RegisterProperty(PropertyPosition, typeof(int));
            this.RegisterProperty(PropertyEncryptionOption, typeof(EncryptionOption));

            this.SetValue<string>(PropertyName, name);
            this.SetValue<string>(PropertyDescription, description);
            this.SetValue<int>(PropertyPosition, position);
            this.SetValue<EncryptionOption>(PropertyEncryptionOption, encryption);
        }

        #endregion
    }
}
