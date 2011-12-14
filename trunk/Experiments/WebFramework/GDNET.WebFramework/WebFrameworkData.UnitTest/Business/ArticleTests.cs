using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            myAtc.PublishedDate = DateTime.Today;

            bool result = myAtc.Save();
            Assert.IsTrue(result);

            Article savedAtc = new Article();
            savedAtc.LoadItemById(myAtc.Id);
        }
    }
}
