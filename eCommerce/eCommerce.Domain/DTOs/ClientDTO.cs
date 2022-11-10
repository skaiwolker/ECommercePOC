using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;

namespace eCommerce.Domain.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Address> Addresses { get; set; }

        public List<CreditCard> CreditCards { get; set; }

        public List<Order> Orders { get; set; }
    }
}
