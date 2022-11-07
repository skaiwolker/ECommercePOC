using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual List<Address> Addresses { get; set; }

        public virtual List<CreditCard> CreditCards { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
