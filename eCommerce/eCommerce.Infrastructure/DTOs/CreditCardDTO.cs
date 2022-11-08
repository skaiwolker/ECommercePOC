using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.DTOs
{
    public class CreditCardDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public string ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }
    }
}
