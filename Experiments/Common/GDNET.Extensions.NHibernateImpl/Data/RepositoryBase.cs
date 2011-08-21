using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Linq;

using GDNET.Common.Data;
using GDNET.Common.DesignByContract;
using GDNET.Common.Domain;

namespace GoogleCode.Core.Data
{
    /// <summary>
    /// Base Repository for working with NHibernate
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public abstract class RepositoryBase<TObject, TId> : IDisposable, IRepositoryBase<TObject, TId> where TObject : DomainBase<TId>
    {
        protected ISession session = null;
        protected ITransaction transaction = null;

        public RepositoryBase(ISession session)
        {
            Throw.ArgumentNullException(session, "session", "Session must be specified.");
            this.session = session;
        }

        #region IDisposable Members

        /// <summary>
        /// Disposes of this instance of the Repository.
        /// </summary>
        /// <param name="isDisposing">Flag that tells the .NET runtime if this class is disposing.</param>
        /// <remarks>This method kills the existing NHibernate session, transaction, and interceptor.</remarks>
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (this.transaction != null)
                {
                    this.transaction.Dispose();
                    this.transaction = null;
                }

                if (this.session != null)
                {
                    this.session.Dispose();
                    this.session = null;
                }
            }
        }

        /// <summary>
        /// Disposes of this instance of the Repository.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IRepositoryBase<TObject,TId> Members

        /// <summary>
        /// Begins a NHibernate transaction.
        /// </summary>
        public void BeginTransaction()
        {
            if (this.transaction == null)
            {
                this.transaction = this.session.BeginTransaction();
            }
        }

        /// <summary>
        /// Commits an NHibernate transaction.
        /// </summary>
        public void Commit()
        {
            Throw.InvalidOperationExceptionIfNull(this.transaction, "You must begin transaction before calling Commit.");

            this.transaction.Commit();
            this.transaction = null;
        }

        /// <summary>
        /// Rolls back an NHibernate transaction.
        /// </summary>
        public void Rollback()
        {
            Throw.InvalidOperationExceptionIfNull(this.transaction, "You must begin transaction before calling Rollback.");

            this.transaction.Rollback();
            this.transaction = null;
        }

        public TObject LoadById(TId id)
        {
            return this.session.Load<TObject>(id);
        }

        public TObject GetById(TId id)
        {
            return this.session.Get<TObject>(id);
        }

        public IList<TObject> GetAll()
        {
            return this.session.Query<TObject>().ToList();
        }

        public TObject SaveOrUpdate(TObject entity)
        {
            Throw.ArgumentNullException(entity, "entity", "Entity must be valid to be saved.");

            this.session.SaveOrUpdate(entity);
            return entity;
        }

        public void Delete(TObject entity)
        {
            Throw.ArgumentNullException(entity, "entity", "Entity must be valid to be deleted.");

            this.session.Delete(entity);
        }

        #endregion
    }
}
