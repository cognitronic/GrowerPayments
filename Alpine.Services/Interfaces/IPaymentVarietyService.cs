using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Messaging.PaymentService;

namespace Alpine.Services.Interfaces
{
    public interface IPaymentVarietyService
    {
        CreatePaymentVarietyResponse CreatePaymentVariety(CreatePaymentVarietyRequest request);
        UpdatePaymentVarietyResponse UpdatePaymentVariety(UpdatePaymentVarietyRequest request);
        DeletePaymentVarietyResponse DeletePaymentVariety(DeletePaymentVarietyRequest request);
        GetPaymentVarietiesResponse GetPaymentVarietiesByPaymentID(GetPaymentVarietiesByPaymentIDRequest request);
        GetPaymentVarietiesResponse GetAllPaymentVarieties();
    }
}
