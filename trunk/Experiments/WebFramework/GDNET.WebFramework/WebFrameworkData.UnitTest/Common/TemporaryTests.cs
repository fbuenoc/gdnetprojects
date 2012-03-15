using NUnit.Framework;
using WebFramework.Domain;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;

namespace WebFramework.Data.UnitTest.Common
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
            var temporary = Temporary.Factory.Create("T1");

            Assert.IsNotNull(temporary.Id.ToString());
            Assert.AreEqual(ListValueConstants.EncryptionTypes.None, temporary.EncryptionType.Name);
            Assert.AreEqual("T1", temporary.Text);
        }

        #endregion

        [Test]
        public void CanAddTemporary()
        {
            var temporary = Temporary.Factory.Create("Test");
            DomainRepositories.Temporary.Save(temporary);

            DomainRepositories.RepositoryAssistant.Flush();

            var savedTemporary = DomainRepositories.Temporary.GetById(temporary.Id);

            Assert.IsNotNull(savedTemporary.Id.ToString());
            Assert.AreEqual("Test", savedTemporary.Text);
            Assert.AreEqual(ListValueConstants.EncryptionTypes.None, savedTemporary.EncryptionType.Name);
            DomainRepositories.Temporary.Delete(savedTemporary.Id);
        }

        [Test]
        public void CanAddTemporaryWithEncryptBase64()
        {
            var temporary = Temporary.Factory.CreateWithBase64("Test");
            DomainRepositories.Temporary.Save(temporary);

            DomainRepositories.RepositoryAssistant.Flush();

            var savedTemporary = DomainRepositories.Temporary.GetById(temporary.Id);

            Assert.IsNotNull(savedTemporary.Id.ToString());
            Assert.AreEqual("Test", savedTemporary.Text);
            Assert.AreEqual(ListValueConstants.EncryptionTypes.Base64, savedTemporary.EncryptionType.Name);
            DomainRepositories.Temporary.Delete(savedTemporary.Id);
        }

        [Test]
        public void CanAddTemporaryWithEncryptAES()
        {
            var temporary = Temporary.Factory.CreateWithAES("Test");
            DomainRepositories.Temporary.Save(temporary);

            DomainRepositories.RepositoryAssistant.Flush();

            var savedTemporary = DomainRepositories.Temporary.GetById(temporary.Id);

            Assert.IsNotNull(savedTemporary.Id.ToString());
            Assert.AreEqual("Test", savedTemporary.Text);
            Assert.AreEqual(ListValueConstants.EncryptionTypes.AES, savedTemporary.EncryptionType.Name);
            DomainRepositories.Temporary.Delete(savedTemporary.Id);
        }
    }
}

