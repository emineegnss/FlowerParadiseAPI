using FlowerParadiseAPI.Domain.Entities;
using FlowerParadiseAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerParadiseAPI.Persistence.Contexts
{
    public class FlowerParadiseDbContext : DbContext
    {
        public FlowerParadiseDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FlowerSpecies> Species { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Color> Colors { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           var datas =  ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                var _ = data.State switch
                {
                    EntityState.Added => data.Entity.UpdateDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow
                }; 
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
