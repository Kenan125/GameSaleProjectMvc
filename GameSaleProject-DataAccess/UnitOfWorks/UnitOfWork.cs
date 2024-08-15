using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_DataAccess.Repositories;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameSaleProjectDbContext _context;
        private bool disposed = false;
        public UnitOfWork(GameSaleProjectDbContext context)  //DI Container
        {
            _context = context;
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);  //GC - Garbage Collector
        }
    }
}
