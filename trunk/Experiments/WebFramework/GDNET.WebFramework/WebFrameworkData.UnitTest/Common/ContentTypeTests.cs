﻿using NUnit.Framework;
using WebFrameworkData.UnitTest.Utils;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkData.UnitTest.Common
{
    [TestFixture]
    public class ContentTypeTests : NUnitBase
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
        public void CanAddContentType()
        {
            string name = "Content type test";
            string typeName = "WebFrameworkData.UnitTest.Common.ContentTypeTests, WebFrameworkData.UnitTest";
            var contentType = AssistantTest.CreateContentType();

            DomainRepositories.ContentType.Save(contentType);
            DomainRepositories.RepositoryAssistant.Flush();

            var savedCT = DomainRepositories.ContentType.GetById(contentType.Id);

            Assert.IsNotNull(savedCT);
            Assert.IsTrue(savedCT.Id > 0);
            Assert.AreEqual(name, savedCT.Name.Value);
            Assert.AreEqual(typeName, savedCT.TypeName);

            DomainRepositories.ContentType.Delete(contentType.Id);
            DomainRepositories.RepositoryAssistant.Flush();
        }

        [Test]
        public void CanAddContentTypeWithContentItems()
        {
            var contentType = AssistantTest.CreateContentType();
            var contentItem = AssistantTest.CreateContentItem("I1", "Item 1", contentType);

            DomainRepositories.RepositoryAssistant.Clear();

            var savedType = DomainRepositories.ContentType.GetById(contentType.Id);

            Assert.IsNotNull(savedType);
            Assert.IsTrue(savedType.ContentItems.Count == 1);
            Assert.AreEqual("I1", savedType.ContentItems[0].Name.Value);
            Assert.AreEqual("Item 1", savedType.ContentItems[0].Description.Value);

            DomainRepositories.ContentItem.Delete(contentItem.Id);
            DomainRepositories.RepositoryAssistant.Flush();

            DomainRepositories.ContentType.Delete(contentType.Id);
            DomainRepositories.RepositoryAssistant.Flush();
        }

        [Test]
        public void CanAddContentTypeWithContentAttributes()
        {
            var contentType = AssistantTest.CreateContentType();
            var listValue = DomainRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            var attribute1 = ContentAttribute.Factory.Create("A1", contentType, listValue, 0);
            var attribute2 = ContentAttribute.Factory.Create("A2", contentType, listValue, 1);
            contentType.AddContentAttribute(attribute1);
            contentType.AddContentAttribute(attribute2);

            DomainRepositories.ContentType.Update(contentType);

            DomainRepositories.ContentType.Delete(contentType.Id);
            DomainRepositories.RepositoryAssistant.Flush();

            Assert.IsNull(DomainRepositories.ContentType.GetById(contentType.Id));
            Assert.IsNull(DomainRepositories.ContentAttribute.GetById(attribute1.Id));
            Assert.IsNull(DomainRepositories.ContentAttribute.GetById(attribute2.Id));
        }

        [Test]
        public void CanDeleteContentType()
        {
            var contentType = AssistantTest.CreateContentType();

            DomainRepositories.ContentType.Delete(contentType.Id);
            DomainRepositories.RepositoryAssistant.Flush();

            var savedCT = DomainRepositories.ContentType.GetById(contentType.Id);
            Assert.IsNull(savedCT);
        }
    }
}