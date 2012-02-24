﻿using System.IO;
using GDNET.Common.DesignByContract;
using GDNET.NHibernate;
using GDNET.NHibernate.SessionManagers;
using NHibernate;

namespace WebFrameworkNHibernate.SessionManagers
{
    public sealed class AppStaticSessionManager : AbstractSessionManager
    {
        #region Singleton

        private static class NestedSessionManager
        {
            public static readonly AppStaticSessionManager SessionManager = new AppStaticSessionManager();
        }

        public new static SessionManager Instance
        {
            get { return NestedSessionManager.SessionManager; }
        }

        #endregion

        static AppStaticSessionManager()
        {
            if (_sessionFactory == null)
            {
                var mapper = AbstractSessionManager.BuildModelMapper();

                string directoryName = Path.GetDirectoryName(typeof(AppStaticSessionManager).Assembly.Location);
                string nhConfigPath = Path.Combine(directoryName, "App_Data/hibernate.cfg.xml");
                AbstractSessionManager._sessionFactory = NHibernateAssistant.BuildSessionFactory(nhConfigPath, mapper);
            }
            else
            {
                ThrowException.InvalidOperationException("Can't init SessionFactory twice.");
            }

            SessionManager.Instance = NestedSessionManager.SessionManager;
        }

        public override ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }

        public override ISession OpenSession()
        {
            return this.SessionFactory.OpenSession();
        }
    }
}