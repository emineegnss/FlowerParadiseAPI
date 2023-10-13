using FlowerParadiseAPI.Domain.Entities;
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

    }
}
