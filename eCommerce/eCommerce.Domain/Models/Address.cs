﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string PublicPlace { get; set; }

        public int Number { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public virtual Client Client { get; set; }

        public int ClientId {get; set; }

    }
}
