using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models
{
    public class CreditCard
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Number { get; set; }

        public string ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        public virtual Client Client { get; set; }

        public int ClientId { get; set; }
    }
}
