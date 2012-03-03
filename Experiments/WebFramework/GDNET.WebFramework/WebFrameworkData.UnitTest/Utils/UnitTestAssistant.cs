using WebFrameworkBusiness.Common;
using WebFrameworkBusiness.Helpers;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkData.UnitTest.Utils
{
    public sealed class UnitTestAssistant
    {
        public static ContentType CreateContentType()
        {
            string name = "Content type test";
            string typeName = "WebFrameworkData.UnitTest.Common.ContentTypeTests, WebFrameworkData.UnitTest";
            var type = ContentType.Factory.Create(name, typeName);

            DomainRepositories.ContentType.Save(type);
            DomainRepositories.RepositoryAssistant.Flush();

            return type;
        }

        public static ContentAttribute CreateContentAttribute()
        {
            var type = CreateContentType();
            var listValue = DomainRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            var attribute = ContentAttribute.Factory.Create("A1", "Attribute 1", type, listValue, 1);

            DomainRepositories.ContentAttribute.Save(attribute);
            DomainRepositories.RepositoryAssistant.Flush();

            return attribute;
        }

        public static ContentItem CreateContentItem(string name, string description, ContentType type)
        {
            var item = ContentItem.Factory.Create(name, description, type);

            DomainRepositories.ContentItem.Save(item);
            DomainRepositories.RepositoryAssistant.Flush();

            return item;
        }

        public static ListValue CreateListValue(string name)
        {
            var lv = ListValue.Factory.Create(name, string.Empty);
            DomainRepositories.ListValue.Save(lv);
            DomainRepositories.RepositoryAssistant.Flush();

            return lv;
        }

        public static void EnsureContentTypes()
        {
            Comment cm1 = Comment.Factory.NewInstance();
            BusinessEntityAssistant.EnsureContentType(cm1);

            Article a1 = Article.Factory.NewInstance();
            BusinessEntityAssistant.EnsureContentType(a1);
        }

    }
}
