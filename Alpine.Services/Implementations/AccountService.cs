using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Interfaces;
using Alpine.Core.Domain.Account;
using Alpine.Core.Domain.Payment;
using Alpine.Services.Messaging.AccountService;
using Alpine.Services.Messaging.PaymentService;
using Alpine.Services.Cache;
using Alpine.Infrastructure.UnitOfWork;
using Alpine.Infrastructure.Querying;

namespace Alpine.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly ICropYearSettingRepository _repository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public AccountService(ICropYearSettingRepository repository, 
            ICacheStorage cache, 
            IPaymentRepository paymentRepository,
            IUnitOfWork uow)
        {
            _repository = repository;
            _paymentRepository = paymentRepository;
            _cache = cache;
            _uow = uow;
        }

        public CropYearSettingResponse GetSettingsByAccountCropYear(CropYearSettingRequest request)
        {
            var response = new CropYearSettingResponse();
            var query = new Query();
            query.Add(new Criterion("AccountID", request.AccountID, CriteriaOperator.Equal));
            query.Add(new Criterion("CropYear", request.CropYear, CriteriaOperator.Equal));
            response.Setting = (CropYearSetting)_repository.FindBy(query).FirstOrDefault<CropYearSetting>();
            return response;
        }

        public CropYearSettingResponse CreateCropYearSetting(CropYearSettingRequest request)
        {
            var response = new CropYearSettingResponse();
            var setting = new CropYearSetting();

            setting = (CropYearSetting)request.Setting;

            var result = _repository.Add(setting);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = " Created New Crop Year Setting Successfully!";
                response.Setting = setting;
            }
            else
            {
                response.Success = false;
                response.Message = "New Crop Year Setting Creation Failed!";
            }

            return response;
        }
    }
}
