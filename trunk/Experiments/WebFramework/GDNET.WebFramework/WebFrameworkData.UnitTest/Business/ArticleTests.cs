using System;
using GDNET.Common.Types;
using NUnit.Framework;
using WebFrameworkBusiness.Common;

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

            Article savedAtc = Article.Factory.Create();
            savedAtc.LoadItemById(myAtc.Id);

            Assert.AreEqual(myAtc.Name, savedAtc.Name);
            Assert.AreEqual(myAtc.Description, savedAtc.Description);
            Assert.AreEqual(myAtc.PublishedDate, savedAtc.PublishedDate);
            Assert.AreEqual(author.ContactName.DisplayName, savedAtc.Author.ContactName.DisplayName);
            Assert.AreEqual(author.Emails.Count, savedAtc.Author.Emails.Count);
            Assert.AreEqual(author.PhoneNumbers.Count, savedAtc.Author.PhoneNumbers.Count);

            savedAtc.Delete();
        }

        [Test]
        public void CanCreateNew100Articles()
        {
            DateTime t1 = DateTime.Now;
            for (int i = 0; i < 100; i++)
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

                Article savedAtc = Article.Factory.Create();
                savedAtc.LoadItemById(myAtc.Id);

                savedAtc.Delete();
            }
            Console.WriteLine("Spent: " + (DateTime.Now - t1).ToString());
        }

        [Test]
        public void CanCreateNewComment()
        {
            Comment c1 = Comment.Factory.Create("T1", "B1");
            c1.Name = "A1";
            c1.Description = "This is A One";
            c1.Email = new Email("huanhvhd@gmail.com");

            bool result = c1.Save();
            Assert.IsTrue(result);

            Comment c2 = Comment.Factory.Create();
            c2.LoadItemById(c1.Id);

            Assert.AreEqual(c1.Name, c2.Name);
            Assert.AreEqual(c1.Description, c2.Description);
            Assert.AreEqual(c1.Body, c2.Body);
            Assert.AreEqual(c1.Email.Serialize(), c2.Email.Serialize());

            c2.Delete();
        }
    }
}
