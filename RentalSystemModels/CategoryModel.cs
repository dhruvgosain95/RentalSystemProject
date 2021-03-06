﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystemModels
{
    public class CategoryModel
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
    }
}
