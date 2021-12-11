using Application.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        //public readonly TenantData TenantData;

        public ApplicationContext(DbContextOptions<ApplicationContext> options/*,TenantData tenant*/) : base(options)
        {
            // TenantData = tenant;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema(TenantData.TenantId);

            //modelBuilder.Entity<Person>().HasQueryFilter(p=>p.TenantId == TenantData.TenantId);
            //modelBuilder.Entity<Product>().HasQueryFilter(p=>p.TenantId == TenantData.TenantId);
        }
    }
}
