using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Services.Messaging.ScheduleService
{
    public class GetScheduleByIDRequest
    {
        public int ScheduleID { get; set; }

        public GetScheduleByIDRequest(int id)
        {
            ScheduleID = id;
        }
    }
}
