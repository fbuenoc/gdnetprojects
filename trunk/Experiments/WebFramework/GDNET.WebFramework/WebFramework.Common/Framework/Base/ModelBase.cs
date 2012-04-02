using System;

namespace WebFramework.Common.Framework.Base
{
    public abstract class ModelBase
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

        public ModelBase()
        {
            this.ModelId = Guid.NewGuid();
        }
    }
}
