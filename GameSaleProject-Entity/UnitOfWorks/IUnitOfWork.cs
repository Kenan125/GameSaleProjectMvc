using GameSaleProject_Entity.Interfaces;

namespace GameSaleProject_Entity.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;

        void Commit();  //içine SaveChanges() gelecek.

        Task CommitAsync();
    }
}
