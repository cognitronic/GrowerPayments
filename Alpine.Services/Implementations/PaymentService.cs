using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Payment;
using Alpine.Core.Domain.User;
using Alpine.Core.Domain.Variety;
using Alpine.Core;
using Alpine.Infrastructure.Querying;
using Alpine.Services.Interfaces;
using Alpine.Services.Messaging.PaymentService;
using Alpine.Services.Mapping;
using Alpine.Services.Cache;
using Alpine.Services.ViewModels;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly IPaymentVarietyRepository _paymentvarietyRepository;
        private readonly IVarietyRepository _varietyRepository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public PaymentService(IPaymentRepository repository, 
            ICacheStorage cache, 
            IUnitOfWork uow, 
            IPaymentVarietyRepository paymentvarietyRepository, 
            IVarietyRepository varietyRepository)
        {
            _repository = repository;
            _paymentvarietyRepository = paymentvarietyRepository;
            _varietyRepository = varietyRepository;
            _cache = cache;
            _uow = uow;
        }

        public PaymentService(IPaymentRepository repository,
            ICacheStorage cache,
            IUnitOfWork uow)
        {
            _repository = repository;
            _cache = cache;
            _uow = uow;
        }

        #region IPaymentService Members

        public CreatePaymentResponse CreatePayment(CreatePaymentRequest request)
        {
            var response = new CreatePaymentResponse();
            var payment = new Payment();

            payment = (Payment)request.Payment;
            payment.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            payment.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            payment.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            payment.DateCreated = DateTime.Now;
            //payment.CropYear = SecurityContextManager.Current.CurrentCropYear;
            payment.LastUpdated = DateTime.Now;
            //payment.GrowerID = -1;
            payment.IsTemplate = false;
            payment.PaymentType = PaymentType.Progress_Payment_1;
            payment.SplitHartley = false;
            
            var result = _repository.Add(payment);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = " Created Payment Successfully!";
                response.View = payment.ConvertToPaymentView();
                response.View.Payment = payment;
            }
            else
            {
                response.Success = false;
                response.Message = "Payment Creation Failed!";
            }

            return response;
        }

        public CreatePaymentResponse CreatePaymentTemplate(CreatePaymentRequest request)
        {
            var response = new CreatePaymentResponse();
            var payment = new Payment();

            payment = (Payment)request.Payment;
            payment.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            payment.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            payment.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            payment.DateCreated = DateTime.Now;
            payment.CropYear = SecurityContextManager.Current.CurrentCropYear;
            payment.LastUpdated = DateTime.Now;
            payment.GrowerID = -1;
            payment.IsTemplate = true;
            payment.PaymentType = PaymentType.Progress_Payment_1;
            payment.SplitHartley = false;
            payment.TemplateID = payment.ID;

            var result = _repository.Add(payment);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = " Created Payment Successfully!";
                response.View = payment.ConvertToPaymentView();
                response.View.Payment = payment;
            }
            else
            {
                response.Success = false;
                response.Message = "Payment Creation Failed!";
            }

            return response;
        }

        public CreatePaymentResponse CreateGrowerPayment(CreatePaymentRequest request)
        {
            var response = new CreatePaymentResponse();
            var payment = new Payment();

            payment = (Payment)request.Payment;

            var result = _repository.Add(payment);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = " Created Payment Successfully!";
                response.View = payment.ConvertToPaymentView();
                response.View.Payment = payment;
            }
            else
            {
                response.Success = false;
                response.Message = "Payment Creation Failed!";
            }

            return response;
        }

        public UpdatePaymentResponse UpdatePayment(UpdatePaymentRequest request)
        {
            var response = new UpdatePaymentResponse();
            var payment = _repository.FindByID(request.Payment.ID);
            payment.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            payment.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            payment.LastUpdated = DateTime.Now;
            payment.Name = request.Payment.Name;
            payment.Note = request.Payment.Note;
            payment.Amount = request.Payment.Amount;
            payment.PaymentDate = request.Payment.PaymentDate;
            payment.PaymentType = request.Payment.PaymentType;
            payment.TransactionCompleted = request.Payment.TransactionCompleted;
            payment.TransactionDate = request.Payment.TransactionDate;
            var result = _repository.Save(payment);
            foreach (var v in request.Payment.Varieties)
            {
                v.PaymentID = payment.ID;
                _paymentvarietyRepository.Save((PaymentVariety)v);
            }
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Payment  Updated Successfully!";
                response.View = payment.ConvertToPaymentView();
            }
            else
            {
                response.Success = false;
                response.Message = "Payment  Update Failed!";
            }

            return response;
        }

        public UpdatePaymentResponse UpdatePaymentByReport(UpdatePaymentRequest request)
        {
            var response = new UpdatePaymentResponse();
            var payment = _repository.FindByID(request.Payment.ID);
            payment.LastUpdated = DateTime.Now;
            payment.Name = request.Payment.Name;
            payment.Note = request.Payment.Note;
            payment.Amount = request.Payment.Amount;
            payment.PaymentDate = request.Payment.PaymentDate;
            payment.PaymentType = request.Payment.PaymentType;
            var result = _repository.Save(payment);
            foreach (var v in request.Payment.Varieties)
            {
                v.PaymentID = payment.ID;
                _paymentvarietyRepository.Save((PaymentVariety)v);
            }
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Payment  Updated Successfully!";
                response.View = payment.ConvertToPaymentView();
            }
            else
            {
                response.Success = false;
                response.Message = "Payment  Update Failed!";
            }

            return response;
        }

        public DeletePaymentResponse DeletePayment(DeletePaymentRequest request)
        {
            var response = new DeletePaymentResponse();
            var query = new Query();
            query.Add(new Criterion("PaymentID", request.Payment.ID, CriteriaOperator.Equal));
            var pv = _paymentvarietyRepository.FindBy(query);
            foreach (var v in pv)
            {
                _paymentvarietyRepository.Remove(v);
            }
            _uow.Commit();
            var result = _repository.Remove((Payment)request.Payment);
            _uow.Commit();
            if (result > 0)
            {
                response.Success = true;
                response.Message = " Payment Deleted Successfully!";
                response.View = request.Payment.ConvertToPaymentView();
            }
            else
            {
                response.Success = false;
                response.Message = "Payment  Delete Failed!";
            }

            return response;
        }

        public GetPaymentsResponse GetPaymentsByGrowerIDCropYear(GetPaymentsByGrowerIDCropYearRequest request)
        {
            var response = new GetPaymentsResponse();
            Query query = new Query();

            query.Add(new Criterion("GrowerID", request.GrowerID, CriteriaOperator.Equal));
            query.Add(new Criterion("CropYear", request.CropYear, CriteriaOperator.Equal));
            query.Add(new Criterion("IsTemplate", request.IsTemplate, CriteriaOperator.Equal));

            var payment = _repository.FindBy(query).OrderBy(p => p.PaymentDate);
            if (payment != null)
            {
                response.Success = true;
                response.Message = "Payment  Retrieved Successfully!";
                response.Payments = payment.ToList<IPayment>();//PaymentMapper.ConvertToPaymentViewList((IList<IPayment>)payment);
            }
            else
            {
                response.Success = false;
                response.Message = "Payment  Retrieved Failed!";
            }

            return response;
        }

        public GetPaymentsResponse GetPaymentsByCropYear(GetPaymentsByGrowerIDCropYearRequest request)
        {
            var response = new GetPaymentsResponse();
            Query query = new Query();
            query.Add(new Criterion("CropYear", request.CropYear, CriteriaOperator.Equal));
            query.Add(new Criterion("IsTemplate", false, CriteriaOperator.Equal));

            var payment = _repository.FindBy(query).OrderByDescending(p => p.GrowerID);
            if (payment != null)
            {
                response.Success = true;
                response.Message = "Payment  Retrieved Successfully!";
                response.Payments = payment.ToList<IPayment>();//PaymentMapper.ConvertToPaymentViewList((IList<IPayment>)payment);
            }
            else
            {
                response.Success = false;
                response.Message = "Payment  Retrieved Failed!";
            }

            return response;
        }

        public GetPaymentsResponse GetPaymentsForNewYearByCropYear(GetPaymentsByGrowerIDCropYearRequest request)
        {
            var response = new GetPaymentsResponse();
            Query query = new Query();
            query.Add(new Criterion("CropYear", request.CropYear, CriteriaOperator.Equal));
            query.Add(new Criterion("IsTemplate", false, CriteriaOperator.Equal));
            query.Add(new Criterion("IsMiscPayment", false, CriteriaOperator.Equal));

            var payment = _repository.FindBy(query).OrderByDescending(p => p.GrowerID);
            if (payment != null)
            {
                response.Success = true;
                response.Message = "Payment  Retrieved Successfully!";
                response.Payments = payment.ToList<IPayment>();//PaymentMapper.ConvertToPaymentViewList((IList<IPayment>)payment);
            }
            else
            {
                response.Success = false;
                response.Message = "Payment  Retrieved Failed!";
            }

            return response;
        }

        public GetPaymentsResponse GetAllPayments()
        {
            throw new NotImplementedException();
        }

        public GetPaymentByIDResponse GetPaymentByID(int id)
        {
            var response = new GetPaymentByIDResponse();
            Query query = new Query();
            query.Add(new Criterion("ID", id, CriteriaOperator.Equal));

            var payment = _repository.FindBy(query);
            if (payment != null)
            {
                response.Success = true;
                response.Message = "Payment  Retrieved Successfully!";
                response.View.Payment = payment.First<IPayment>();//PaymentMapper.ConvertToPaymentViewList((IList<IPayment>)payment);
            }
            else
            {
                response.Success = false;
                response.Message = "Payment  Retrieved Failed!";
            }

            return response;
        }

        public GetPaymentsResponse GetPaymentsByTemplateID(GetPaymentsByTemplateIDRequest request)
        {
            var response = new GetPaymentsResponse();
            Query query = new Query();


            query.Add(new Criterion("TemplateID", request.TemplateID, CriteriaOperator.Equal));
            query.Add(new Criterion("IsTemplate", false, CriteriaOperator.Equal));
            query.Add(new Criterion("TransactionCompleted", false, CriteriaOperator.Equal));

            var payment = _repository.FindBy(query).OrderBy(p => p.Name);
            if (payment != null)
            {
                response.Success = true;
                response.Message = "Payment  Retrieved Successfully!";
                response.Payments = payment.ToList<IPayment>();//PaymentMapper.ConvertToPaymentViewList((IList<IPayment>)payment);
            }
            else
            {
                response.Success = false;
                response.Message = "Payment  Retrieved Failed!";
            }

            return response;
        }

        public GetPaymentsResponse GetPaymentTemplatesByCropYear(GetPaymentTemplatesByCropYearRequest request)
        {
            var response = new GetPaymentsResponse();
            Query query = new Query();

            
            query.Add(new Criterion("CropYear", request.CropYear, CriteriaOperator.Equal));
            query.Add(new Criterion("IsTemplate", true, CriteriaOperator.Equal));

            var payment = _repository.FindBy(query).OrderBy(p => p.Name);
            if (payment != null)
            {
                response.Success = true;
                response.Message = "Payment  Retrieved Successfully!";
                response.Payments = payment.ToList<IPayment>();//PaymentMapper.ConvertToPaymentViewList((IList<IPayment>)payment);
            }
            else
            {
                response.Success = false;
                response.Message = "Payment  Retrieved Failed!";
            }

            return response;
        }



        #endregion
    }
}
