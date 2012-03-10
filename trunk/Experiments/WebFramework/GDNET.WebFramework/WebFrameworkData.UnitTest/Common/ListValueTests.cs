using System;
using System.Linq;
using NUnit.Framework;
using WebFramework.Data.UnitTest.Utils;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;
using WebFramework.Domain.DefaultImpl;

namespace WebFramework.Data.UnitTest.Common
{
    [TestFixture]
    public class ListValueTests : NUnitBase
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
        public void FactoryCreateTest_With2Params()
        {
            var lv = ListValue.Factory.Create("TestLV", "D1");

            Assert.AreEqual("TestLV", lv.Name);
            Assert.AreEqual("D1", lv.Description.Value);
        }

        [Test]
        public void FactoryCreateTest_With3Params()
        {
            var lv = ListValue.Factory.Create("TestLV", "D1", "V1");

            Assert.AreEqual("TestLV", lv.Name);
            Assert.AreEqual("D1", lv.Description.Value);
            Assert.AreEqual("V1", lv.CustomValue);
        }

        #endregion

        [Test]
        public void CanFindByName()
        {
            var valueItem = DomainRepositories.ListValue.FindByName(ListValueConstants.EncryptionTypes.None);
            Assert.IsNotNull(valueItem);
            Assert.AreEqual(ListValueConstants.EncryptionTypes.None, valueItem.Name);
        }

        [Test]
        public void CanAddListValue()
        {
            string lvName = Guid.NewGuid().ToString();
            var lv = UnitTestAssistant.CreateListValue(lvName);

            var savedLV = DomainRepositories.ListValue.GetById(lv.Id);

            Assert.IsNotNull(savedLV);
            Assert.IsTrue(savedLV.Id > 0);
            Assert.AreEqual(lvName, savedLV.Name);
            Assert.IsEmpty(savedLV.Description.Value);

            DomainRepositories.ListValue.Delete(lv.Id);
            DomainRepositories.RepositoryAssistant.Flush();
        }

        [Test]
        public void CanAddListValueWithSubValues()
        {
            string lvName = Guid.NewGuid().ToString();
            string lvChild = Guid.NewGuid().ToString();
            var rootValue = UnitTestAssistant.CreateListValue(lvName);
            var childValue = UnitTestAssistant.CreateListValue(lvChild);

            rootValue.AddSubValue(childValue);
            DomainRepositories.RepositoryAssistant.Flush();

            var savedLV = DomainRepositories.ListValue.GetById(rootValue.Id);

            Assert.IsNotNull(savedLV);
            Assert.AreEqual(1, savedLV.SubValues.Count);
            Assert.AreEqual(lvChild, savedLV.SubValues[0].Name);

            DomainRepositories.ListValue.Delete(rootValue.Id);
            DomainRepositories.RepositoryAssistant.Flush();

            var savedChildLV = DomainRepositories.ListValue.GetById(childValue.Id);
            Assert.IsNull(savedChildLV);
        }

        [Test]
        public void CanGetRootValues()
        {
            string root1 = Guid.NewGuid().ToString();
            string root2 = Guid.NewGuid().ToString();
            var rootValue1 = UnitTestAssistant.CreateListValue(root1);
            var rootValue2 = UnitTestAssistant.CreateListValue(root2);

            string child1 = Guid.NewGuid().ToString();
            string child2 = Guid.NewGuid().ToString();
            var childValue1 = UnitTestAssistant.CreateListValue(child1);
            var childValue2 = UnitTestAssistant.CreateListValue(child2);

            rootValue1.AddSubValue(childValue1);
            rootValue2.AddSubValue(childValue2);
            DomainRepositories.RepositoryAssistant.Flush();

            var rootValues = DomainRepositories.ListValue.GetAllRootValues();
            rootValues = rootValues.Where(x => x.Name == rootValue1.Name || x.Name == rootValue2.Name).ToList();

            Assert.IsTrue(rootValues.Count == 2);
            Assert.AreEqual(root1, rootValues[0].Name);
            Assert.AreEqual(root2, rootValues[1].Name);

            DomainRepositories.ListValue.Delete(rootValue1.Id);
            DomainRepositories.ListValue.Delete(rootValue2.Id);
            DomainRepositories.RepositoryAssistant.Flush();
        }

        [Test]
        public void CanGetAllValuesByParent()
        {
            string listName = Guid.NewGuid().ToString();
            string child1 = Guid.NewGuid().ToString();
            string child2 = Guid.NewGuid().ToString();

            var rootValue1 = UnitTestAssistant.CreateListValue(listName);
            var childValue1 = UnitTestAssistant.CreateListValue(child1);
            var childValue2 = UnitTestAssistant.CreateListValue(child2);

            rootValue1.AddSubValue(childValue1);
            childValue1.AddSubValue(childValue2);
            DomainRepositories.RepositoryAssistant.Flush();

            var listOfValues = DomainRepositories.ListValue.GetAllValuesByParent(rootValue1);

            Assert.IsTrue(listOfValues.Count == 2);
            Assert.AreEqual(childValue1.Name, listOfValues[0].Name);
            Assert.AreEqual(childValue2.Name, listOfValues[1].Name);

            DomainRepositories.ListValue.Delete(rootValue1.Id);
            DomainRepositories.RepositoryAssistant.Flush();
        }

        [Test]
        public void CanGetAllValuesByParent_WithParent()
        {
            string listName = Guid.NewGuid().ToString();
            string child1 = Guid.NewGuid().ToString();
            string child2 = Guid.NewGuid().ToString();

            var rootValue1 = UnitTestAssistant.CreateListValue(listName);
            var childValue1 = UnitTestAssistant.CreateListValue(child1);
            var childValue2 = UnitTestAssistant.CreateListValue(child2);

            rootValue1.AddSubValue(childValue1);
            childValue1.AddSubValue(childValue2);
            DomainRepositories.RepositoryAssistant.Flush();

            var listOfValues = DomainRepositories.ListValue.GetAllValuesByParent(rootValue1, true);

            Assert.IsTrue(listOfValues.Count == 3);
            Assert.AreEqual(rootValue1.Name, listOfValues[0].Name);
            Assert.AreEqual(childValue1.Name, listOfValues[1].Name);
            Assert.AreEqual(childValue2.Name, listOfValues[2].Name);

            DomainRepositories.ListValue.Delete(rootValue1.Id);
            DomainRepositories.RepositoryAssistant.Flush();
        }

        [Test]
        public void CanAddListValueWithParent()
        {
            string lvRoot = Guid.NewGuid().ToString();
            string lvChild = Guid.NewGuid().ToString();
            var lv = UnitTestAssistant.CreateListValue(lvRoot);
            var subLV = ListValue.Factory.Create(lvChild, "D1", "CV1", lv.Id);

            Assert.IsNotNull(subLV.Parent);
            Assert.AreEqual(lv.Name, subLV.Parent.Name);

            DomainRepositories.ListValue.Delete(lv);
            DomainRepositories.RepositoryAssistant.Flush();

            var savedLV = DomainRepositories.ListValue.GetById(lv.Id);
            Assert.IsNull(savedLV);
        }

        [Test]
        public void CanDeleteListValue()
        {
            string lvRoot = Guid.NewGuid().ToString();
            var lv = UnitTestAssistant.CreateListValue(lvRoot);

            DomainRepositories.ListValue.Delete(lv);
            DomainRepositories.RepositoryAssistant.Flush();

            var savedLV = DomainRepositories.ListValue.GetById(lv.Id);
            Assert.IsNull(savedLV);
        }
    }
}
