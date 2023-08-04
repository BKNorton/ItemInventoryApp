
using ItemInventory.API.DTOModels;
using ItemInventory.API.Models;
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
        public async virtual Task<ActionResult<T>> Add(T entity)
        {
            return new OkObjectResult( await _context.AddAsync(entity));
        }

        public async virtual Task<ActionResult> Delete(Guid id)
        {
            var item = await _context.Set<T>().FindAsync(id);
            if (item == null)
            {
                return new NotFoundObjectResult(item);
            }
            _context.Remove(item);
            return await SaveChanges();
        }

        public async virtual Task<ActionResult<List<T>>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .AsQueryable()
                .Where(predicate)
                .ToListAsync();
        }

        public async virtual Task<ActionResult<T>>? Get(Guid id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async virtual Task<ActionResult<IEnumerable<T>>>? GetAll()
        {
            return  await _context.Set<T>().ToListAsync();
        }
        public async virtual Task<IActionResult> Update(T entity)
        {
            return new OkObjectResult(_context.Update(entity));
        }

        public async virtual Task<ActionResult> SaveChanges()
        {
            return new OkObjectResult(await _context.SaveChangesAsync());
        }

        public bool IsNull()
        {
            var x = _context.Set<T>();
            if (x == null) return true;
            else return false;
        }
    }
}
