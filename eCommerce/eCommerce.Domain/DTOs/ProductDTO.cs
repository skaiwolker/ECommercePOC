using eCommerce.Domain.Models;
using System.Collections.Generic;

namespace eCommerce.Domain.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Supplier { get; set; }
        //public virtual Supplier Supplier { get; set; }
        //public int SupplierId { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
