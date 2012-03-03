using GDNET.Common.Types;
using NUnit.Framework;
using WebFrameworkBusiness.Common;
using WebFrameworkData.UnitTest.Utils;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkData.UnitTest.Business
{
    [TestFixture]
    public class CommentTests : NUnitBase
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            base.Init();

            UnitTestAssistant.EnsureContentTypes();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            base.Clean();
        }

        [Test]
        public void CanCreateNewComment()
        {
            Comment cm2 = Comment.Factory.Create("T1", "B1");
            cm2.Email = new Email("huanhvhd@gmail.com");

            bool result = cm2.Save();
            Assert.IsTrue(result);

            Comment cm3 = Comment.Factory.NewInstance();
            cm3.GetById(cm2.Id);

            Assert.AreEqual(cm2.Title, cm3.Title);
            Assert.AreEqual(cm2.Body, cm3.Body);
            Assert.AreEqual(cm2.Email.Serialize(), cm3.Email.Serialize());

            cm3.Delete();
            DomainRepositories.RepositoryAssistant.Flush();
        }
    }
}
