using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eCommerce.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int Status { get; set; }

        public virtual Client Client { get; set; }

        public int ClientId { get; set; }

        [JsonIgnore]
        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
