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
    public class ContentAttributeTests : NUnitBase
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
            var attribute = ContentAttribute.Factory.Create();

            Assert.AreEqual(true, attribute.IsActive);
            Assert.AreEqual(true, attribute.IsDeletable);
            Assert.AreEqual(true, attribute.IsEditable);
            Assert.AreEqual(true, attribute.IsViewable);
            VerificationUtils.EmptyCreMod(attribute);
        }

        #endregion

        [Test]
        public void CanAddContentAttribute()
        {
            var type = AssistantTest.CreateContentType();
            var attribute = ContentAttribute.Factory.Create("T1", type, ListValueConstants.ContentDataTypes_Text_InputTextBox);

            DomainRepositories.ContentAttribute.Save(attribute);
            DomainRepositories.ContentAttribute.Synchronize();

            var myAttribute = DomainRepositories.ContentAttribute.GetById(attribute.Id);
            Assert.IsNotNull(myAttribute);
            Assert.AreEqual(attribute.Id, myAttribute.Id);
            Assert.AreEqual("T1", myAttribute.Code);
            Assert.AreEqual(type.TypeName, myAttribute.ContentType.TypeName);
            Assert.AreEqual(ListValueConstants.ContentDataTypes_Text_InputTextBox, myAttribute.DataType.Name);

            DomainRepositories.ContentAttribute.Delete(attribute);
            DomainRepositories.ContentType.Delete(type);
            DomainRepositories.ContentType.Synchronize();
        }

        [Test]
        public void CanDeleteContentAttribute()
        {
            var type = AssistantTest.CreateContentType();
            var attribute = ContentAttribute.Factory.Create("T1", type, ListValueConstants.ContentDataTypes_Text_InputTextBox);

            DomainRepositories.ContentAttribute.Save(attribute);
            DomainRepositories.ContentAttribute.Synchronize();

            DomainRepositories.ContentAttribute.Delete(attribute);
            DomainRepositories.ContentAttribute.Synchronize();

            var savedAttribute = DomainRepositories.ContentAttribute.GetById(attribute.Id);
            Assert.IsNull(savedAttribute);

            DomainRepositories.ContentType.Delete(type);
            DomainRepositories.ContentType.Synchronize();
        }
    }
}
