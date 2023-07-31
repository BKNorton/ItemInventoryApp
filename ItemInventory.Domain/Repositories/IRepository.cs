using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItemInventory.Domain.Repositories
{
    internal interface IRepository<T> 
    {
        T Add(T entity);
        T Delete(T entity); 
        T Get(Guid id);
        T Update(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
