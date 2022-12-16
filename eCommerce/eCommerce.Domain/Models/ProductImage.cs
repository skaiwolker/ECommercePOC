using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models
{
    public class ProductImage
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public virtual Product Product { get; set; }
        
        public int ProductId { get; set; }
    }
}
