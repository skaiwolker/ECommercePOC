using eCommerce.Domain.Models;

namespace eCommerce.Domain.DTOs
{
    public class OrderProductDTO
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public Order Order { get; set; }

        public int OrderId { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
