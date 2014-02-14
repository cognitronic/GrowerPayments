using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;
using Alpine.Services;
using Alpine.Services.ViewModels;

namespace Alpine.Services.Messaging.PayeeService
{
    public class DeletePayeeResponse : Response
    {
        public PayeeView Payee { get; set; }
    }
}
