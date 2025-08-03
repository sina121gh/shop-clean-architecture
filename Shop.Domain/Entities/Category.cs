﻿using Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
