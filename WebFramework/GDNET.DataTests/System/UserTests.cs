using System.Linq;
using GDNET.DataTests.Base;
using GDNET.Domain;
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
            DomainRepositories.User.Save(u1);
            DomainRepositories.RepositoryManager.FlushAndClear();

            var allUsers = DomainRepositories.User.GetAll();
            Assert.IsTrue(allUsers.Count(x => x.Id == u1.Id) == 1);
        }
    }
}
