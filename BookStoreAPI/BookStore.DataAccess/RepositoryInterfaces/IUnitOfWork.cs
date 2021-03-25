using BookStore.DataAccess.DatabaseContext;
using System;

namespace BookStore.DataAccess.RepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsTransactionActive { get; }
        BookStoreDbContext Context { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
