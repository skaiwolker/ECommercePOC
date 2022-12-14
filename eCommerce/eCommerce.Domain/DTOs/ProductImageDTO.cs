using eCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs
{
    public class ProductImageDTO
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public virtual ProductDTO Product { get; set; }

        public int ProductId { get; set; }
    }
}
