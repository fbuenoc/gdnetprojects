using System;
using GDNET.Common.Types;
using NUnit.Framework;
using WebFrameworkBusiness.Common;
using WebFrameworkData.UnitTest.Utils;

namespace WebFrameworkData.UnitTest.Business
{
    [TestFixture]
    public class ArticleTests : NUnitBase
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
        public void CanCreateNewArticle()
        {
            Article myAtc = Article.Factory.Create("A1", "This is A One", "MC 1");
            myAtc.SourceInfo = new Website();
            myAtc.SourceInfo.Address = "http://vn.yahoo.com";
            myAtc.SourceInfo.SiteName = "Yahoo";
            myAtc.PublishedDate = DateTime.Now;

            Contact author = new Contact();
            author.ContactName = new Name();
            author.ContactName.DisplayName = "Huan HOANG";
            myAtc.Author = author;

            bool result = myAtc.Save();
            Assert.IsTrue(result);

            Article savedAtc = Article.Factory.NewInstance();
            savedAtc.GetById(myAtc.Id);

            Assert.AreEqual(myAtc.Name, savedAtc.Name);
            Assert.AreEqual(myAtc.Description, savedAtc.Description);
            Assert.AreEqual(myAtc.PublishedDate, savedAtc.PublishedDate);
            Assert.AreEqual(author.ContactName.DisplayName, savedAtc.Author.ContactName.DisplayName);
            Assert.AreEqual(author.Emails.Count, savedAtc.Author.Emails.Count);
            Assert.AreEqual(author.PhoneNumbers.Count, savedAtc.Author.PhoneNumbers.Count);

            savedAtc.Delete();
        }

        [Test]
        public void CanCreateNew10Articles()
        {
            DateTime t1 = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                Article myAtc = Article.Factory.Create("A1", "This is A One", "MC1");
                myAtc.SourceInfo = new Website();
                myAtc.SourceInfo.SiteName = "Yahoo";
                myAtc.SourceInfo.Address = "http://vn.yahoo.com";
                myAtc.PublishedDate = DateTime.Now;

                Contact author = new Contact();
                author.ContactName = new Name();
                author.ContactName.DisplayName = "Huan HOANG";
                myAtc.Author = author;

                bool result = myAtc.Save();
                Assert.IsTrue(result);

                Article savedAtc = Article.Factory.NewInstance();
                savedAtc.GetById(myAtc.Id);

                savedAtc.Delete();
            }
            Console.WriteLine("Spent: " + (DateTime.Now - t1).ToString());
        }
    }
}
