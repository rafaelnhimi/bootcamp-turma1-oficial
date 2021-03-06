﻿using Microsoft.EntityFrameworkCore;
using NetCoreEntityFramework.Context;
using System.Threading.Tasks;

namespace NetCoreEntityFramework.Utils
{
    public abstract class RepositoryUsuarioContext<TDomain> where TDomain : class
    {
        protected readonly UsuarioContext _context;

        public RepositoryUsuarioContext(UsuarioContext context)
        {
            _context = context;
        }

        public virtual void Add(TDomain entity)
        {
            _context.Set<TDomain>().Add(entity);
        }

        public virtual async Task AddAsync(TDomain entity)
        {
            await _context.Set<TDomain>().AddAsync(entity);
        }

        public virtual void Delete(TDomain entity)
        {
            _context.Set<TDomain>().Remove(entity);
        }

        public virtual async Task DeleteAsync(TDomain entity)
        {
            await Task.FromResult(_context.Set<TDomain>().Remove(entity));
        }

        public virtual void Update(TDomain entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TDomain>().Update(entity);
        }

        public async Task UpdateAsync(TDomain entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Task.FromResult(_context.Set<TDomain>().Update(entity));
        }
    }
}
