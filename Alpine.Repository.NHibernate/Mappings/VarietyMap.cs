using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Variety;
using FluentNHibernate.Mapping;

namespace Alpine.Repository.NHibernate.Mappings
{
    public class VarietyMap : ClassMap<Variety>
    {
        public VarietyMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.AccountID);
            Map(x => x.NutwareID);
        }
    }
}
