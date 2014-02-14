using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;

namespace Alpine.Services.Messaging.PayeeService
{
    public class GetPayeesRequest
    {
        public int GrowerID { get; set; }

        public GetPayeesRequest(int growerID)
        {
            GrowerID = growerID;
        }
    }
}
