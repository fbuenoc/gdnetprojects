using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;

using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace GoogleCode.Data.Tests
{
    using GDNET.Extensions.NHibernateImpl;
    using GoogleCode.Core.Data;
    using GoogleCode.Core.Domain;
    using GoogleCode.Data.Mapping;

    [TestFixture]
    public class LabelRepositoryTests
    {
        #region TestFixture Methods

        [SetUp]
        public void SetUp()
        {
            NHSessionManager.Initialize(MappingUtil.GetHbmMapping(), TestConstants.DefaultCfgFile);
            NHibernateProfiler.Initialize();
        }

        [TearDown]
        public void TearDown()
        {
            NHSessionManager.Release();
        }

        #endregion

        #region SaveOrUpdate Tests

        [Test]
        public void SaveOrUpdateTest()
        {
            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    repository.BeginTransaction();

                    Label l1 = new Label { Name = "Label 1" };
                    repository.SaveOrUpdate(l1);

                    repository.Commit();
                    Assert.IsTrue(l1.Id > 0);

                    repository.BeginTransaction();
                    repository.Delete(l1);
                    repository.Commit();
                }
            }
        }

        [Test]
        public void SaveOrUpdateTest_WithProject()
        {
            using (var session = NHSessionManager.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var labelRepository = new LabelRepository(session);
                    var projectRepository = new ProjectRepository(session);

                    Project p1 = TestHelperFactory.NewProject(1);
                    Project p2 = TestHelperFactory.NewProject(2);
                    projectRepository.SaveOrUpdate(p1);
                    projectRepository.SaveOrUpdate(p2);

                    Label l1 = TestHelperFactory.NewLabel(1);
                    l1.AddLink(p1);
                    l1.AddLink(p2);

                    Label l2 = TestHelperFactory.NewLabel(2);
                    l2.AddLink(p1);

                    labelRepository.SaveOrUpdate(l1);
                    labelRepository.SaveOrUpdate(l2);

                    transaction.Commit();

                    labelRepository.BeginTransaction();
                    labelRepository.Delete(l1);
                    labelRepository.Delete(l2);
                    labelRepository.Commit();

                    projectRepository.BeginTransaction();
                    projectRepository.Delete(p1);
                    projectRepository.Delete(p2);
                    projectRepository.Commit();
                }
            }
        }

        #endregion

        #region GetAll Tests

        [Test]
        public void GetAllTest()
        {
            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    var results1 = repository.GetAll();

                    repository.BeginTransaction();

                    Label l1 = new Label { Name = "Label 1" };
                    repository.SaveOrUpdate(l1);

                    repository.Commit();

                    var results2 = repository.GetAll();
                    Assert.AreEqual(results2.Count, results1.Count + 1);
                    Assert.IsNotNull(results2.First(label => label.Id == l1.Id));

                    repository.BeginTransaction();
                    repository.Delete(l1);
                    repository.Commit();
                }
            }
        }

        [Test]
        public void GetAllTest_With2ndCache()
        {
            Label l1 = new Label { Name = "Label 1" };
            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    var results1 = repository.GetAll();

                    repository.BeginTransaction();
                    repository.SaveOrUpdate(l1);
                    repository.Commit();
                    Console.WriteLine("Saved---");

                    Console.WriteLine("Get all 1---");
                    var results2 = repository.GetAll();
                    Assert.AreEqual(results2.Count, results1.Count + 1);
                    Assert.IsNotNull(results2.First(label => label.Id == l1.Id));
                }
            }

            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    Console.WriteLine("Get all 2---");
                    var results = repository.GetAll();
                    Console.WriteLine("Get all 3---");
                    var results3 = repository.GetAll();

                    repository.BeginTransaction();
                    repository.Delete(l1.Id);
                    repository.Commit();
                }
            }
        }

        [Test]
        public void GetAllTest_Paging()
        {
            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    repository.BeginTransaction();

                    Label l1 = new Label { Name = "Label 1" };
                    Label l2 = new Label { Name = "Label 2" };
                    repository.SaveOrUpdate(l1);
                    repository.SaveOrUpdate(l2);

                    repository.Commit();

                    var results1 = repository.GetAll(0, 1);
                    var results2 = repository.GetAll(1, 1);

                    Assert.AreEqual(1, results1.Count);
                    Assert.AreEqual(1, results2.Count);
                    Assert.AreNotEqual(results1[0].Id, results2[0].Id);

                    repository.BeginTransaction();
                    repository.Delete(l1);
                    repository.Delete(l2);
                    repository.Commit();
                }
            }
        }

        #endregion

        [Test]
        public void FindByPropertyTest()
        {
            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    repository.BeginTransaction();

                    Label l1 = new Label { Name = "Label 1" };
                    repository.SaveOrUpdate(l1);

                    repository.Commit();

                    var results = repository.FindByProperty("Name", "Label 1");
                    Assert.IsTrue(results.Count > 0);

                    repository.BeginTransaction();
                    repository.Delete(l1);
                    repository.Commit();
                }
            }
        }

        [Test]
        public void FindByPropertyTest_In()
        {
            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    repository.BeginTransaction();

                    Label l1 = new Label { Name = "Label 1" };
                    Label l2 = new Label { Name = "Label 2" };
                    repository.SaveOrUpdate(l1);
                    repository.SaveOrUpdate(l2);

                    repository.Commit();

                    var results = repository.FindByProperty("Name", new string[] { "Label 1", "Label 2" });
                    Assert.IsTrue(results.Count >= 2);

                    repository.BeginTransaction();
                    repository.Delete(l1);
                    repository.Delete(l2);
                    repository.Commit();
                }
            }
        }

        [Test]
        public void FindByPropertyTestWithOrder()
        {
            Label l1 = new Label { Name = "Label 1" };
            Label l2 = new Label { Name = "Label 2" };

            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    repository.BeginTransaction();

                    repository.SaveOrUpdate(l1);
                    repository.SaveOrUpdate(l2);

                    repository.Commit();
                }
            }

            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    var results = repository.FindByProperty("Name", "Label 1", new Order("Id", true));
                    Assert.IsTrue(results.Count > 0);

                    Console.WriteLine("Merging------");
                    var l1m = session.Merge(l1);
                    var l2m = session.Merge(l2);

                    Console.WriteLine("Deleting------");
                    repository.BeginTransaction();
                    repository.Delete(l1m);
                    repository.Delete(l2m);
                    repository.Commit();
                }
            }
        }


        [Test]
        public void RollbackTest()
        {
            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    var results1 = repository.GetAll();

                    repository.BeginTransaction();

                    Label l1 = new Label { Name = "Label 1" };
                    repository.SaveOrUpdate(l1);

                    repository.Rollback();

                    var results2 = repository.GetAll();
                    Assert.AreEqual(results2.Count, results1.Count);
                }
            }
        }

        #region LoadById Tests

        [Test]
        public void LoadByIdTest()
        {
            int labelId = 0;
            string labelName = string.Empty;
            using (var session = NHSessionManager.OpenSession())
            {
                Label l1 = new Label { Name = "Label 1" };
                using (var repository = new LabelRepository(session))
                {
                    repository.BeginTransaction();
                    repository.SaveOrUpdate(l1);
                    repository.Commit();

                    labelId = l1.Id;
                    labelName = l1.Name;
                }
            }

            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    var result = repository.LoadById(labelId);
                    Assert.AreEqual(labelId, result.Id);

                    Console.WriteLine("---");
                    Console.WriteLine("Compare name of label, from now NHibernate will execute a query");
                    Console.WriteLine("---");

                    Assert.AreEqual(labelName, result.Name);

                    repository.BeginTransaction();
                    repository.Delete(result);
                    repository.Commit();
                }
            }
        }

        [Test, ExpectedException(typeof(ObjectNotFoundException))]
        public void LoadByIdTest_NotFould()
        {
            using (var session = NHSessionManager.OpenSession())
            {
                Label l1 = new Label { Name = "Label 1" };
                using (var repository = new LabelRepository(session))
                {
                    var result1 = repository.LoadById(l1.Id);
                    var name = result1.Name;
                }
            }
        }

        #endregion

    }
}
