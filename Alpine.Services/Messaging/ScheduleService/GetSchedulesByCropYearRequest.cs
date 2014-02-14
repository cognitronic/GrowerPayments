using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Alpine.Services.Messaging.ScheduleService
{
    public class GetSchedulesByCropYearRequest
    {
        public int AccountID { get; set; }
        public string CropYear { get; set; }
    }
}
