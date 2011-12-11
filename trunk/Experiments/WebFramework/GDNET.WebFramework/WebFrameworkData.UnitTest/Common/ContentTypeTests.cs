using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using WebFrameworkDomain;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Constants;
using WebFrameworkDomain.DefaultImpl;
using WebFrameworkData.UnitTest.Utils;

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

        #region Factory Tests

        [Test]
        public void FactoryCreateTest()
        {
            var ct = ContentType.Factory.Create();

            Assert.AreEqual(true, ct.IsActive);
            Assert.AreEqual(true, ct.IsDeletable);
            Assert.AreEqual(true, ct.IsEditable);
            Assert.AreEqual(true, ct.IsViewable);
            VerificationUtils.EmptyCreMod(ct);
        }

        #endregion

        [Test]
        public void CanAddContentType()
        {
            string name = "Content type test";
            string typeName = "WebFrameworkData.UnitTest.Common.ContentTypeTests, WebFrameworkData.UnitTest";
            var contentType = AssistantTest.CreateContentType();

            DomainRepositories.ContentType.Save(contentType);
            DomainRepositories.ContentType.Synchronize();
            DomainRepositories.ContentType.Clear();

            var savedCT = DomainRepositories.ContentType.GetById(contentType.Id);

            Assert.IsNotNull(savedCT);
            Assert.IsTrue(savedCT.Id > 0);
            Assert.AreEqual(name, savedCT.Name.Value);
            Assert.AreEqual(typeName, savedCT.TypeName);

            DomainRepositories.ContentType.Delete(contentType.Id);
            DomainRepositories.ContentType.Synchronize();
        }

        [Test]
        public void CanAddContentTypeWithContentItems()
        {
            var contentType = AssistantTest.CreateContentType();
            var contentItem = AssistantTest.CreateContentItem("I1", "Item 1", contentType);

            DomainRepositories.ContentType.Clear();
            var savedType = DomainRepositories.ContentType.GetById(contentType.Id);

            Assert.IsNotNull(savedType);
            Assert.IsTrue(savedType.ContentItems.Count == 1);
            Assert.AreEqual("I1", savedType.ContentItems[0].Name.Value);
            Assert.AreEqual("Item 1", savedType.ContentItems[0].Description.Value);

            DomainRepositories.ContentItem.Delete(contentItem.Id);
            DomainRepositories.ContentItem.Synchronize();

            DomainRepositories.ContentType.Delete(contentType.Id);
            DomainRepositories.ContentType.Synchronize();
        }

        [Test]
        public void CanAddContentTypeWithContentAttributes()
        {
            var contentType = AssistantTest.CreateContentType();

            var attribute1 = ContentAttribute.Factory.Create("A1", contentType, ListValueConstants.ContentDataTypes_Text_SimpleTextBox);
            var attribute2 = ContentAttribute.Factory.Create("A2", contentType, ListValueConstants.ContentDataTypes_Text_SimpleTextBox);
            contentType.AddContentAttribute(attribute1);
            contentType.AddContentAttribute(attribute2);

            DomainRepositories.ContentType.Update(contentType);
            DomainRepositories.ContentType.Clear();

            DomainRepositories.ContentType.Delete(contentType.Id);
            DomainRepositories.ContentType.Synchronize();

            Assert.IsNull(DomainRepositories.ContentType.GetById(contentType.Id));
            Assert.IsNull(DomainRepositories.ContentAttribute.GetById(attribute1.Id));
            Assert.IsNull(DomainRepositories.ContentAttribute.GetById(attribute2.Id));
        }

        [Test]
        public void CanDeleteContentType()
        {
            var contentType = AssistantTest.CreateContentType();

            DomainRepositories.ContentType.Clear();

            DomainRepositories.ContentType.Delete(contentType.Id);
            DomainRepositories.ContentType.Synchronize();

            var savedCT = DomainRepositories.ContentType.GetById(contentType.Id);
            Assert.IsNull(savedCT);
        }
    }
}
