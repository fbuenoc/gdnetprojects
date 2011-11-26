using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class ContentAttribute : EntityFullControlBase<long>
    {
        #region Properties

        public virtual ContentType ContentType
        {
            get;
            set;
        }

        public virtual ListValue DataType
        {
            get;
            set;
        }

        public virtual string Code
        {
            get;
            set;
        }

        public virtual int Position
        {
            get;
            set;
        }

        #endregion

        protected ContentAttribute() { }
    }
}
