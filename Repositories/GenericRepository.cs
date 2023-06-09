﻿using CVApplicationsManager.Contracts;
using CVApplicationsManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace CVApplicationsManager.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            var entity = await GetAsync(id);

            if (entity is not null)
            {
                _context.Set<T>().Remove(entity);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int? id)
        {
            var entity = await GetAsync(id);

            if (entity is not null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int? id)
        {
            if (id is null)
            {
                throw new Exception("Not found");
            }
            var entity = await _context.Set<T>().FindAsync(id); //set<T>() is a generic table relative to T. Any table used with this method

            if (entity is null)
            {
                throw new Exception($"No records found with the Id : {id}");
            }

            return entity is null ? throw new Exception("Not found") : entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
