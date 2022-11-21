using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace eCommerce.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Department { get; set; }

        public string Seller { get; set; }
        //public virtual Seller Seller { get; set; }
        //public int SellerId { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
