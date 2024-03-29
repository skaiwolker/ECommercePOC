﻿using eCommerce.Domain.Models.Base;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace eCommerce.Domain.Models
{
    public class Product : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Department { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }

        public virtual List<ProductImage> ProductImages { get; set; }
    }
}
