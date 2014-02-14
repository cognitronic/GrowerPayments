using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Messaging.PaymentService;

namespace Alpine.Services.Interfaces
{
    public interface IPaymentService
    {
        CreatePaymentResponse CreatePayment(CreatePaymentRequest request);
        CreatePaymentResponse CreatePaymentTemplate(CreatePaymentRequest request);
        UpdatePaymentResponse UpdatePayment(UpdatePaymentRequest request);
        UpdatePaymentResponse UpdatePaymentByReport(UpdatePaymentRequest request);
        DeletePaymentResponse DeletePayment(DeletePaymentRequest request);
        GetPaymentsResponse GetPaymentsByGrowerIDCropYear(GetPaymentsByGrowerIDCropYearRequest request);
        GetPaymentsResponse GetPaymentsByCropYear(GetPaymentsByGrowerIDCropYearRequest request);
        GetPaymentsResponse GetPaymentsForNewYearByCropYear(GetPaymentsByGrowerIDCropYearRequest request);
        GetPaymentsResponse GetAllPayments();
        GetPaymentsResponse GetPaymentsByTemplateID(GetPaymentsByTemplateIDRequest request);
        GetPaymentsResponse GetPaymentTemplatesByCropYear(GetPaymentTemplatesByCropYearRequest request);
        GetPaymentByIDResponse GetPaymentByID(int id);
        CreatePaymentResponse CreateGrowerPayment(CreatePaymentRequest request);
    }
}
