using Microsoft.EntityFrameworkCore;
using MotoApp.Entities;
using System.Collections.Generic;

namespace MotoApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbSet<T> _dbset;
        private readonly DbContext _dbContext;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }
        public T? GetById(int id)
        {
            return _dbset.Find(id);
        }

        public void Add(T item)
        {
            _dbset.Add(item);
        }

        public void Remove(T item)
        {
            _dbset.Remove(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}