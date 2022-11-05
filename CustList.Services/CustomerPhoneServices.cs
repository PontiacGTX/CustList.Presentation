using CustList.Common;
using CustList.Entities.Entities;
using CustList.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustList.Services
{
    public class CustomerPhoneServices : IEntityService<CustomerPhone>
    {
        private IEntityRepository<CustomerPhone> _CustomerPhoneRepo;

        public CustomerPhoneServices(IEntityRepository<CustomerPhone> customerRepo)
        {
            _CustomerPhoneRepo = customerRepo;
        }
        public async Task<Response<CustomerPhone>> Add(CustomerPhone entity)
        {
            var ent = await _CustomerPhoneRepo.Add(entity);
            return Factory.GetResponse<Response<CustomerPhone>, CustomerPhone>(ent);
        }

        public async Task<Response<bool>> Any<TId>(TId id)
        {
            var res = await _CustomerPhoneRepo.Any(id);
            return Factory.GetResponse<Response<bool>, bool>(res);
        }

        public async Task<Response<bool>> Any(Expression<Func<CustomerPhone, bool>> selector)
        {
            var res = await _CustomerPhoneRepo.Any(selector);
            return Factory.GetResponse<Response<bool>, bool>(res);
        }

        public async Task<Response<long>> Count()
        {
            var res = await _CustomerPhoneRepo.Count();
            return Factory.GetResponse<Response<long>, long>(res);
        }

        public async Task<Response<long>> Count(Expression<Func<CustomerPhone, bool>> selector)
        {
            var res = await _CustomerPhoneRepo.Count(selector);
            return Factory.GetResponse<Response<long>, long>(res);
        }

        public async Task<Response<CustomerPhone>> First(Expression<Func<CustomerPhone, bool>> selector)
        {
            var res = await _CustomerPhoneRepo.First(selector);
            return Factory.GetResponse<Response<CustomerPhone>, CustomerPhone>(res);
        }

        public async Task<Response<CustomerPhone>> Get<TId>(TId id)
        {
            var res = await _CustomerPhoneRepo.Get(id);
            return Factory.GetResponse<Response<CustomerPhone>, CustomerPhone>(res);
        }

        public async Task<Response<IList<CustomerPhone>>> GetAll()
        {
            var res = await _CustomerPhoneRepo.GetAll();
            return Factory.GetResponse<Response<IList<CustomerPhone>>, IList<CustomerPhone>>(res);
        }

        public async Task<Response<IList<CustomerPhone>>> GetAll(Expression<Func<CustomerPhone, bool>> selector)
        {
            var res = await _CustomerPhoneRepo.GetAll(selector);
            return Factory.GetResponse<Response<IList<CustomerPhone>>, IList<CustomerPhone>>(res);
        }

        public async Task<Response<bool>> Remove(CustomerPhone entity)
        {
            var res = !await _CustomerPhoneRepo.Remove(entity);
            return Factory.GetResponse<Response<bool>, bool>(res);
        }

        public async Task<Response<bool>> Remove<TId>(TId id)
        {
            var res = !await _CustomerPhoneRepo.Remove(id);
            return Factory.GetResponse<Response<bool>, bool>(res);
        }

        public async Task<Response<CustomerPhone>> Update(CustomerPhone entity)
        {
            var res = await _CustomerPhoneRepo.Update(entity);
            return Factory.GetResponse<Response<CustomerPhone>, CustomerPhone>(res);
        }
    }
}
