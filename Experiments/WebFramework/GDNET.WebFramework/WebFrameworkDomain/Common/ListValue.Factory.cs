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
                ThrowException.ArgumentExceptionIfNullOrEmpty(name, "name", "Name of item can not be null.");

                var listValue = new ListValue
                {
                    Name = name,
                    CustomValue = customValue,
                };

                listValue.Description = Translation.Factory.Create(description);
                listValue.Parent = (parentId <= 0) ? null : DomainRepositories.ListValue.GetById(parentId);
                listValue.LifeCycle.AddStatutLog(StatutLog.Factory.Create("BF"));

                return listValue;
            }

            internal ListValue NewInstance()
            {
                return new ListValue();
            }
        }
    }
}
