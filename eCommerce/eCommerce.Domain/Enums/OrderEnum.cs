using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Enums
{
    public class OrderEnum
    {
        public enum Status
        {
            Draft = 1,
            Pending = 2,
            AwaitingPayment = 3,
            PaymentConfirmed = 4,
            PaymentRefused = 5,
            Cancelled = 6,
            Preparing = 7,
            Shipped = 8,
            Completed = 9
        }
    }
}
