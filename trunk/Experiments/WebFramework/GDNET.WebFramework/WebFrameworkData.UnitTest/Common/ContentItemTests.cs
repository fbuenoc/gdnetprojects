﻿using System;
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
        public void CanAddContentTypeWithAttribute()
        {
            var contentAttribute = AssistantTest.CreateContentAttribute();
            var contentItem = ContentItem.Factory.Create("T1", "Test 1", contentAttribute.ContentType);

            ContentItemAttributeValue attributeValue = ContentItemAttributeValue.Factory.Create(contentAttribute, contentItem, "V1");
            contentItem.AddAttributeValue(attributeValue);

            DomainRepositories.ContentItem.Save(contentItem);
            DomainRepositories.ContentItem.Synchronize();
            DomainRepositories.ContentItem.Clear();

            var savedItem = DomainRepositories.ContentItem.GetById(contentItem.Id);
            Assert.IsNotNull(savedItem);
            Assert.AreEqual(contentItem.Name.Value, savedItem.Name.Value);
            Assert.AreEqual(1, savedItem.AttributeValues.Count);
            Assert.AreEqual("V1", savedItem.AttributeValues[0].Value.Value);

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
    }
}