using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Seller { get; set; }
        //public virtual Seller Seller { get; set; }
        //public int SellerId { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        [JsonIgnore]
        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
