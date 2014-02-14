using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Alpine.Services.ViewModels;
using Alpine.Core.Domain.Payment;

namespace Alpine.Services.Messaging.PaymentService
{
    [Serializable]
    public class GetPaymentsResponse : Response
    {
        public IList<IPayment> Payments { get; set; }
    }
}
