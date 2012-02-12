using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Constants;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkData.UnitTest.Utils
{
    public sealed class AssistantTest
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
            var attribute = ContentAttribute.Factory.Create("T1", type, ListValueConstants.ContentDataTypes.TextSimpleTextBox);

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

    }
}
