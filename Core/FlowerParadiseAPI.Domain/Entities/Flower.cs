using FlowerParadiseAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerParadiseAPI.Domain.Entities
{
    public class Flower : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }

        public float Price { get; set; }

        
    }
}
