using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFrameworkDomain.Common.Business
{
    public abstract class ContentAttributeBase
    {
        public ContentAttributeBase(string code, string dataTypeCode)
            : this(code, dataTypeCode, 0)
        {
        }

        public ContentAttributeBase(string code, string dataTypeCode, int position)
        {
            this.Code = code;
            this.DataTypeCode = dataTypeCode;
            this.Position = position;
        }

        public string Code
        {
            get;
            protected set;
        }

        public string DataTypeCode
        {
            get;
            protected set;
        }

        public int Position
        {
            get;
            protected set;
        }
    }
}
