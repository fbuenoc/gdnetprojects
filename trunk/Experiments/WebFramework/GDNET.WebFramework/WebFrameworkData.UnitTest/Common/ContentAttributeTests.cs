using NUnit.Framework;
using WebFrameworkData.UnitTest.Utils;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Constants;
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

        #region Factory Tests

        [Test]
        public void FactoryCreateTest()
        {
            var attribute = ContentAttribute.Factory.Create();

            Assert.AreEqual(true, attribute.IsActive);
            Assert.AreEqual(true, attribute.IsDeletable);
            Assert.AreEqual(true, attribute.IsEditable);
            Assert.AreEqual(true, attribute.IsViewable);
            VerificationAssistant.EmptyCreMod(attribute);
        }

        #endregion

        [Test]
        public void CanAddContentAttribute()
        {
            var contentType = AssistantTest.CreateContentType();
            var attribute = ContentAttribute.Factory.Create("T1", contentType, ListValueConstants.ContentDataTypes.TextSimpleTextBox);

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
            var attribute = ContentAttribute.Factory.Create("T1", type, ListValueConstants.ContentDataTypes.TextSimpleTextBox);

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
