using CustList.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustList.Entities
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }

        public  DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPhone> CustomerPhones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Customer>().HasKey(x => x.cId);
            modelBuilder.Entity<Customer>().Property(x => x.Name1).HasMaxLength(30).HasColumnName("cName1");
            modelBuilder.Entity<Customer>().Property(x => x.Name2).HasMaxLength(30).HasColumnName("cName2");
            modelBuilder.Entity<Customer>().Property(x => x.LastName1).HasMaxLength(30).HasColumnName("cLastName1");
            modelBuilder.Entity<Customer>().Property(x => x.LastName2).HasMaxLength(30).HasColumnName("cLastName2");

            modelBuilder.Entity<CustomerPhone>().ToTable("CustomerPhones");
            modelBuilder.Entity<CustomerPhone>().HasKey(x=>x.cpId);
            modelBuilder.Entity<CustomerPhone>().Property(x=>x.cpPhone).HasMaxLength(20);
            modelBuilder.Entity<CustomerPhone>().HasOne(x=>x.Customer).WithMany(x=>x.CustomerPhones);

            base.OnModelCreating(modelBuilder);
        }
    }
}
