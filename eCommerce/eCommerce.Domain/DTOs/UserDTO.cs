using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Role Role { get; set; }

        public int RoleId { get; set; }

        public int Active { get; set; }

        public List<Address> Addresses { get; set; }

        public List<CreditCard> CreditCards { get; set; }

        public List<Order> Orders { get; set; }

        public List<Product> Products { get; set; }

    }
}
