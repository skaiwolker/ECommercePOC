﻿using eCommerce.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models
{
    public class Role : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
