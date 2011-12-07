using System;
using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;
using WebFrameworkDomain.DefaultImpl;

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
                return this.Create(name, description, null);
            }

            public ListValue Create(string name, string description, string customValue)
            {
                return this.Create(name, description, customValue, 0);
            }

            public ListValue Create(string name, string description, string customValue, long parentId)
            {
                Throw.ArgumentExceptionIfNullOrEmpty(name, "name", "Name of item can not be null.");

                var listValue = this.Create();

                listValue.Name = name;
                listValue.CustomValue = customValue;
                listValue.Description = Translation.Factory.Create(description);
                listValue.Parent = (parentId <= 0) ? null : DomainRepositories.ListValue.GetById(parentId);
                listValue.Application = null;

                return listValue;
            }
        }
    }
}
