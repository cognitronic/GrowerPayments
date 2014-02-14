using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Payment;
using Alpine.Infrastructure.Querying;
using Alpine.Services.Interfaces;
using Alpine.Services.Messaging.PaymentService;
using Alpine.Services.Mapping;
using Alpine.Services.Cache;
using Alpine.Services.ViewModels;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Services.Implementations
{
    public class PaymentVarietyService : IPaymentVarietyService
    {
        private readonly IPaymentVarietyRepository _repository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public PaymentVarietyService(IPaymentVarietyRepository repository, ICacheStorage cache, IUnitOfWork uow)
        {
            _repository = repository;
            _cache = cache;
            _uow = uow;
        }

        #region IPaymentVarietyService Members

        public CreatePaymentVarietyResponse CreatePaymentVariety(CreatePaymentVarietyRequest request)
        {
            var response = new CreatePaymentVarietyResponse();
            var paymentvariety = new PaymentVariety();

            paymentvariety = (PaymentVariety)request.PaymentVariety;
            var result = _repository.Add(paymentvariety);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Variety Created Successfully!";
                response.View = paymentvariety.ConvertToPaymentVarietyView();
                response.View.PaymentVariety = paymentvariety;
            }
            else
            {
                response.Success = false;
                response.Message = "Assessment Creation Failed!";
            }

            return response;
        }

        public UpdatePaymentVarietyResponse UpdatePaymentVariety(UpdatePaymentVarietyRequest request)
        {
            var response = new UpdatePaymentVarietyResponse();
            var result = _repository.Save((PaymentVariety)request.PaymentVariety);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Payment Variety Updated Successfully!";
                response.View = request.PaymentVariety.ConvertToPaymentVarietyView();
            }
            else
            {
                response.Success = false;
                response.Message = "Payment Variety Update Failed!";
            }

            return response;
        }

        public DeletePaymentVarietyResponse DeletePaymentVariety(DeletePaymentVarietyRequest request)
        {
            var response = new DeletePaymentVarietyResponse();
            var result = _repository.Remove((PaymentVariety)request.PaymentVariety);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = " PaymentVariety Deleted Successfully!";
                response.View = request.PaymentVariety.ConvertToPaymentVarietyView();
            }
            else
            {
                response.Success = false;
                response.Message = "Payment Variety Delete Failed!";
            }

            return response;
        }

        public GetPaymentVarietiesResponse GetPaymentVarietiesByPaymentID(GetPaymentVarietiesByPaymentIDRequest request)
        {
            var response = new GetPaymentVarietiesResponse();
            Query query = new Query();

            query.Add(new Criterion("PaymentID", request.PaymentID, CriteriaOperator.Equal));

            var paymentvariety = _repository.FindBy(query);
            if (paymentvariety != null)
            {
                response.Success = true;
                response.Message = "Payment Variety Retrieved Successfully!";
                response.PaymentVarieties = PaymentVarietyMapper.ConvertToPaymentVarietyViewList((IList<IPaymentVariety>)paymentvariety);
            }
            else
            {
                response.Success = false;
                response.Message = "Payment Variety Retrieved Failed!";
            }

            return response;
        }

        public GetPaymentVarietiesResponse GetAllPaymentVarieties()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
