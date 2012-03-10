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

        public virtual Translation Value
        {
            get;
            set;
        }

        #endregion

        protected ContentItemAttributeValue() { }
    }
}
