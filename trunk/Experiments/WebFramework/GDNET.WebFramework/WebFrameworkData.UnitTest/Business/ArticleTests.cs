using System;
using NUnit.Framework;
using WebFrameworkBusiness;

namespace WebFrameworkData.UnitTest.Business
{
    [TestFixture]
    public class ArticleTests : NUnitBase
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
        public void CanCreateNewArticle()
        {
            Article myAtc = new Article();
            myAtc.Name = "A1";
            myAtc.Description = "This is A One";
            myAtc.SourceName = "Yahoo";
            myAtc.SourceUrl = "http://vn.yahoo.com";
            myAtc.PublishedDate = DateTime.Now;

            bool result = myAtc.Save();
            Assert.IsTrue(result);

            Article savedAtc = new Article();
            savedAtc.LoadItemById(myAtc.Id);

            Assert.AreEqual(myAtc.Name, savedAtc.Name);
            Assert.AreEqual(myAtc.Description, savedAtc.Description);
            Assert.AreEqual(myAtc.SourceName, savedAtc.SourceName);
            Assert.AreEqual(myAtc.SourceUrl, savedAtc.SourceUrl);
            Assert.AreEqual(myAtc.PublishedDate, savedAtc.PublishedDate);

            savedAtc.Delete();
        }

        [Test]
        public void CanCreateNewComment()
        {
            Comment c1 = new Comment();
            c1.Name = "A1";
            c1.Description = "This is A One";
            c1.Body = "B1";
            c1.Email = "huanhvhd@gmail.com";

            bool result = c1.Save();
            Assert.IsTrue(result);

            Comment c2 = new Comment();
            c2.LoadItemById(c1.Id);

            Assert.AreEqual(c1.Name, c2.Name);
            Assert.AreEqual(c1.Description, c2.Description);
            Assert.AreEqual(c1.Body, c2.Body);
            Assert.AreEqual(c1.Email, c2.Email);

            c2.Delete();
        }
    }
}
