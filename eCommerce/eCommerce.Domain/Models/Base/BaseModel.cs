using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models.Base
{
    public class BaseModel
    {
        public int Active { get; set; }

        public int Delete { get; set; }

        public DateOnly CreatedOn { get; set; }

        public BaseModel()
        {
            Active = 1;
            Delete = 0;

            CreatedOn =;
        }

    }
}
