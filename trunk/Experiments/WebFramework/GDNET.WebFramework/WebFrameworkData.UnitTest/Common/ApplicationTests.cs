using NUnit.Framework;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.DefaultImpl;
using System;

namespace WebFrameworkData.UnitTest.Common
{
    [TestFixture]
    public class ApplicationTests : NUnitBase
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
            var app = Application.Factory.Create("Google", "The Google site", "http://google.com");

            Assert.AreEqual(false, app.IsActive);
            Assert.AreEqual(true, app.IsDeletable);
            Assert.AreEqual(true, app.IsEditable);
            Assert.AreEqual(false, app.IsViewable);
        }

        #endregion

        [Test]
        public void CanAddApplication()
        {
            var rootUrl = "http://" + Guid.NewGuid().ToString() + ".com";
            var name = "Yahoo";
            var desc = "The Yahoo";
            var app = Application.Factory.Create(name, desc, rootUrl);

            DomainRepositories.Application.Save(app);
            DomainRepositories.RepositoryAssistant.Flush();

            var myApp = DomainRepositories.Application.GetById(app.Id);
            Assert.IsNotNull(myApp);
            Assert.AreEqual(app.Id, myApp.Id);
            Assert.AreEqual(rootUrl, myApp.RootUrl);
            Assert.AreEqual(name, myApp.Name.Value);
            Assert.AreEqual(desc, myApp.Description.Value);
            Assert.AreEqual(ListValueConstants.ApplicationCategories.Default, myApp.Category.Name);
            Assert.AreEqual(CommonConstants.CultureCodeDefault, myApp.CultureDefault.CultureCode);

            DomainRepositories.Application.Delete(app.Id);
            DomainRepositories.RepositoryAssistant.Flush();

            var myApp2 = DomainRepositories.Application.GetById(app.Id);
            Assert.IsNull(myApp2);
        }
    }
}
