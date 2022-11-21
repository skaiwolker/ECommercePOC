using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eCommerce.Domain.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [JsonIgnore]
        public virtual List<Address> Addresses { get; set; }

        [JsonIgnore]
        public virtual List<CreditCard> CreditCards { get; set; }

        [JsonIgnore]
        public virtual List<Order> Orders { get; set; }

    }
}
