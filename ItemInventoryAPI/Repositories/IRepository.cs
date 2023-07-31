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
        T Add(T entity);
        void Delete(Guid id);
        Task<ActionResult<T>>? Get(Guid id);
        T Update(T entity);
        public Task<ActionResult<IEnumerable<T>>>? GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();
        bool IsNull();
    }
}
