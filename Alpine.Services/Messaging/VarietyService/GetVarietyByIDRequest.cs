using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Services.Messaging.VarietyService
{
    public class GetVarietyByIDRequest
    {
        public int VarietyID { get; set; }

        public GetVarietyByIDRequest(int id)
        {
            VarietyID = id;
        }
    }
}
