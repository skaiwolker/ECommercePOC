using eCommerce.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual Role Role { get; set; }

        public int RoleId { get; set; }

        public virtual List<Address> Addresses { get; set; }

        public virtual List<CreditCard> CreditCards { get; set; }

        public virtual List<Order> Orders { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
