using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Permission.Models.Context;

namespace Permission.Models.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        T GetById(int id);
        T Create(T entity);
        void Update(T entity);
        void Delete(int id);
        void SaveChanges();
    }
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class

    {
        private readonly PermissionDataContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(PermissionDataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            context.Database.EnsureCreated();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual T Create(T entity)
        {
            _dbSet.Add(entity);
            SaveChanges();
            return entity;
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
            SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var exist = _dbSet.Find(id);
            _dbSet.Remove(exist);
            SaveChanges();
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

