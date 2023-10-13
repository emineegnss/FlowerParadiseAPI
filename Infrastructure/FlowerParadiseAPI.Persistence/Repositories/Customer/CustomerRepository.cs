﻿using FlowerParadiseAPI.Application.Repositories;
using FlowerParadiseAPI.Domain.Entities;
using FlowerParadiseAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerParadiseAPI.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(FlowerParadiseDbContext context) : base(context)
        {
        }
    }
}
