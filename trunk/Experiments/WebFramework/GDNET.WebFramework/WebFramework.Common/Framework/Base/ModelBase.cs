using System;

namespace WebFramework.Common.Framework.Base
{
    public abstract class ModelBase
    {
        public object EntityId
        {
            get;
            protected set;
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
