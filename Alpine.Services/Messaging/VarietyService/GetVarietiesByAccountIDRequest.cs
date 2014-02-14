using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Services.Messaging.VarietyService
{
    public class GetVarietiesByAccountIDRequest
    {
        public int AccountID { get; set; }

         public GetVarietiesByAccountIDRequest(int accountid)
        {
            AccountID = accountid;
        }
    }
}
