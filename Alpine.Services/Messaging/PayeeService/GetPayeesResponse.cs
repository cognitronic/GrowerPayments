using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;

namespace Alpine.Services.Messaging.PayeeService
{
    public class GetPayeesResponse : Response
    {
        public IList<IPayee> Payees { get; set; }
    }
}
