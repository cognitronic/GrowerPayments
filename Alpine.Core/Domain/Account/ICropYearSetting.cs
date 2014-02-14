using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Account
{
    public interface ICropYearSetting : ISystemObject, IAuditable
    {
        new int ID { get; set; }
        int AccountID { get; set; }
        string CropYear { get; set; }
        bool PaymentSetupComplete { get; set; }
        
    }
}
