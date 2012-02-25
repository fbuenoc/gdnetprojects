using NUnit.Framework;
using WebFrameworkData.UnitTest.Utils;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkData.UnitTest.Common
{
    [TestFixture]
    public class ContentItemTests : NUnitBase
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
        public void CanAddContentItem()
        {
            var type = UnitTestAssistant.CreateContentType();
            var item = UnitTestAssistant.CreateContentItem("T1", "Test 1", type);

            var myItem = DomainRepositories.ContentItem.GetById(item.Id);
            Assert.IsNotNull(myItem);
            Assert.AreEqual(item.Id, myItem.Id);
            Assert.AreEqual(0, myItem.Views);
            Assert.AreEqual("T1", myItem.Name.Value);
            Assert.AreEqual("Test 1", myItem.Description.Value);
            Assert.AreEqual(type.TypeName, myItem.ContentType.TypeName);

            DomainRepositories.ContentItem.Delete(item);
            DomainRepositories.ContentType.Delete(type);

            DomainRepositories.RepositoryAssistant.FlushAndClear();
        }

        [Test]
        public void CanAddRelationContentItems()
        {
            var type = UnitTestAssistant.CreateContentType();
            var item1 = UnitTestAssistant.CreateContentItem("T1", "Test 1", type);
            var item2 = UnitTestAssistant.CreateContentItem("T2", "Test 2", type);
            var item3 = UnitTestAssistant.CreateContentItem("T3", "Test 3", type);
            item1.AddRelationItem(item2);
            item1.AddRelationItem(item3);

            DomainRepositories.RepositoryAssistant.Flush();

            var myItem = DomainRepositories.ContentItem.GetById(item1.Id);
            Assert.AreEqual(2, myItem.RelationItems.Count);
            Assert.AreEqual(item2.Id, myItem.RelationItems[0].Id);
            Assert.AreEqual(item3.Id, myItem.RelationItems[1].Id);

            DomainRepositories.ContentItem.Delete(item3);
            DomainRepositories.ContentItem.Delete(item2);
            DomainRepositories.ContentItem.Delete(item1);
            DomainRepositories.ContentType.Delete(type);

            DomainRepositories.RepositoryAssistant.Flush();
        }

        [Test]
        public void CanDeleteContentItem()
        {
            var type = UnitTestAssistant.CreateContentType();
            var item = ContentItem.Factory.Create("T1", "Test 1", type);

            DomainRepositories.ContentItem.Save(item);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            DomainRepositories.ContentItem.Delete(item.Id);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            var savedItem = DomainRepositories.ContentItem.GetById(item.Id);
            Assert.IsNull(savedItem);

            DomainRepositories.ContentType.Delete(type.Id);
            DomainRepositories.RepositoryAssistant.Flush();
        }

        [Test]
        public void CanUpdateContentItem()
        {
            var contentAttribute = UnitTestAssistant.CreateContentAttribute();
            var contentItem = ContentItem.Factory.Create("T1", "Test 1", contentAttribute.ContentType);

            DomainRepositories.ContentItem.Save(contentItem);
            DomainRepositories.RepositoryAssistant.Flush();

            ContentItemAttributeValue attributeValue1 = ContentItemAttributeValue.Factory.Create(contentAttribute, contentItem, "V1");
            ContentItemAttributeValue attributeValue2 = ContentItemAttributeValue.Factory.Create(contentAttribute, contentItem, "V2");
            contentItem.AddAttributeValue(attributeValue1);
            contentItem.AddAttributeValue(attributeValue2);

            DomainRepositories.ContentItem.Save(contentItem);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            var savedItem = DomainRepositories.ContentItem.GetById(contentItem.Id);
            Assert.IsNotNull(savedItem);
            Assert.AreEqual(contentItem.Name.Value, savedItem.Name.Value);
            Assert.AreEqual(2, savedItem.AttributeValues.Count);
            Assert.AreEqual("V1", savedItem.AttributeValues[0].Value.Value);
            Assert.AreEqual("V2", savedItem.AttributeValues[1].Value.Value);

            DomainRepositories.ContentItem.Delete(contentItem.Id);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            savedItem = DomainRepositories.ContentItem.GetById(contentItem.Id);
            Assert.IsNull(savedItem);

            DomainRepositories.ContentType.Delete(contentAttribute.ContentType.Id);
            DomainRepositories.RepositoryAssistant.FlushAndClear();
        }

        [Test]
        public void CanAddContentItemWithAttributeValue()
        {
            var contentAttribute = UnitTestAssistant.CreateContentAttribute();
            var contentItem = ContentItem.Factory.Create("T1", "Test 1", contentAttribute.ContentType);

            ContentItemAttributeValue attributeValue1 = ContentItemAttributeValue.Factory.Create(contentAttribute, contentItem, "V1");
            ContentItemAttributeValue attributeValue2 = ContentItemAttributeValue.Factory.Create(contentAttribute, contentItem, "V2");
            contentItem.AddAttributeValue(attributeValue1);
            contentItem.AddAttributeValue(attributeValue2);

            DomainRepositories.ContentItem.Save(contentItem);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            var savedItem = DomainRepositories.ContentItem.GetById(contentItem.Id);
            Assert.IsNotNull(savedItem);
            Assert.AreEqual(contentItem.Name.Value, savedItem.Name.Value);
            Assert.AreEqual(2, savedItem.AttributeValues.Count);
            Assert.AreEqual("V1", savedItem.AttributeValues[0].Value.Value);
            Assert.AreEqual("V2", savedItem.AttributeValues[1].Value.Value);

            DomainRepositories.ContentItem.Delete(contentItem.Id);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            savedItem = DomainRepositories.ContentItem.GetById(contentItem.Id);
            Assert.IsNull(savedItem);

            DomainRepositories.ContentAttribute.Delete(contentAttribute.Id);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            var savedAttribute = DomainRepositories.ContentAttribute.GetById(contentAttribute.Id);
            Assert.IsNull(savedAttribute);

            DomainRepositories.ContentType.Delete(contentAttribute.ContentType.Id);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            var savedContentType = DomainRepositories.ContentType.GetById(contentAttribute.ContentType.Id);
            Assert.IsNull(savedContentType);
        }

        [Test]
        public void CanAddContentItemWithRelationItems()
        {
            var contentAttribute = UnitTestAssistant.CreateContentAttribute();
            var contentItem = ContentItem.Factory.Create("T1", "Test 1", contentAttribute.ContentType);

            DomainRepositories.ContentItem.Save(contentItem);

            var relationItem1 = ContentItem.Factory.Create("R1", "Relation 1", contentAttribute.ContentType);
            var relationItem2 = ContentItem.Factory.Create("R2", "Relation 2", contentAttribute.ContentType);

            DomainRepositories.ContentItem.Save(relationItem1);
            DomainRepositories.ContentItem.Save(relationItem2);

            contentItem.AddRelationItem(relationItem1);
            contentItem.AddRelationItem(relationItem2);

            DomainRepositories.RepositoryAssistant.FlushAndClear();

            var savedItem = DomainRepositories.ContentItem.GetById(contentItem.Id);
            Assert.IsNotNull(savedItem);
            Assert.AreEqual(2, savedItem.RelationItems.Count);
            Assert.AreEqual("R1", savedItem.RelationItems[0].Name.Value);
            Assert.AreEqual("R2", savedItem.RelationItems[1].Name.Value);

            DomainRepositories.ContentItem.Delete(contentItem.Id);
            DomainRepositories.RepositoryAssistant.Flush();

            var r1 = DomainRepositories.ContentItem.GetById(relationItem1.Id);
            Assert.IsNotNull(r1);

            var r2 = DomainRepositories.ContentItem.GetById(relationItem2.Id);
            Assert.IsNotNull(r2);

            DomainRepositories.ContentAttribute.Delete(r1.Id);
            DomainRepositories.ContentAttribute.Delete(r2.Id);
            DomainRepositories.RepositoryAssistant.Flush();
        }
    }
}
