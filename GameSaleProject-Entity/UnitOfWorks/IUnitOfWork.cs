using GameSaleProject_Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;

        void Commit();  //içine SaveChanges() gelecek.

        void CommitAsync();
    }
}
