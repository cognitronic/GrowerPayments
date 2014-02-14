using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Variety;
using Alpine.Core.Domain.Payment;
using FluentNHibernate.Mapping;

namespace Alpine.Repository.NHibernate.Mappings
{
    public class PaymentVarietyMap : ClassMap<PaymentVariety>
    {
        public PaymentVarietyMap()
        {
            Id(x => x.ID);
            Map(x => x.PaymentID);
            Map(x => x.Price);
            Map(x => x.VarietyID);
            Map(x => x.NutwareID);
            References<Variety>(x => x.Variety)
                .Column("VarietyID")
                .NotFound
                .Ignore()
                .Not.Update()
                .Not.Insert();
        }
    }
}
