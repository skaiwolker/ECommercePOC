using eCommerce.Domain.Models;

namespace eCommerce.Domain.DTOs
{
    public class AddressDTO
    {

        public int Id { get; set; }

        public string PublicPlace { get; set; }

        public int Number { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }
    }
}
