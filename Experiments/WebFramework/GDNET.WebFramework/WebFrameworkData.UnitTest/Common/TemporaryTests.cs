using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using WebFrameworkDomain;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Constants;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkData.UnitTest.Common
{
    [TestFixture]
    public class TemporaryTests : NUnitBase
    {
        [SetUp]
        public void SetUp()
        {
            base.Init();
        }

        [TearDown]
        public void TearDown()
        {
            base.Clean();
        }

        #region Factory Tests

        [Test]
        public void FactoryCreateTest()
        {
            var temporary = Temporary.Factory.Create();

            Assert.AreEqual(true, temporary.IsActive);
            Assert.IsNotNull(new Guid(temporary.Id));

            Assert.IsNull(temporary.EncodingType);
            Assert.IsNull(temporary.Text);
            VerificationUtils.EmptyCreMod(temporary);
        }

        #endregion

        [Test]
        public void CanAddTemporary()
        {
            var temporary = Temporary.Factory.Create(string.Empty, ListValueConstants.EncodingTypes_None);
            DomainRepositories.Temporary.Save(temporary);
            DomainRepositories.Temporary.Synchronize();

            var savedTemporary = DomainRepositories.Temporary.GetById(temporary.Id);

            Assert.IsTrue(string.IsNullOrEmpty(savedTemporary.Id) == false);
            Assert.IsNotNull(new Guid(savedTemporary.Id));
            Assert.AreEqual(ListValueConstants.EncodingTypes_None, savedTemporary.EncodingType.Name);
            DomainRepositories.Temporary.DeleteAll();
        }
    }
}
