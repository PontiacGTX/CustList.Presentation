
using CustList.Common;
using CustList.Entities.Entities;
using CustList.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustList.Services
{
    public class CustomerServices : IEntityService<Customer>
    {
        private IEntityRepository<Customer> _customerRepo;
        
        public CustomerServices(IEntityRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public async Task<Response<Customer>> Add(Customer entity)
        {
            var ent = await _customerRepo.Add(entity);
            return Factory.GetResponse<Response<Customer>, Customer>(ent);
        }

        public async Task<Response<bool>> Any<TId>(TId id)
        {
            var res = await _customerRepo.Any(id);
            return Factory.GetResponse<Response<bool>,bool>(res);
        }

        public async Task<Response<bool>> Any(Expression<Func<Customer, bool>> selector)
        {
            var res = await _customerRepo.Any(selector);
            return Factory.GetResponse<Response<bool>, bool>(res);
        }

        public async Task<Response<long>> Count()
        {
            var res = await _customerRepo.Count();
            return Factory.GetResponse<Response<long>, long>(res);
        }

        public async Task<Response<long>> Count(Expression<Func<Customer, bool>> selector)
        {
            var res =  await _customerRepo.Count(selector);
            return Factory.GetResponse<Response<long>, long>(res);
        }

        public async  Task<Response<Customer>> First(Expression<System.Func<Customer, bool>> selector)
        {
            var res = await _customerRepo.First(selector);
            return Factory.GetResponse<Response<Customer>, Customer>(res);
        }

        public async Task<Response<Customer>> Get<TId>(TId id)
        {
            var res = await _customerRepo.Get(id);
            return Factory.GetResponse<Response<Customer>, Customer>(res);
        }

        public async Task<Response<IList<Customer>>> GetAll()
        {
            var res = await _customerRepo.GetAll();
            return Factory.GetResponse<Response<IList<Customer>>, IList<Customer>>(res);
        }

        public async Task<Response<IList<Customer>>> GetAll(Expression<Func<Customer, bool>> selector)
        {
            var res = await _customerRepo.GetAll(selector);
            return Factory.GetResponse<Response<IList<Customer>>, IList<Customer>>(res);
        }

        public async Task<Response<bool>> Remove(Customer entity)
        {
            var res = await _customerRepo.Remove(entity);
            return Factory.GetResponse<Response<bool>, bool>(res);
        }

        public async Task<Response<bool>> Remove<TId>(TId id)
        {
            var res = await _customerRepo.Remove(id);
            return Factory.GetResponse<Response<bool>, bool>(res);
        }

        public async  Task<Response<Customer>> Update(Customer entity)
        {
            var res = await _customerRepo.Update(entity);
            return Factory.GetResponse<Response<Customer>, Customer>(res);
        }
    }
}