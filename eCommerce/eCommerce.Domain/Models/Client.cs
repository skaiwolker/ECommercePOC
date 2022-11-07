using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Address> Addresses { get; set; }

        public List<CreditCard> CreditCards { get; set; }

        public List<Order> Orders { get; set; }

    }
}
