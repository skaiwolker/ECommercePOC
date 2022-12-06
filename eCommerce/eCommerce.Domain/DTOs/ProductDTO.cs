using eCommerce.Domain.DTOs.Base;
using eCommerce.Domain.Models;
using System.Collections.Generic;

namespace eCommerce.Domain.DTOs
{
    public class ProductDTO : BaseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Department { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
