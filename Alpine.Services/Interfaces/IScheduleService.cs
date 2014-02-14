using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Messaging.ScheduleService;

namespace Alpine.Services.Interfaces
{
    public interface IScheduleService
    {
        CreateScheduleResponse CreateSchedule(CreateScheduleRequest request);
        UpdateScheduleResponse UpdateSchedule(UpdateScheduleRequest request);
        DeleteScheduleResponse DeleteSchedule(DeleteScheduleRequest request);
        GetScheduleByIDResponse GetScheduleByID(GetScheduleByIDRequest request);
        GetSchedulesResponse GetSchedulesByCropYear(GetSchedulesByCropYearRequest request);
        GetSchedulesResponse GetAllSchedules();
    }
}
