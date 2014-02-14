using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;
using FluentNHibernate.Mapping;

namespace Alpine.Repository.NHibernate.Mappings
{
    public class PayeeMap : ClassMap<Payee>
    {
        public PayeeMap()
        {
            Id(x => x.ID);
            Map(x => x.Address);
            Map(x => x.City);
            Map(x => x.CellPhone);
            Map(x => x.ChangedBy);
            Map(x => x.CheckMadeTo);
            Map(x => x.DateCreated);
            Map(x => x.Email);
            Map(x => x.EnteredBy);
            Map(x => x.Fax);
            Map(x => x.FirstName);
            Map(x => x.GrowerID);
            Map(x => x.LastName);
            Map(x => x.LastUpdated);
            Map(x => x.SplitPercent);
            Map(x => x.WorkPhone);
            Map(x => x.State);
            Map(x => x.Zip);
        }
    }
}
