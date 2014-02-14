using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.ViewModels;

namespace Alpine.Services.Messaging.PaymentService
{
    public class UpdatePaymentVarietyResponse : Response
    {
        public PaymentVarietyView View { get; set; }
    }
}
