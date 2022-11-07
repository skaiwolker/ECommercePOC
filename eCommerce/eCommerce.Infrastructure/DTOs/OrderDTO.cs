using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public virtual Client Client { get; set; }

        public int ClientId { get; set; }

        public virtual List<Stock> Stocks { get; set; }
    }
}
