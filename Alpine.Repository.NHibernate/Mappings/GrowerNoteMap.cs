using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;
using FluentNHibernate.Mapping;

namespace Alpine.Repository.NHibernate.Mappings
{
    public class GrowerNoteMap : ClassMap<GrowerNote>
    {
        public GrowerNoteMap()
        {
            Id(x => x.ID);
            Map(x => x.ChangedBy);
            Map(x => x.DateCreated);
            Map(x => x.EnteredBy);
            Map(x => x.GrowerID);
            Map(x => x.LastUpdated);
            Map(x => x.Note);
            Map(x => x.IsActive);
        }
    }
}
