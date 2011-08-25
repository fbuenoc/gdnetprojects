using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using GDNET.Extensions.NHibernateImpl;
using GoogleCode.Data.Mapping;

namespace GoogleCode.GenerateRandomData
{
    class Program
    {
        private const string DefaultCfgFile = "hibernate.cfg.xml";

        static void Main(string[] args)
        {
            NHibernateProfiler.Initialize();
            NHSessionManager.Initialize(MappingUtil.GetHbmMapping(), DefaultCfgFile);

            using (var session = NHSessionManager.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    RandomData.Create(session);
                    transaction.Commit();
                }
            }
        }
    }
}
