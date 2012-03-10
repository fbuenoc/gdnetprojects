using NUnit.Framework;
using WebFramework.Domain.Common;
using WebFramework.Domain.DefaultImpl;
using System;

namespace WebFramework.Data.UnitTest.Common
{
    [TestFixture]
    public class TranslationTests : NUnitBase
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
        public void CanAddStatutLifeCycle()
        {
            string code = Guid.NewGuid().ToString();
            Translation tran = Translation.Factory.Create(code, "Translation 1");
            DomainRepositories.Translation.Save(tran);
            DomainRepositories.RepositoryAssistant.Flush();

            Assert.AreEqual(code, tran.Code);
            Assert.AreEqual("Translation 1", tran.Value);
            Assert.IsTrue(tran.LifeCycle.Id > 0);

            DomainRepositories.Translation.Delete(tran.Id);
        }
    }
}
