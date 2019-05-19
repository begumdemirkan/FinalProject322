﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject322.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        
        public IEnumerable<Category> Category { get; set; }
    }
}
