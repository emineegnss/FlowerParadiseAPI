﻿using FlowerParadiseAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerParadiseAPI.Domain.Entities
{
    public class Color : BaseEntity
    {
        public string ColorName { get; set; }
        public ICollection<Flower> Flowers { get; set; }
    }
}
