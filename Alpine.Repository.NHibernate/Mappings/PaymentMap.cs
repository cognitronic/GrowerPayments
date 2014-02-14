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
    public class PaymentMap : ClassMap<Payment>
    {
        public PaymentMap()
        {
            Id(x => x.ID);
            Map(x => x.ChangedBy);
            Map(x => x.CropYear);
            Map(x => x.DateCreated);
            Map(x => x.Description);
            Map(x => x.EnteredBy);
            Map(x => x.GrowerID);
            Map(x => x.Amount);
            Map(x => x.TransactionDate);
            Map(x => x.SplitHartley);
            Map(x => x.Note);
            Map(x => x.IsTemplate);
            Map(x => x.TemplateID);
            Map(x => x.PaymentType).CustomType(typeof(PaymentType));
            Map(x => x.LastUpdated);
            Map(x => x.AccountID);
            Map(x => x.Name);
            Map(x => x.TransactionCompleted);
            Map(x => x.IsMiscPayment);
            Map(x => x.PaymentDate);
            HasMany<PaymentVariety>(x => x.Varieties)
                .KeyColumn("PaymentID");
        }
    }
}
