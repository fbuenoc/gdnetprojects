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

                var listValue = this.Create();

                listValue.Name = name;
                listValue.CustomValue = customValue;
                listValue.Description = Translation.Factory.Create(description);
                listValue.Parent = null;
                listValue.Application = null;

                return listValue;
            }

            public ListValue Retrieve(string code)
            {
                throw new NotImplementedException();
            }
        }
    }
}
