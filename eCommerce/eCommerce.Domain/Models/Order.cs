using eCommerce.Domain.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eCommerce.Domain.Models
{
    public class Order : BaseModel
    {
        public int Id { get; set; }

        public int Status { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
