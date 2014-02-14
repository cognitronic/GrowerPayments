using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Messaging.AccountService;

namespace Alpine.Services.Interfaces
{
    public interface IAccountService
    {
        CropYearSettingResponse GetSettingsByAccountCropYear(CropYearSettingRequest request);
        CropYearSettingResponse CreateCropYearSetting(CropYearSettingRequest request);
    }
}
