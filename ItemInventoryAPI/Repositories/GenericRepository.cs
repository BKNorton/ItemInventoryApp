
using ItemInventory.API.DTOModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItemInventory.API.Repositories
{
    public abstract class GenericRepository<T>
        : IRepository<T> where T : class
    {
        protected readonly ItemInventoryContext _context;

        public GenericRepository(ItemInventoryContext context)
        {
            _context = context;
        }
        public virtual T Add(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public virtual void Delete(Guid id)
        {
            _context.Remove(id);
            SaveChanges();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }

        public async virtual Task<ActionResult<T>>? Get(Guid id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async virtual Task<ActionResult<IEnumerable<T>>>? GetAll()
        {
            return  await _context.Set<T>().ToListAsync();
        }
        public virtual T Update(T entity)
        {
            return _context.Update(entity).Entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool IsNull()
        {
            var x = _context.Set<T>();
            if (x == null) return true;
            else return false;
        }
    }
}
