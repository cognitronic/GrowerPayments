using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Assessment;
using Alpine.Core.Domain.Account;
using FluentNHibernate.Mapping;

namespace Alpine.Repository.NHibernate.Mappings
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Id(x => x.ID);
            Map(x => x.ChangedBy);
            Map(x => x.Address1);
            Map(x => x.Address2);
            Map(x => x.City);
            Map(x => x.DateCreated);
            Map(x => x.DomainName);
            Map(x => x.Email);
            Map(x => x.EnteredBy);
            Map(x => x.Fax);
            Map(x => x.LastUpdated);
            Map(x => x.Name);
            Map(x => x.PathToLogo);
            Map(x => x.Phone);
            Map(x => x.State);
            Map(x => x.WebsiteUrl);
            Map(x => x.Zip);
        }
    }
}
