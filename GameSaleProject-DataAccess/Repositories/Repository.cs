﻿using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameSaleProject_DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GameSaleProjectDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(GameSaleProjectDbContext context)  //UnitOfWork
        {
            _context = context;         //ara katman - veritabanı
            _dbSet = _context.Set<T>(); //tablo
        }
        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);

        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);

        }
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);

        }
        public void Delete(T entity)
        {
            var isDeletedProperty = entity.GetType().GetProperty("IsDeleted");
            if (isDeletedProperty != null)
            {
                isDeletedProperty.SetValue(entity, true);
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity);
            }

        }
        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            foreach (var tablo in includes)
            {
                query = query.Include(tablo);
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync(
    Expression<Func<T, bool>> filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
    params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            // Apply filter if provided
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Apply includes for eager loading
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // Apply orderby if provided
            if (orderby != null)
            {
                query = orderby(query);
            }

            return await query.ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
