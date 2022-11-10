using eCommerce.Domain.Models;
using System.Collections.Generic;

namespace eCommerce.Domain.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int Status { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
