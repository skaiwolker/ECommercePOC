using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.DTOs
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

        public double Price { get; set; }

        public virtual List<Stock> Stocks { get; set; }
    }
}
