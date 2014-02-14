using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Payment;
using Alpine.Services.ViewModels;

namespace Alpine.Services.Messaging.PaymentService
{
    public class GetPaymentVarietiesResponse : Response
    {
        public IList<PaymentVarietyView> PaymentVarieties { get; set; }
    }
}
