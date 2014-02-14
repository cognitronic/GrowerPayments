using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Messaging.PayeeService;
using Alpine.Core.Domain.Grower;

namespace Alpine.Services.Interfaces
{
    public interface IPayeeService
    {
        CreatePayeeResponse CreatePayee(CreatePayeeRequest request);
        UpdatePayeeResponse UpdatePayee(UpdatePayeeRequest request);
        DeletePayeeResponse DeletePayee(DeletePayeeRequest request);
        GetPayeesResponse GetPayeesByGrowerID(GetPayeesRequest request);
        Payee GetPayeeID(int payeeID);
    }
}
