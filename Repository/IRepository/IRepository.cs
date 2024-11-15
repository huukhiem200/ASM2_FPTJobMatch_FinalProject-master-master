﻿using System.Linq.Expressions;

namespace FPT_JOBPORTAL.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Add(T entity);
        void Delete(T entity);
        void Save();
    }
}
