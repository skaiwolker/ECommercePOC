using System.ComponentModel.DataAnnotations;

namespace eCommerce.Domain.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Number { get; set; }

        public string ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        public virtual Client Client { get; set; }

        public int ClientId { get; set; }
    }
}
