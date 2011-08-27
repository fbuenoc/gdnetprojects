using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Extensions.NHibernateImpl;
using GoogleCode.Core.Domain;
using GoogleCode.Data;
using GoogleCode.Data.Mapping;

using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace GoogleCode.TestSecondLevelCache
{
    class Program
    {
        private const string DefaultCfgFile = "hibernate.cfg.xml";

        static void Main(string[] args)
        {
            NHibernateProfiler.Initialize();
            NHSessionManager.Initialize(MappingUtil.GetHbmMapping(), DefaultCfgFile);

            Label l1 = new Label { Name = "Label 1" };
            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    var results1 = repository.GetAll();
                    var results2 = repository.GetAll();

                    repository.BeginTransaction();
                    repository.SaveOrUpdate(l1);
                    repository.Commit();

                    Console.WriteLine("New label saved, let's modify it directly in database");
                    Console.ReadLine();
                }
            }

            using (var session = NHSessionManager.OpenSession())
            {
                using (var repository = new LabelRepository(session))
                {
                    var results1 = repository.GetAll();

                    Label l2 = repository.GetById(l1.Id);

                    Console.WriteLine("Label: " + l2.Name);
                    Console.ReadLine();

                    repository.BeginTransaction();
                    repository.Delete(l2);
                    repository.Commit();
                }
            }
        }
    }
}
