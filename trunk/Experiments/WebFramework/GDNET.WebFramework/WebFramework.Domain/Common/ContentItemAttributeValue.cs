using GDNET.Common.Base.Entities;

namespace WebFramework.Domain.Common
{
    public partial class ContentItemAttributeValue : EntityBase<long>
    {
        #region Properties

        public virtual ContentAttribute ContentAttribute
        {
            get;
            set;
        }

        public virtual ContentItem ContentItem
        {
            get;
            set;
        }

        public virtual Translation ValueTranslation
        {
            get;
            protected internal set;
        }

        public virtual string ValueText
        {
            get;
            protected internal set;
        }

        public virtual void SetValueTranslation(Translation value)
        {
            this.ValueText = null;
            this.ValueTranslation = value;
        }

        public virtual void SetValueText(string value)
        {
            this.ValueText = value;
            this.ValueTranslation = null;
        }

        #endregion

        protected ContentItemAttributeValue() { }
    }
}
