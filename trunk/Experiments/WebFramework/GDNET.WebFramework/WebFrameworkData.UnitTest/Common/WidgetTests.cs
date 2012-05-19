using NUnit.Framework;
using WebFramework.Domain;
using WebFramework.Domain.System;
using WebFrameworkData.UnitTest;

namespace WebFramework.Data.UnitTest.Common
{
    [TestFixture]
    public class WidgetTests : NUnitBase
    {
        [SetUp]
        public void SetUp()
        {
            base.Init();

            TestAssistant.CreateCultures();
            TestAssistant.CreateListValues();
        }

        [TearDown]
        public void TearDown()
        {
            base.Clean();
        }

        [Test]
        public void CanAddWidget()
        {
            var widget = Widget.Factory.Create("W1", "WidgetOne", "The widget one");
            widget.ClassName = this.GetType().FullName;
            widget.AssemblyName = this.GetType().Assembly.FullName;

            DomainRepositories.Widget.Save(widget);
            DomainRepositories.RepositoryAssistant.FlushAndClear();

            var widget2 = DomainRepositories.Widget.GetById(widget.Id);
            Assert.IsNotNull(widget2);
            Assert.AreEqual("W1", widget2.Code);
            Assert.AreEqual("WidgetOne", widget2.TechnicalName);
            Assert.AreEqual("The widget one", widget2.Name.Value);
            Assert.IsNullOrEmpty(widget2.Description.Value);
        }
    }
}
