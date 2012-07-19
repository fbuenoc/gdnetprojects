using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Content
{
    public partial class ContentItem : EntityHistoryComplex
    {
        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual string Keywords
        {
            get;
            set;
        }
    }
}
