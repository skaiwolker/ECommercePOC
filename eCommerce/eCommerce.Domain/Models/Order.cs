using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int Status { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }

        public List<Stock> Stocks { get; set; }
    }
}
