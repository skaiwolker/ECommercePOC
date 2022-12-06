using eCommerce.Domain.DTOs.Base;
using eCommerce.Domain.Models;
using System.Collections.Generic;

namespace eCommerce.Domain.DTOs
{
    public class OrderDTO : BaseDTO
    {
        public int Id { get; set; }

        public int Status { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
