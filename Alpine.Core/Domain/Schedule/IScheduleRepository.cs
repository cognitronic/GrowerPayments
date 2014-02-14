using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Schedule
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Schedule FindByID(int ID);
    }
}
