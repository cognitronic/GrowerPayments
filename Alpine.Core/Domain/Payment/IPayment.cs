using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Schedule;
using Alpine.Core.Domain.Variety;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Payment
{
    public interface IPayment : ISchedule
    {
        int GrowerID { get; set; }
        PaymentType PaymentType { get; set; }
        decimal Amount { get; set; }
        DateTime? TransactionDate { get; set; }
        bool SplitHartley { get; set; }
        string Note { get; set; }
        bool IsTemplate { get; set; }
        new string Name { get; set; }
        new string Description { get; set; }
        new DateTime PaymentDate { get; set; }
        new string CropYear { get; set; }
        new IList<IPaymentVariety> Varieties { get; set; }
        new int AccountID { get; set; }
        int TemplateID { get; set; }
        bool TransactionCompleted { get; set; }
        bool IsMiscPayment { get; set; }
    }
}
