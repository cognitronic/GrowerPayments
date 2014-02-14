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
    public class AssessmentMap : ClassMap<Assessment>
    {
        public AssessmentMap()
        {
            Id(x => x.ID);
            Map(x => x.ChangedBy);
            Map(x => x.CropYear);
            Map(x => x.DateCreated);
            Map(x => x.EnteredBy);
            Map(x => x.LastUpdated);
            Map(x => x.Name);
            Map(x => x.PricePerInShellPound);
            Map(x => x.AccountID);
            Map(x => x.AppliedToAll);
            References<Account>(x => x.Account)
                .Column("AccountID")
                .NotFound
                .Ignore()
                .Not.Update()
                .Not.Insert();
        }
    }
}
