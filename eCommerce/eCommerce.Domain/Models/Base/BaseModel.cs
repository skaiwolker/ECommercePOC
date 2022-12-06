using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models.Base
{
    public class BaseModel
    {
        public int Delete { get; set; }

        public DateTime CreatedOn { get; set; }

        public BaseModel()
        {
            Delete = 0;

            CreatedOn = DateTime.Today;
        }

    }
}
