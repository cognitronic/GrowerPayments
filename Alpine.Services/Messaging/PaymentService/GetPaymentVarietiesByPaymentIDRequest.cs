using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Services.Messaging.PaymentService
{
    public class GetPaymentVarietiesByPaymentIDRequest
    {
        public int PaymentID { get; set; }

        public GetPaymentVarietiesByPaymentIDRequest(int paymentid)
        {
            PaymentID = paymentid;
        }
    }
}
