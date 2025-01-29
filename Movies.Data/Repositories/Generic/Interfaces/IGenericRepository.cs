﻿namespace Movies.Data.Repositories.Generic.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByGenericPropertyAsync<TProperty>(string propertyName, TProperty value);
        void AddAsync(T t);
        void Update(T t);
        void Remove(T t);
    }
}
