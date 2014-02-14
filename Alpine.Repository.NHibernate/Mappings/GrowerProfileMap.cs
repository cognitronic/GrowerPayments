using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;
using FluentNHibernate.Mapping;

namespace Alpine.Repository.NHibernate.Mappings
{
    public class GrowerProfileMap : ClassMap<GrowerProfile>
    {
        public GrowerProfileMap()
        {
            Id(x => x.ID);
            Map(x => x.GrowerID);
            Map(x => x.IsStandardSchedule);
            References<Grower>(x => x.Grower)
                .Column("GrowerID")
                .NotFound
                .Ignore()
                .Not.Update()
                .Not.Insert();
        }
    }
}
