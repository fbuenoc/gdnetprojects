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

            var savedCT = DomainRepositories.ContentType.GetById(contentType.Id);

            Assert.IsNotNull(savedCT);
            Assert.IsTrue(savedCT.Id > 0);
            Assert.AreEqual(name, savedCT.Name.Value);
            Assert.AreEqual(typeName, savedCT.TypeName);

            DomainRepositories.ContentType.Delete(contentType);
            DomainRepositories.ContentType.Synchronize();
        }

        [Test]
        public void CanAddContentTypeWithContentItems()
        {
            var contentType = AssistantTest.CreateContentType();
            var contentItem = AssistantTest.CreateContentItem("I1", "Item 1", contentType);

            var savedType = DomainRepositories.ContentType.GetById(contentType.Id);

            try
            {
                Assert.IsNotNull(savedType);
                Assert.IsTrue(savedType.ContentItems.Count == 1);
            }
            catch (Exception ex)
            {
            }

            DomainRepositories.ContentItem.Delete(contentItem);
            DomainRepositories.ContentType.Delete(contentType);
            DomainRepositories.ContentType.Synchronize();
        }

        [Test]
        public void CanDeleteContentType()
        {
            var contentType = AssistantTest.CreateContentType();

            DomainRepositories.ContentType.Save(contentType);
            DomainRepositories.ContentType.Synchronize();

            DomainRepositories.ContentType.Delete(contentType);
            DomainRepositories.ContentType.Synchronize();

            var savedCT = DomainRepositories.ContentType.GetById(contentType.Id);
            Assert.IsNull(savedCT);
        }
    }
}
