using System;
using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;

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

            public ListValue Create(string name, string description)
            {
                return this.Create(name, null, description);
            }

            public ListValue Create(string name, string customValue, string description)
            {
                Throw.ArgumentExceptionIfNullOrEmpty(name, "name", "Name of item can not be null.");

                var lv = this.Create();
                lv.Name = name;
                lv.CustomValue = customValue;
                lv.Description = Translation.Factory.Create(Guid.NewGuid().ToString(), description);
                lv.Parent = null;
                lv.Application = null;

                return lv;
            }

            public ListValue Retrieve(string code)
            {
                throw new NotImplementedException();
            }
        }
    }
}
