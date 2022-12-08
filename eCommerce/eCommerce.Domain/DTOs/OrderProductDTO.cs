using eCommerce.Domain.DTOs.Base;
using eCommerce.Domain.Models;

namespace eCommerce.Domain.DTOs
{
    public class OrderProductDTO : BaseDTO
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public OrderDTO Order { get; set; }

        public int OrderId { get; set; }

        public ProductDTO Product { get; set; }

        public int ProductId { get; set; }
    }
}
