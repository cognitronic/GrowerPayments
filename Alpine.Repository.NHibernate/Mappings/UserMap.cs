using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.User;
using FluentNHibernate.Mapping;
using Alpine.Core.Domain.Account;

namespace Alpine.Repository.NHibernate.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.ID);
            Map(x => x.FirstName);
            Map(x => x.AccountID);
            Map(x => x.ChangedBy);
            Map(x => x.DateCreated);
            Map(x => x.Email);
            Map(x => x.EnteredBy);
            Map(x => x.IsActive);
            Map(x => x.LastLoginDate);
            Map(x => x.LastName);
            Map(x => x.LastUpdated);
            Map(x => x.Password);
            Map(x => x.PasswordAnswer);
            Map(x => x.PasswordQuestion);
            Map(x => x.SystemID);
            Map(x => x.AccessLevel);
            Map(x => x.Avatar);
            Map(x => x.Type);
            References<Account>(x => x.Account).Column("AccountID").NotFound.Ignore();
        }
    }
}
