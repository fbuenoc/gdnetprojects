using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using WebFrameworkDomain;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Constants;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkData.UnitTest.Common
{
    [TestFixture]
    public class TemporaryTests : NUnitBase
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
            var temporary = Temporary.Factory.Create();

            Assert.AreEqual(true, temporary.IsActive);
            Assert.IsNotNull(new Guid(temporary.Id));

            Assert.IsNull(temporary.EncryptionType);
            Assert.IsNull(temporary.Text);
            VerificationUtils.EmptyCreMod(temporary);
        }

        #endregion

        [Test]
        public void CanAddTemporary()
        {
            var temporary = Temporary.Factory.Create("Test");
            DomainRepositories.Temporary.Save(temporary);

            DomainRepositories.Temporary.Synchronize();
            DomainRepositories.Temporary.Clear();

            var savedTemporary = DomainRepositories.Temporary.GetById(temporary.Id);

            Assert.IsNotNull(new Guid(savedTemporary.Id));
            Assert.AreEqual("Test", savedTemporary.Text);
            Assert.AreEqual(ListValueConstants.EncryptionTypes_None, savedTemporary.EncryptionType.Name);
            DomainRepositories.Temporary.DeleteAll();
        }

        [Test]
        public void CanAddTemporaryWithEncryptBase64()
        {
            var temporary = Temporary.Factory.CreateWithBase64("Test");
            DomainRepositories.Temporary.Save(temporary);

            DomainRepositories.Temporary.Synchronize();
            DomainRepositories.Temporary.Clear();

            var savedTemporary = DomainRepositories.Temporary.GetById(temporary.Id);

            Assert.IsNotNull(new Guid(savedTemporary.Id));
            Assert.AreEqual("Test", savedTemporary.Text);
            Assert.AreEqual(ListValueConstants.EncryptionTypes_Base64, savedTemporary.EncryptionType.Name);
            DomainRepositories.Temporary.DeleteAll();
        }

        [Test]
        public void CanAddTemporaryWithEncryptAES()
        {
            var temporary = Temporary.Factory.CreateWithAES("Test");
            DomainRepositories.Temporary.Save(temporary);

            DomainRepositories.Temporary.Synchronize();
            DomainRepositories.Temporary.Clear();

            var savedTemporary = DomainRepositories.Temporary.GetById(temporary.Id);

            Assert.IsNotNull(new Guid(savedTemporary.Id));
            Assert.AreEqual("Test", savedTemporary.Text);
            Assert.AreEqual(ListValueConstants.EncryptionTypes_AES, savedTemporary.EncryptionType.Name);
            DomainRepositories.Temporary.DeleteAll();
        }
    }
}

