using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Services.Messaging.PaymentService
{
    public class GetPaymentTemplatesByCropYearRequest
    {
        public string CropYear { get; set; }

        public GetPaymentTemplatesByCropYearRequest(string cropyear)
        {
            CropYear = cropyear;
        }
    }
}
