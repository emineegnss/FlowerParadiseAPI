﻿using FlowerParadiseAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerParadiseAPI.Domain.Entities
{
    public class FlowerSpecies : BaseEntity
    {
        public string SpeciesName { get; set; }
        public ICollection<Flower> Flowers { get; set; }
    }
}
