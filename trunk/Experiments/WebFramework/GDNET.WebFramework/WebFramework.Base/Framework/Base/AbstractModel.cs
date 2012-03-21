using System;

namespace WebFramework.Base.Framework.Base
{
    public abstract class AbstractModel
    {
        protected object id
        {
            get;
            set;
        }

        public Guid ModelId
        {
            get;
            private set;
        }

        public AbstractModel()
        {
            this.ModelId = Guid.NewGuid();
        }
    }
}
