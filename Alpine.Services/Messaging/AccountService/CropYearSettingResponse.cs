using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Account;

namespace Alpine.Services.Messaging.AccountService
{
    public class CropYearSettingResponse : Response
    {
        public IList<ICropYearSetting> Settings { get; set; }
        public CropYearSetting Setting { get; set; }
    }
}
