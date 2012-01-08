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

        #region Factory Tests

        [Test]
        public void FactoryCreateTest()
        {
            var item = ContentItem.Factory.Create();

            Assert.AreEqual(true, item.IsActive);
            Assert.AreEqual(true, item.IsDeletable);
            Assert.AreEqual(true, item.IsEditable);
            Assert.AreEqual(true, item.IsViewable);
            VerificationUtils.EmptyCreMod(item);
        }

        #endregion

        [Test]
        public void CanAddContentItem()
        {
            var type = AssistantTest.CreateContentType();
            var item = AssistantTest.CreateContentItem("T1", "Test 1", type);

            var myItem = DomainRepositories.ContentItem.GetById(item.Id);
            Assert.IsNotNull(myItem);
            Assert.AreEqual(item.Id, myItem.Id);
            Assert.AreEqual("T1", myItem.Name.Value);
            Assert.AreEqual("Test 1", myItem.Description.Value);
            Assert.AreEqual(type.TypeName, myItem.ContentType.TypeName);

            DomainRepositories.ContentItem.Delete(item);
            DomainRepositories.ContentType.Delete(type);

            DomainRepositories.ContentType.Synchronize();
        }

        [Test]
        public void CanDeleteContentItem()
        {
            var type = AssistantTest.CreateContentType();
            var item = ContentItem.Factory.Create("T1", "Test 1", type);

            DomainRepositories.ContentItem.Save(item);
            DomainRepositories.ContentItem.Synchronize();

            DomainRepositories.ContentItem.Delete(item.Id);
            DomainRepositories.ContentItem.Synchronize();

            var savedItem = DomainRepositories.ContentItem.GetById(item.Id);
            Assert.IsNull(savedItem);

            DomainRepositories.ContentType.Delete(type.Id);
            DomainRepositories.ContentType.Synchronize();
        }

        [Test]
        public void CanUpdateContentItem()
        {
            var contentAttribute = AssistantTest.CreateContentAttribute();
            var contentItem = ContentItem.Factory.Create("T1", "Test 1", contentAttribute.ContentType);

            DomainRepositories.ContentItem.Save(contentItem);
            DomainRepositories.ContentItem.Synchronize();

            ContentItemAttributeValue attributeValue1 = ContentItemAttributeValue.Factory.Create(contentAttribute, contentItem, "V1");
            ContentItemAttributeValue attributeValue2 = ContentItemAttributeValue.Factory.Create(contentAttribute, contentItem, "V2");
            contentItem.AddAttributeValue(attributeValue1);
            contentItem.AddAttributeValue(attributeValue2);

            DomainRepositories.ContentItem.Save(contentItem);
            DomainRepositories.ContentItem.Synchronize();
            DomainRepositories.ContentItem.Clear();

            var savedItem = DomainRepositories.ContentItem.GetById(contentItem.Id);
            Assert.IsNotNull(savedItem);
            Assert.AreEqual(contentItem.Name.Value, savedItem.Name.Value);
            Assert.AreEqual(2, savedItem.AttributeValues.Count);
            Assert.AreEqual("V1", savedItem.AttributeValues[0].Value.Value);
            Assert.AreEqual("V2", savedItem.AttributeValues[1].Value.Value);

            DomainRepositories.ContentItem.Delete(contentItem.Id);
            DomainRepositories.ContentItem.Synchronize();

            savedItem = DomainRepositories.ContentItem.GetById(contentItem.Id);
            Assert.IsNull(savedItem);

            DomainRepositories.ContentType.Delete(contentAttribute.ContentType.Id);
            DomainRepositories.ContentType.Synchronize();
        }

        [Test]
        public void CanAddContentItemWithAttributeValue()
        {
            var contentAttribute = AssistantTest.CreateContentAttribute();
            var contentItem = ContentItem.Factory.Create("T1", "Test 1", contentAttribute.ContentType);

            ContentItemAttributeValue attributeValue1 = ContentItemAttributeValue.Factory.Create(contentAttribute, contentItem, "V1");
            ContentItemAttributeValue attributeValue2 = ContentItemAttributeValue.Factory.Create(contentAttribute, contentItem, "V2");
            contentItem.AddAttributeValue(attributeValue1);
            contentItem.AddAttributeValue(attributeValue2);

            DomainRepositories.ContentItem.Save(contentItem);
            DomainRepositories.ContentItem.Synchronize();
            DomainRepositories.ContentItem.Clear();

            var savedItem = DomainRepositories.ContentItem.GetById(contentItem.Id);
            Assert.IsNotNull(savedItem);
            Assert.AreEqual(contentItem.Name.Value, savedItem.Name.Value);
            Assert.AreEqual(2, savedItem.AttributeValues.Count);
            Assert.AreEqual("V1", savedItem.AttributeValues[0].Value.Value);
            Assert.AreEqual("V2", savedItem.AttributeValues[1].Value.Value);

            DomainRepositories.ContentItem.Delete(contentItem.Id);
            DomainRepositories.ContentItem.Synchronize();

            savedItem = DomainRepositories.ContentItem.GetById(contentItem.Id);
            Assert.IsNull(savedItem);

            DomainRepositories.ContentAttribute.Delete(contentAttribute.Id);
            DomainRepositories.ContentAttribute.Synchronize();

            var savedAttribute = DomainRepositories.ContentAttribute.GetById(contentAttribute.Id);
            Assert.IsNull(savedAttribute);

            DomainRepositories.ContentType.Delete(contentAttribute.ContentType.Id);
            DomainRepositories.ContentType.Synchronize();

            var savedContentType = DomainRepositories.ContentType.GetById(contentAttribute.ContentType.Id);
            Assert.IsNull(savedContentType);
        }

        [Test]
        public void CanAddContentItemWithRelationItems()
        {
            var contentAttribute = AssistantTest.CreateContentAttribute();
            var contentItem = ContentItem.Factory.Create("T1", "Test 1", contentAttribute.ContentType);

            DomainRepositories.ContentItem.Save(contentItem);

            var relationItem1 = ContentItem.Factory.Create("R1", "Relation 1", contentAttribute.ContentType);
            var relationItem2 = ContentItem.Factory.Create("R2", "Relation 2", contentAttribute.ContentType);

            DomainRepositories.ContentItem.Save(relationItem1);
            DomainRepositories.ContentItem.Save(relationItem2);

            contentItem.AddRelationItem(relationItem1);
            contentItem.AddRelationItem(relationItem2);

            DomainRepositories.ContentItem.Synchronize();
            //DomainRepositories.ContentItem.Clear();

            var savedItem = DomainRepositories.ContentItem.GetById(contentItem.Id);
            Assert.IsNotNull(savedItem);
            Assert.AreEqual(2, savedItem.RelationItems.Count);
            Assert.AreEqual("R1", savedItem.RelationItems[0].Name.Value);
            Assert.AreEqual("R2", savedItem.RelationItems[1].Name.Value);

            DomainRepositories.ContentItem.Delete(contentItem.Id);
            DomainRepositories.ContentItem.Synchronize();

            var r1 = DomainRepositories.ContentItem.GetById(relationItem1.Id);
            Assert.IsNotNull(r1);

            var r2 = DomainRepositories.ContentItem.GetById(relationItem2.Id);
            Assert.IsNotNull(r2);

            DomainRepositories.ContentAttribute.Delete(relationItem1.Id);
            DomainRepositories.ContentAttribute.Delete(relationItem2.Id);
            DomainRepositories.ContentAttribute.Synchronize();
        }
    }
}
