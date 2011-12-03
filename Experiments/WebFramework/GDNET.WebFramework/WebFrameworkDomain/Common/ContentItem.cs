using System.Collections.Generic;
using System.Collections.ObjectModel;

using GDNET.Common.Base.Entities;

using WebFrameworkDomain.Extensions;

namespace WebFrameworkDomain.Common
{
    public partial class ContentItem : EntityFullControlBase<long>
    {
        private IList<ContentItemAttributeValue> attributeValues = new List<ContentItemAttributeValue>();

        #region Properties

        public virtual ContentType ContentType
        {
            get;
            set;
        }

        public virtual Translation Name
        {
            get;
            set;
        }

        public virtual Translation Description
        {
            get;
            set;
        }

        public virtual int Position
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<ContentItemAttributeValue> AttributeValues
        {
            get { return new ReadOnlyCollection<ContentItemAttributeValue>(this.attributeValues); }
        }

        #endregion

        #region Methods

        public virtual void AddAttributeValue(ContentItemAttributeValue attributeValue)
        {
            if (this.attributeValues.Contains(attributeValue))
            {
                return;
            }

            attributeValue.ContentItem = this;
            this.attributeValues.Add(attributeValue);
        }

        public virtual void RemoveAttributeValue(ContentItemAttributeValue attributeValue)
        {
            if (this.attributeValues.Contains(attributeValue))
            {
                this.attributeValues.Remove(attributeValue);
            }
        }

        public virtual void RemoveAllAttributeValues()
        {
            this.attributeValues.Clear();
        }

        #endregion

        protected ContentItem() { }

    }
}
