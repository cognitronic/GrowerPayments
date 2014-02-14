using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Services.Messaging.PaymentService
{
    public class GetPaymentsByTemplateIDRequest
    {
        public int TemplateID { get; set; }

        public GetPaymentsByTemplateIDRequest(int templateid)
        {
            TemplateID = templateid;
        }
    }
}
