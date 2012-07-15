using System;
using GDNET.DataTests.Base;
using GDNET.Domain;
using GDNET.Domain.Base.Exceptions;
using GDNET.Domain.System;
using NUnit.Framework;

namespace GDNET.DataTests.System
{
    [TestFixture]
    public class UserTests : NUnitTestBase
    {
        [Test]
        public void CanAddUser()
        {
            var u1 = User.Factory.Create("love@gmail.com", "A1B2C3");
            u1.DisplayName = "Love";
            u1.IsActive = true;
            DomainRepositories.User.Save(u1);
            DomainRepositories.RepositoryManager.FlushAndClear();

            var u2 = DomainRepositories.User.GetById(u1.Id);
            Assert.AreEqual("love@gmail.com", u2.Email);
            Assert.AreEqual("A1B2C3", u2.Password);
            Assert.AreEqual("Love", u2.DisplayName);
            Assert.IsTrue(u2.IsActive);
            Assert.AreNotEqual(DateTime.MinValue, u2.EntityHistory.CreatedAt);
            Assert.IsFalse(string.IsNullOrEmpty(u2.EntityHistory.CreatedBy));
            Assert.AreEqual(DateTime.MinValue, u2.EntityHistory.LastModifiedAt);
            Assert.IsTrue(string.IsNullOrEmpty(u2.EntityHistory.LastModifiedBy));

            u2.DisplayName = "DN";
            DomainRepositories.RepositoryManager.Flush();
            Assert.AreNotEqual(DateTime.MinValue, u2.EntityHistory.LastModifiedAt);
            Assert.IsFalse(string.IsNullOrEmpty(u2.EntityHistory.LastModifiedBy));
        }

        [Test]
        [ExpectedException(typeof(BusinessException))]
        public void CantAddUserBecauseEmailNotUnique()
        {
            var u1 = User.Factory.Create("love@gmail.com", "A1B2C3");
            DomainRepositories.User.Save(u1);

            var u2 = User.Factory.Create("love@gmail.com", "XYZ");
            DomainRepositories.User.Save(u2);
        }

        [Test]
        [ExpectedException(typeof(BusinessException))]
        public void CantModifyUserBecauseEmailNotUnique()
        {
            var u1 = User.Factory.Create("love1@gmail.com", "A1B2C3");
            var u2 = User.Factory.Create("love2@gmail.com", "XYZ");
            DomainRepositories.User.Save(u1);
            DomainRepositories.User.Save(u2);
        }

        [Test]
        public void CanFindByEmail()
        {
            var u1 = User.Factory.Create("love1@gmail.com", "A1B2C3");
            DomainRepositories.User.Save(u1);
            DomainRepositories.RepositoryManager.FlushAndClear();

            var u2 = DomainRepositories.User.FindByEmail(u1.Email);
            Assert.IsNotNull(u2);
            Assert.AreEqual(u1.Id, u2.Id);
        }
    }
}
