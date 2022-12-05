using eCommerce.Domain.Models;

namespace eCommerce.Domain.DTOs
{
    public class CreditCardDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public string ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}
