using CustList.Entities;
using CustList.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustList.EntityRepository
{
    public class CustomersRepository : IEntityRepository<Customer>
    {
        private AppDbContext _ctx;

        public CustomersRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Customer> Add(Customer entity)
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
                return await _ctx.Customers.AnyAsync(x=>x.cId ==idC);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Any(Expression<Func<Customer, bool>> selector)
        {
            try
            {
                return await _ctx.Customers.AnyAsync(selector);
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
                return await _ctx.Customers.LongCountAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<long> Count(Expression<Func<Customer, bool>> selector)
        {
            try
            {
                return await _ctx.Customers.LongCountAsync(selector);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Customer> First(Expression<Func<Customer, bool>> selector)
        {
            try
            {
                return await _ctx.Customers.Include(x=>x.CustomerPhones).FirstOrDefaultAsync(selector)!;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Customer> Get<TId>(TId id)
        {
            try
            {
                int idC = Convert.ToInt32(id);
                return await _ctx.Customers.Include(x=>x.CustomerPhones).FirstOrDefaultAsync( x=>x.cId == idC)!;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IList<Customer>> GetAll()
        {
            try
            {
                return await _ctx.Customers.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IList<Customer>> GetAll(Expression<Func<Customer, bool>> selector)
        {
            try
            {
                return await _ctx.Customers.Include(x=>x.CustomerPhones).Where(selector).ToListAsync()!;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Remove(Customer entity)
        {
            try
            {
                foreach(var phone in _ctx.CustomerPhones.Where(x => x.cId == entity.cId))
                {
                    _ctx.CustomerPhones.Remove(phone);
                }
                await _ctx.SaveChangesAsync();

                _ctx.Customers.Remove(entity);

                await _ctx.SaveChangesAsync();

                return await this.Any(x => x.cId == entity.cId);
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
                foreach (var phone in _ctx.CustomerPhones.Where(x => x.cId == cId))
                {
                    _ctx.CustomerPhones.Remove(phone);
                }
                await _ctx.SaveChangesAsync();

                var entity = await Get(id);

                if (entity == null)
                    return true;

                _ctx.Customers.Remove(entity);

                await _ctx.SaveChangesAsync();

                return await this.Any(x => x.cId == entity.cId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Customer> Update(Customer entity)
        {
            try
            {
                var updEntity = await Get(entity.cId);
                _ctx.Entry(updEntity).CurrentValues.SetValues(entity);

                await _ctx.SaveChangesAsync();

                return await First(x => x.cId == entity.cId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
