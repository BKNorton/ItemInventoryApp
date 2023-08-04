using ItemInventory.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItemInventory.API.Repositories
{
    public interface IRepository<T> 
    {
        Task<ActionResult<T>> Add(T entity);
        Task<ActionResult> Delete(Guid id);
        Task<ActionResult<T>>? Get(Guid id);
        Task<IActionResult> Update(T entity);
        Task<ActionResult<IEnumerable<T>>>? GetAll();
        Task<ActionResult<List<T>>> Find(Expression<Func<T, bool>> predicate);
        Task<ActionResult> SaveChanges();
        bool IsNull();
    }
}
