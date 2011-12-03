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
        public void FactoryCreateTest()
        {
            var lv = ListValue.Factory.Create();

            Assert.AreEqual(true, lv.IsActive);
            Assert.AreEqual(true, lv.IsDeletable);
            Assert.AreEqual(true, lv.IsEditable);
            Assert.AreEqual(true, lv.IsViewable);
            VerificationUtils.EmptyCreMod(lv);
        }

        [Test]
        public void FactoryCreateTest_With2Params()
        {
            var lv = ListValue.Factory.Create("TestLV", "D1");

            Assert.AreEqual("TestLV", lv.Name);
            Assert.AreEqual("D1", lv.Description.Value);
            VerificationUtils.EmptyCreMod(lv);
        }

        [Test]
        public void FactoryCreateTest_With3Params()
        {
            var lv = ListValue.Factory.Create("TestLV", "V1", "D1");

            Assert.AreEqual("TestLV", lv.Name);
            Assert.AreEqual("D1", lv.Description.Value);
            Assert.AreEqual("V1", lv.CustomValue);
            VerificationUtils.EmptyCreMod(lv);
        }

        #endregion

        [Test]
        public void CanFindByName()
        {
            var valueItem = DomainRepositories.ListValue.FindByName(ListValueConstants.EncryptionTypes_None);
            Assert.IsNotNull(valueItem);
            Assert.AreEqual(ListValueConstants.EncryptionTypes_None, valueItem.Name);
        }

        [Test]
        public void CanAddListValue()
        {
            var lv = AssistantTest.CreateListValue("TestLV");
            DomainRepositories.ListValue.Clear();

            var savedLV = DomainRepositories.ListValue.GetById(lv.Id);

            Assert.IsNotNull(savedLV);
            Assert.IsTrue(savedLV.Id > 0);
            Assert.AreEqual("TestLV", savedLV.Name);
            Assert.IsEmpty(savedLV.Description.Value);

            DomainRepositories.ListValue.Delete(lv.Id);
            DomainRepositories.ListValue.Synchronize();
        }

        [Test]
        public void CanAddListValueWithSubValues()
        {
            var rootValue = AssistantTest.CreateListValue("TestLV");
            var childValue = AssistantTest.CreateListValue("Child1");

            rootValue.AddSubValue(childValue);
            DomainRepositories.ListValue.Synchronize();
            DomainRepositories.ListValue.Clear();

            var savedLV = DomainRepositories.ListValue.GetById(rootValue.Id);

            Assert.IsNotNull(savedLV);
            Assert.AreEqual(1, savedLV.SubValues.Count);
            Assert.AreEqual("Child1", savedLV.SubValues[0].Name);

            DomainRepositories.ListValue.Delete(rootValue.Id);
            DomainRepositories.ListValue.Synchronize();

            var savedChildLV = DomainRepositories.ListValue.GetById(childValue.Id);
            Assert.IsNull(savedChildLV);
        }

        [Test]
        public void CanDeleteListValue()
        {
            var lv = AssistantTest.CreateListValue("TestLV");

            DomainRepositories.ListValue.Delete(lv);
            DomainRepositories.ListValue.Synchronize();
            DomainRepositories.ListValue.Clear();

            var savedLV = DomainRepositories.ListValue.GetById(lv.Id);
            Assert.IsNull(savedLV);
        }
    }
}
