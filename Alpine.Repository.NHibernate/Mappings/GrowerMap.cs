using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;
using FluentNHibernate.Mapping;

namespace Alpine.Repository.NHibernate.Mappings
{
    public class GrowerMap : ClassMap<Grower>
    {
        public GrowerMap()
        {
            Table("vwGrower");
            Id(x => x.ID);
            Map(x => x.Address1);
            Map(x => x.City);
            Map(x => x.GrowerSince);
            Map(x => x.Name);
            Map(x => x.State);
            Map(x => x.Zip);
            Map(x => x.IsStandardSchedule);
        }
    }
}
