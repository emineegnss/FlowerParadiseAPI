using FlowerParadiseAPI.Application.Repositories;
using FlowerParadiseAPI.Persistence.Contexts;
using FlowerParadiseAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerParadiseAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<FlowerParadiseDbContext>(options=>options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<IFlowerRepository, FlowerRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IFlowerSpeciesRepository, FlowerSpeciesRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
        }
    }
}
