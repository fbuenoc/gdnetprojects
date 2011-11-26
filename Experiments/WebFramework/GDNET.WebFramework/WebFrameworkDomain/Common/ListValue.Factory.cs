using System;
using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class ListValue
    {
        public static ListValueFactory Factory
        {
            get { return new ListValueFactory(); }
        }

        public sealed class ListValueFactory
        {
            /// <summary>
            /// Create a category with default values
            /// </summary>
            /// <returns></returns>
            public ListValue Create()
            {
                ListValue lv = new ListValue
                {
                    IsActive = true,
                    IsDeletable = true,
                    IsEditable = true,
                    IsViewable = true,
                };

                return lv;
            }

            public ListValue Retrieve(string code)
            {
                throw new NotImplementedException();
            }
        }
    }
}
