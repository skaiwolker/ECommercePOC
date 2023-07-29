using eCommerce.Domain.DTOs.Base;
using eCommerce.Domain.Models;

namespace eCommerce.Domain.DTOs
{
    public class AddressDTO : BaseDTO
    {

        public int Id { get; set; }

        public string PublicPlace { get; set; }

        public int Number { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public UserDTO User { get; set; }

        public int UserId { get; set; }
    }
}
