﻿using NUnit.Framework;
using WebFrameworkData.UnitTest.Utils;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkData.UnitTest.Common
{
    [TestFixture]
    public class ContentAttributeTests : NUnitBase
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            base.Init();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            base.Clean();
        }

        [Test]
        public void CanAddContentAttribute()
        {
            var contentType = AssistantTest.CreateContentType();
            var listValue = DomainRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            var attribute = ContentAttribute.Factory.Create("T1", contentType, listValue, 0);

            DomainRepositories.ContentAttribute.Save(attribute);
            DomainRepositories.RepositoryAssistant.Flush();
            DomainRepositories.RepositoryAssistant.Clear();

            var myAttribute = DomainRepositories.ContentAttribute.GetById(attribute.Id);
            Assert.IsNotNull(myAttribute);
            Assert.AreEqual(attribute.Id, myAttribute.Id);
            Assert.AreEqual("T1", myAttribute.Code);
            Assert.AreEqual(contentType.TypeName, myAttribute.ContentType.TypeName);
            Assert.AreEqual(ListValueConstants.ContentDataTypes.TextSimpleTextBox, myAttribute.DataType.Name);

            DomainRepositories.ContentAttribute.Delete(attribute.Id);
            DomainRepositories.RepositoryAssistant.Flush();

            DomainRepositories.ContentType.Delete(contentType.Id);
            DomainRepositories.RepositoryAssistant.Flush();
        }

        [Test]
        public void CanDeleteContentAttribute()
        {
            var type = AssistantTest.CreateContentType();
            var listValue = DomainRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            var attribute = ContentAttribute.Factory.Create("T1", type, listValue, 0);

            DomainRepositories.ContentAttribute.Save(attribute);
            DomainRepositories.RepositoryAssistant.Flush();
            DomainRepositories.RepositoryAssistant.Clear();

            DomainRepositories.ContentAttribute.Delete(attribute.Id);
            DomainRepositories.RepositoryAssistant.Flush();

            var savedAttribute = DomainRepositories.ContentAttribute.GetById(attribute.Id);
            Assert.IsNull(savedAttribute);

            DomainRepositories.ContentType.Delete(type.Id);
            DomainRepositories.RepositoryAssistant.Flush();
        }
    }
}