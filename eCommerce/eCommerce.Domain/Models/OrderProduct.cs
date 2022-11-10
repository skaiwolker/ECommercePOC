using System.ComponentModel.DataAnnotations;

namespace eCommerce.Domain.Models
{
    public class OrderProduct
    {
        [Key]
        [Required]
        public int Id { get; set; }

        //public Seller Seller { get; set; }
        //public int SellerId { get; set; }

        public int Amount { get; set; }

        public virtual Order Order { get; set; }

        public int OrderId { get; set; }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }

    }
}
