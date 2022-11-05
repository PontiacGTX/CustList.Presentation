using CustList.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustList.Services
{
    public interface IEntityService<T> where T :class
    {
        Task<Response<long>> Count();
        Task<Response<long>> Count(Expression<Func<T, bool>> selector);
        Task<Response<T>> Add(T entity);
        Task<Response<IList<T>>> GetAll();
        Task<Response<IList<T>>> GetAll(Expression<Func<T, bool>> selector);
        Task<Response<T>> First(Expression<Func<T, bool>> selector);
        Task<Response<T>> Get<TId>(TId id);
        Task<Response<bool>> Remove(T entity);
        Task<Response<bool>> Remove<TId>(TId id);
        Task<Response<T>> Update(T entity);

        Task<Response<bool>> Any<TId>(TId id);
        Task<Response<bool>> Any(Expression<Func<T, bool>> selector);
    }
}
