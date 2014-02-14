using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Services.Messaging.PaymentService
{
    public class GetPaymentsByGrowerIDCropYearRequest
    {
        public int GrowerID { get; set; }
        public string CropYear { get; set; }
        public bool IsTemplate { get; set; }

        public GetPaymentsByGrowerIDCropYearRequest(int growerid, string cropyear)
        {
            GrowerID = growerid;
            CropYear = cropyear;
        }
    }
}
