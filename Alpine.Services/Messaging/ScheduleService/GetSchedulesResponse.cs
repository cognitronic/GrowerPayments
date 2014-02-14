using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Schedule;
using Alpine.Services.ViewModels;
using System.Runtime.Serialization;


namespace Alpine.Services.Messaging.ScheduleService
{
    public class GetSchedulesResponse : Response
    {
        public IList<ScheduleView> Schedules{ get; set; }
    }
}
