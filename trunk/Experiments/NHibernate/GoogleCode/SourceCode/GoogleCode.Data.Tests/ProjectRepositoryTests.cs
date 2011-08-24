using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using GDNET.Extensions.NHibernateImpl;
using GoogleCode.Data.Mapping;
using GoogleCode.Core.Domain;

namespace GoogleCode.Data.Tests
{
    [TestFixture]
    public class ProjectRepositoryTests
    {
        #region TestFixture Methods

        [SetUp]
        public void SetUp()
        {
            NHSessionManager.Initialize(MappingUtil.GetHbmMapping());
        }

        [TearDown]
        public void TearDown()
        {
            NHSessionManager.Release();
        }

        #endregion

        [Test]
        public void SaveOrUpdateTestWithLabel()
        {
            using (var session = NHSessionManager.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var labelRepository = new LabelRepository(session);
                    var projectRepository = new ProjectRepository(session);

                    Label l1 = TestHelperFactory.NewLabel(1);
                    Label l2 = TestHelperFactory.NewLabel(2);

                    labelRepository.SaveOrUpdate(l1);
                    labelRepository.SaveOrUpdate(l2);

                    Project p1 = TestHelperFactory.NewProject(1);
                    Project p2 = TestHelperFactory.NewProject(2);
                    p1.AddLink(l1);
                    p1.AddLink(l2);
                    p2.AddLink(l2);

                    projectRepository.SaveOrUpdate(p1);
                    projectRepository.SaveOrUpdate(p2);

                    transaction.Commit();

                    projectRepository.BeginTransaction();
                    projectRepository.Delete(p1);
                    projectRepository.Delete(p2);
                    projectRepository.Commit();

                    labelRepository.BeginTransaction();
                    labelRepository.Delete(l1);
                    labelRepository.Delete(l2);
                    labelRepository.Commit();
                }
            }
        }
    }
}
