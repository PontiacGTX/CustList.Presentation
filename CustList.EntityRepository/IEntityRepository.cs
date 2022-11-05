using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustList.EntityRepository
{
    public interface IEntityRepository<T> where T : class
    {
        Task<long> Count();
        Task<long> Count(Expression<Func<T, bool>> selector);
        Task<T> Add(T entity); 
        Task<IList<T>> GetAll(); 
        Task<IList<T>> GetAll(Expression<Func<T,bool>> selector); 
        Task<T> First(Expression<Func<T,bool>> selector); 
        Task<T> Get<TId>(TId id);
        Task<bool> Remove(T entity); 
        Task<bool> Remove<TId>(TId id);
        Task<T> Update(T entity);

        Task<bool> Any<TId>(TId id);
        Task<bool> Any(Expression<Func<T, bool>> selector);

    }
}
