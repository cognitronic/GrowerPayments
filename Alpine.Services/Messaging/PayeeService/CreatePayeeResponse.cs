using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;
using Alpine.Services.ViewModels;
using System.Runtime.Serialization;

namespace Alpine.Services.Messaging.PayeeService
{
    [Serializable]
    public class CreatePayeeResponse : Response
    {
        public PayeeView Payee { get; set; }
    }
}
