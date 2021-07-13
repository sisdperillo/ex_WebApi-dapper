using System;

namespace ExDapper.WebApi.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
