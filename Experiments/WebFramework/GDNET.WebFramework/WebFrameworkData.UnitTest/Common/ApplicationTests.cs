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
            var app = Application.Factory.Create("http://google.com", "Google", "The Google site");

            Assert.AreEqual(false, app.IsActive);
            Assert.AreEqual(true, app.IsDeletable);
            Assert.AreEqual(true, app.IsEditable);
            Assert.AreEqual(true, app.IsViewable);
            VerificationUtils.EmptyCreMod(app);
        }

        #endregion

        [Test]
        public void CanAddApplication()
        {
            var rootUrl = "http://yahoo.com";
            var name = "Yahoo";
            var desc = "The Yahoo";
            var app = Application.Factory.Create(rootUrl, name, desc);

            DomainRepositories.Application.Save(app);
            DomainRepositories.Application.Synchronize();

            var myApp = DomainRepositories.Application.GetById(app.Id);
            Assert.IsNotNull(myApp);
            Assert.AreEqual(app.Id, myApp.Id);
            Assert.AreEqual(rootUrl, myApp.RootUrl);
            Assert.AreEqual(name, myApp.Name.Value);
            Assert.AreEqual(desc, myApp.Description.Value);
            Assert.AreEqual(ListValueConstants.ApplicationCategories_Default, myApp.Category.Name);

            DomainRepositories.Application.Delete(app.Id);
            DomainRepositories.Application.Synchronize();

            var myApp2 = DomainRepositories.Application.GetById(app.Id);
            Assert.IsNull(myApp2);
        }
    }
}
