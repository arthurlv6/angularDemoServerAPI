﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ProductPropertyModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}
