using BookStore.DataAccess.DatabaseContext;
using BookStore.DataAccess.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace BookStore.DataAccess.RepositoryImplementations
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private members

        private IDbContextTransaction _transaction;

        #endregion

        #region Constructors

        public UnitOfWork(BookStoreDbContext context)
        {
            Context = context;
        }

        #endregion

        #region Public properties

        public BookStoreDbContext Context { get; }

        #endregion

        #region Interface implementation

        public bool IsTransactionActive
        {
            get
            {
                return (Context.Database.CurrentTransaction != null);
            }
        }

        public void BeginTransaction()
        {
            _transaction = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (IsTransactionActive)
            {
                try
                {
                    _transaction.Commit();
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();
                    throw;
                }
                finally
                {
                    _transaction.Dispose();
                }
            }
        }

        public void Rollback()
        {
            if (IsTransactionActive)
            {
                try
                {
                    _transaction.Rollback();
                }
                finally
                {
                    _transaction.Dispose();
                }
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }

        #endregion
    }
}
