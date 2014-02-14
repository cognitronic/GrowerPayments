using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Payment;

namespace Alpine.Services.Messaging.PaymentService
{
    public class UpdatePaymentVarietyRequest
    {
        public IPaymentVariety PaymentVariety { get; set; }
    }
}
