using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Account;
using System.Runtime.Serialization;

namespace Alpine.Services.Messaging.AccountService
{
    public class CropYearSettingRequest
    {
        public int AccountID{ get; set; }
        public string CropYear{ get; set; }
        public bool PaymentSetupComplete { get; set; }
        public ICropYearSetting Setting { get; set; }
    }
}
