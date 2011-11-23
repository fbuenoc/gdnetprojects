using System;
using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class Temporary : EntityCreModBase<string>
    {
        public virtual string Text
        {
            get;
            set;
        }

        protected Temporary() { }
    }
}
