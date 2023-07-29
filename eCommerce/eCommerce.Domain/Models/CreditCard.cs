using eCommerce.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Domain.Models
{
    public class CreditCard : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Number { get; set; }

        public string ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }
    }
}
