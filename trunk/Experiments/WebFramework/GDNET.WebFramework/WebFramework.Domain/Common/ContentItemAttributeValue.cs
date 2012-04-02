using GDNET.Common.Base.Entities;

namespace WebFramework.Domain.Common
{
    public partial class ContentItemAttributeValue : EntityBase<long>
    {
        private string valueText = null;
        private Translation valueTranslation = null;

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

        public virtual Translation Value
        {
            get { return this.valueTranslation; }
            set
            {
                this.valueText = null;
                this.valueTranslation = value;
            }
        }

        public virtual string ValueText
        {
            get { return this.valueText; }
            set
            {
                this.valueText = value;
                this.valueTranslation = null;
            }
        }

        #endregion

        protected ContentItemAttributeValue() { }
    }
}
