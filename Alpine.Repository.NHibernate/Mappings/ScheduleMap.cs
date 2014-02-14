using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Variety;
using Alpine.Core.Domain.Schedule;
using FluentNHibernate.Mapping;

namespace Alpine.Repository.NHibernate.Mappings
{
    public class ScheduleMap : ClassMap<Schedule>
    {
        public ScheduleMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.ChangedBy);
            Map(x => x.CropYear);
            Map(x => x.DateCreated);
            Map(x => x.EnteredBy);
            Map(x => x.LastUpdated);
            Map(x => x.PaymentDate);
            Map(x => x.AccountID);
            HasMany<Variety>(x => x.Varieties);
        }
    }
}
