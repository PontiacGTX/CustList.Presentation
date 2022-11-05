using CustList.Entities;
using CustList.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustList.EntityRepository
{
    public  class CustomerPhoneRepository : IEntityRepository<CustomerPhone>
    {
        private AppDbContext _ctx;

        public CustomerPhoneRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<CustomerPhone> Add(CustomerPhone entity)
        {
            try
            {
                var entry = _ctx.Add(entity);
                await _ctx.SaveChangesAsync();
                return entry.Entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Any<TId>(TId id)
        {
            try
            {
                int idC = Convert.ToInt32(id);
                return await _ctx.CustomerPhones.AnyAsync(x => x.cId == idC);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Any(Expression<Func<CustomerPhone, bool>> selector)
        {
            try
            {
                return await _ctx.CustomerPhones.AnyAsync(selector);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<long> Count()
        {
            try
            {
                return await _ctx.CustomerPhones.LongCountAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<long> Count(Expression<Func<CustomerPhone, bool>> selector)
        {
            try
            {
                return await _ctx.CustomerPhones.LongCountAsync(selector);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<CustomerPhone> First(Expression<Func<CustomerPhone, bool>> selector)
        {
            try
            {
                return await _ctx.CustomerPhones.Include(x => x.Customer).FirstOrDefaultAsync(selector)!;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<CustomerPhone> Get<TId>(TId id)
        {
            try
            {
                int idC = Convert.ToInt32(id);
                return await _ctx.CustomerPhones.Include(x => x.Customer).FirstOrDefaultAsync(x => x.cId == idC)!;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IList<CustomerPhone>> GetAll()
        {
            try
            {
                return await _ctx.CustomerPhones.Include(x => x.Customer).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IList<CustomerPhone>> GetAll(Expression<Func<CustomerPhone, bool>> selector)
        {
            try
            {
                return await _ctx.CustomerPhones.Include(x=>x.Customer).Where(selector).ToListAsync()!;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Remove(CustomerPhone entity)
        {
            try
            {
                var phone = await _ctx.CustomerPhones.Include(x => x.Customer).FirstOrDefaultAsync(x => x.cId == entity.cId);
                {
                    _ctx.CustomerPhones.Remove(phone);
                }
                await _ctx.SaveChangesAsync();

                return await this.Any(x => x.cpId == entity.cpId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Remove<TId>(TId id)
        {
            try
            {
                var cId = Convert.ToInt32(id);
                foreach (var phone in _ctx.CustomerPhones.Include(x => x.Customer).Where(x => x.cpId == cId))
                {
                    _ctx.CustomerPhones.Remove(phone);
                }
                await _ctx.SaveChangesAsync();

                return await this.Any(x => x.cId == cId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<CustomerPhone> Update(CustomerPhone entity)
        {
            try
            {
                var updEntity = await Get(entity.cId);
                _ctx.Entry(updEntity).CurrentValues.SetValues(entity);

                await _ctx.SaveChangesAsync();

                return await First(x => x.cpId == entity.cpId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
