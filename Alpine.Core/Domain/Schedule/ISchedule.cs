using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;
using Alpine.Core.Domain.Variety;
using Alpine.Core.Domain.Payment;

namespace Alpine.Core.Domain.Schedule
{
    public interface ISchedule : ISystemObject, IAuditable
    {
        string Name { get; set; }
        string Description { get; set; }
        DateTime PaymentDate { get; set; }
        string CropYear { get; set; }
        IList<IPaymentVariety> Varieties { get; set; }
        int AccountID { get; set; }
        string ToJSON();
    }
}
