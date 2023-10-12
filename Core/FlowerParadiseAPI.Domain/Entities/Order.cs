using FlowerParadiseAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerParadiseAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public ICollection<Flower> Flowers { get; set; }
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
    }
}
