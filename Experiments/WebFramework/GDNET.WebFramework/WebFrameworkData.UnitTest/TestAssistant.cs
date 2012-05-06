using WebFramework.Domain;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;

namespace WebFrameworkData.UnitTest
{
    public static class TestAssistant
    {
        public static void CreateCultures()
        {
            if (DomainRepositories.Culture.GetAll().Count == 0)
            {
                var c1 = Culture.Factory.Create("en-US");
                DomainRepositories.Culture.Save(c1);

                var c2 = Culture.Factory.Create("vi-VN");
                DomainRepositories.Culture.Save(c2);
            }
        }

        public static void CreateListValues()
        {
            if (DomainRepositories.ListValue.GetAll().Count == 0)
            {
                var L1 = ListValue.Factory.Create(ListValueConstants.ContentDataTypes.TextSimpleTextBox, "TextSimpleTextBox");
                DomainRepositories.ListValue.Save(L1);
            }
        }
    }
}
