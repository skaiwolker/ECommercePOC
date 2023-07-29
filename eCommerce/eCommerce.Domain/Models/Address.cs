using eCommerce.Domain.Models.Base;

namespace eCommerce.Domain.Models
{
    public class Address : BaseModel
    {
        public int Id { get; set; }

        public string PublicPlace { get; set; }

        public int Number { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public virtual User User { get; set; }

        public int UserId {get; set; }


    }
}
