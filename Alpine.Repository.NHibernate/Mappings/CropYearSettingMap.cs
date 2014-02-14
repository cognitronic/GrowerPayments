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
    public class CropYearSettingMap : ClassMap<CropYearSetting>
    {
        public CropYearSettingMap()
        {
            Id(x => x.ID);
            Map(x => x.ChangedBy);
            Map(x => x.AccountID);
            Map(x => x.CropYear);
            Map(x => x.PaymentSetupComplete);
            Map(x => x.EnteredBy);
            Map(x => x.DateCreated);
            Map(x => x.LastUpdated);
        }
    }
}
