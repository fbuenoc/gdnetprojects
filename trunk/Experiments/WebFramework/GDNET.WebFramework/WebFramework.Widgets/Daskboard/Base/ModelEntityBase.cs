using System;

namespace WebFramework.Widgets.Daskboard.Base
{
    public abstract class ModelEntityBase
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

        public ModelEntityBase()
        {
            this.ModelId = Guid.NewGuid();
        }
    }
}
