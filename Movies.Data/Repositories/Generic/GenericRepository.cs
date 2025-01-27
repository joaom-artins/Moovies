﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Movies.Core.Models.Base;
using Movies.Data.Context;
using Movies.Data.Repositories.Generic.Interfaces;

namespace Movies.Data.Repositories.Generic
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
    {
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().AsNoTracking().SingleOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
        }

        public  async Task<T?> GetByGenericPropertyAsync<TProperty>(string propertyName, TProperty value)
        {
            var propertyInfo = typeof(T).GetProperty(propertyName);
            if (propertyInfo is null)
            {
                return default!;
            }

            var parameter = Expression.Parameter(typeof(T), "x");

            var propertyAccess = Expression.Property(parameter, propertyInfo);

            var constant = Expression.Constant(value, typeof(TProperty));
            var equality = Expression.Equal(propertyAccess, constant);

            var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

            return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(lambda);

        }

        public async void AddAsync(T t)
        {
            await context.Set<T>().AddAsync(t);
        }

        public void Update(T t)
        {
            context.Set<T>().Update(t);
        }

        public void Remove(T t)
        {
            context.Set<T>().Remove(t);
        }
    }
}
