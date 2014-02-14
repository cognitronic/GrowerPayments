using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.ViewModels;
using Alpine.Core.Domain.Schedule;
using AutoMapper;

namespace Alpine.Services.Mapping
{
    public static class ScheduleMapper
    {
        public static ScheduleView ConvertToScheduleView(this ISchedule schedule)
        {
            return Mapper.Map<ISchedule, ScheduleView>(schedule);
        }

        public static Schedule ConvertToSchedule(this ScheduleView view)
        {
            return Mapper.Map<ScheduleView, Schedule>(view);
        }

        public static IList<ScheduleView> ConvertToScheduleViewList(this IList<ISchedule> schedules)
        {
            return Mapper.Map<IList<ISchedule>, IList<ScheduleView>>(schedules);
        }
    }
}
