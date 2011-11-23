using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class ListValue
    {
        public static ListValueFactory Factory
        {
            get { return new ListValueFactory(); }
        }

        public class ListValueFactory
        {
            /// <summary>
            /// Create a category with default values
            /// </summary>
            /// <returns></returns>
            public ListValue Create()
            {
                ListValue c = new ListValue
                {
                    IsActive = true,
                    IsDeletable = true,
                    IsEditable = true,
                };

                return c;
            }
        }
    }
}
