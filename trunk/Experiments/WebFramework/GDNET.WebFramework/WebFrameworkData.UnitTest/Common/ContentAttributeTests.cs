using NUnit.Framework;
using WebFramework.Data.UnitTest.Utils;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;
using WebFramework.Domain.DefaultImpl;

namespace WebFramework.Data.UnitTest.Common
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
            var contentType = UnitTestAssistant.CreateContentType();
            var listValue = DomainRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            var attribute = ContentAttribute.Factory.Create("A1", "Attribute 1", contentType, listValue, 0);

            DomainRepositories.ContentAttribute.Save(attribute);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            var myAttribute = DomainRepositories.ContentAttribute.GetById(attribute.Id);
            Assert.IsNotNull(myAttribute);
            Assert.AreEqual(attribute.Id, myAttribute.Id);
            Assert.AreEqual("T1", myAttribute.Code);
            Assert.AreEqual(contentType.TypeName, myAttribute.ContentType.TypeName);
            Assert.AreEqual(ListValueConstants.ContentDataTypes.TextSimpleTextBox, myAttribute.DataType.Name);

            DomainRepositories.ContentAttribute.Delete(attribute.Id);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            DomainRepositories.ContentType.Delete(contentType.Id);
            DomainRepositories.RepositoryAssistant.FlushAndClear();
        }

        [Test]
        public void CanDeleteContentAttribute()
        {
            var type = UnitTestAssistant.CreateContentType();
            var listValue = DomainRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            var attribute = ContentAttribute.Factory.Create("A1", "Attribute 1", type, listValue, 0);

            DomainRepositories.ContentAttribute.Save(attribute);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            DomainRepositories.ContentAttribute.Delete(attribute.Id);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            var savedAttribute = DomainRepositories.ContentAttribute.GetById(attribute.Id);
            Assert.IsNull(savedAttribute);

            DomainRepositories.ContentType.Delete(type.Id);
            DomainRepositories.RepositoryAssistant.FlushAndClear();
        }
    }
}
