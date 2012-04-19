using WebFramework.Domain.Base;

namespace WebFramework.Domain.Common
{
    public class DTOContentItem : DTOEntityBase<long>
    {
        public string Name
        {
            get;
            protected set;
        }

        public string Description
        {
            get;
            protected set;
        }

        public int Position
        {
            get;
            protected set;
        }

        public long Views
        {
            get;
            protected set;
        }

        public bool IsActive
        {
            get;
            protected set;
        }

        public bool IsEditable
        {
            get;
            protected set;
        }

        public bool IsDeletable
        {
            get;
            protected set;
        }

        public override void BuildDTO(object[] objects)
        {
            this.Id = (long)objects[0];
        }
    }
}
