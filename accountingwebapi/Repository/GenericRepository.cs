﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POSIMSWebApi;
using accountingwebapi.Context;
using accountingwebapi.Models.App;
using accountingwebapi.Interfaces.Repositories;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AcctgContext _context;
        public GenericRepository(AcctgContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            if(_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateRangeAsync<TEntity>(
            IEnumerable<TEntity> entities,
            Expression<Func<TEntity, bool>> predicate = null,
            Action<TEntity> updateAction = null,
            CancellationToken cancellationToken = default) where TEntity : class
        {
            if (entities == null || !entities.Any())
            {
                return 0;
            }

            // Apply custom update action if provided
            if (updateAction != null)
            {
                foreach (var entity in entities)
                {
                    updateAction(entity);
                }
            }

            // If a predicate is provided, filter and validate the entities
            if (predicate != null)
            {
                entities = entities.Where(predicate.Compile());
            }

            // Bulk update approach
            _context.Set<TEntity>().UpdateRange(entities);

            // Save changes and return the number of affected rows
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public async Task<int> InsertAndGetIdAsync(T entity)
        {
            var entityEntry = _context.Set<T>().Add(entity);

            await _context.SaveChangesAsync();

            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty == null)
            {
                throw new InvalidOperationException($"The entity type {typeof(T).Name} does not have a property named 'Id'.");
            }

            return (int)idProperty.GetValue(entity);
        }

        public async Task<Guid> InsertAndGetGuidAsync(T entity)
        {
            var entityEntry = _context.Set<T>().Add(entity);

            await _context.SaveChangesAsync();

            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty == null)
            {
                throw new InvalidOperationException($"The entity type {typeof(T).Name} does not have a property named 'Id'.");
            }

            return (Guid)idProperty.GetValue(entity);
        }

        public async Task<string> AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await _context.Set<T>().AddRangeAsync(entities);
                return "Success!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public async Task<T> FirstOrDefaultAsync(int Id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == Id);
        }

        public async Task<T> FirstOrDefaultAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public T FirstOrDefault(int id)
        {
            return _context.Set<T>().FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
        }

        public T FirstOrDefault(Guid id)
        {
            return _context.Set<T>().FirstOrDefault(e => EF.Property<Guid>(e, "Id") == id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task<IQueryable<T>> FindAsyncQueryable(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetByGuid(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            if (entity is AuditedEntity deletableEntity)
            {
                deletableEntity.IsDeleted = true;
                deletableEntity.DeletionTime = DateTime.UtcNow;
                _context.Set<T>().Update(entity); // Ensure EF tracks this as modified
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is AuditedEntity deletableEntity)
                {
                    deletableEntity.IsDeleted = true;
                    deletableEntity.DeletionTime = DateTime.UtcNow;
                }
            }
            _context.Set<T>().UpdateRange(entities); // Mark all as modified
        }

        public async Task RemoveAsync(T entity)
        {
            if (entity is AuditedEntity deletableEntity)
            {
                deletableEntity.IsDeleted = true;
                deletableEntity.DeletionTime = DateTime.UtcNow;
                _context.Set<T>().Update(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is AuditedEntity deletableEntity)
                {
                    deletableEntity.IsDeleted = true;
                    deletableEntity.DeletionTime = DateTime.UtcNow;
                }
            }
            _context.Set<T>().UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
