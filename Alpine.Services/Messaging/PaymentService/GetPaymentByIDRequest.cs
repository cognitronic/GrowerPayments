using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Services.Messaging.PaymentService
{
    public class GetPaymentByIDRequest
    {
        public int PaymentID { get; set; }

        public GetPaymentByIDRequest(int id)
        {
            PaymentID = id;
        }
    }
}
