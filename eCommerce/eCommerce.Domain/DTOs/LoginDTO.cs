using eCommerce.Domain.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs
{
    public class LoginDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
