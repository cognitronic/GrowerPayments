using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Variety;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Payment
{
    public interface IPaymentVariety : ISystemObject
    {
        int VarietyID { get; set; }
        IVariety Variety { get; set; }
        decimal Price { get; set; }
        int PaymentID { get; set; }
        int NutwareID { get; set; }
        string ToJSON();
    }
}
