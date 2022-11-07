using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models
{
    public class Stock
    {
        [Key]
        [Required]
        public int Id { get; set; }

        //public Seller Seller { get; set; }
        //public int SellerId { get; set; }

        public Order Order { get; set; }

        public int OrderId { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

    }
}
