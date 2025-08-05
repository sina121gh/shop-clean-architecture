﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTOs.Category
{
    public record ShowCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
