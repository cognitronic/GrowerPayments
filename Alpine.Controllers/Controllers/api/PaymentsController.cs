using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;
using Alpine.Core.Domain.Payment;
using Alpine.Core.Domain.Account;
using Alpine.Core;
using Alpine.Web.Security;
using Alpine.Services.Interfaces;
using Alpine.Services.Messaging.PaymentService;
using Alpine.Services.Messaging.AccountService;
using Alpine.Services.Messaging.VarietyService;
using Alpine.Services.ViewModels;
using Alpine.Controllers.ActionArguments;
using Alpine.Controllers.ViewModels.UserAccount;
using Alpine.Infrastructure.Authentication;
using Alpine.Infrastructure.Session;
using Alpine.Core.Domain.User;
using Alpine.Services.Messaging.UserService;
using AutoMapper;
using StructureMap;
using Newtonsoft.Json;

namespace Alpine.Controllers.Controllers.api
{
    public class PaymentsController : ApiController
    {
        private readonly IPaymentService _service;
        private readonly IAccountService _accountService;
        private readonly IGrowerService _growerService;
        private readonly IPaymentVarietyService _varietyService;
        private readonly IVarietyService _vService;
        protected readonly ILocalAuthenticationService _authenticationService;
        protected readonly IUserService _userService;
        protected readonly IExternalAuthenticationService _externalAuthenticationService;
        protected readonly IFormsAuthentication _formsAuthentications;
        protected readonly IActionArguments _actionArguments;
        public PaymentsController(IPaymentService service,
            ILocalAuthenticationService authenticationService,
            IUserService userService,
            IAccountService accountService,
            IGrowerService growerService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IPaymentVarietyService varietyService,
            IVarietyService vService,
            IActionArguments actionArguments)
        {
            _service = service;
            _varietyService = varietyService;
            _accountService = accountService;
            _growerService = growerService;
            _vService = vService;
        }

        public PaymentsController() { }

        [HttpPost]
        [ActionName("CreatePayment")]
        public string CreatePayment(Payment payment)
        {
            var request = new CreatePaymentRequest();
            request.Payment = payment;
            _service.CreatePayment(request);
            return "1:Payment Successfully Created!:/MasterSchedule";
        }

        [HttpPost]
        [ActionName("CreatePaymentTemplate")]
        public string CreatePaymentTemplate(Payment payment)
        {
            var request = new CreatePaymentRequest();
            request.Payment = payment;
            request.Payment.IsTemplate = true;
            request.Payment.TemplateID = request.Payment.ID;
            _service.CreatePaymentTemplate(request);
            return "1:Payment Successfully Created!:/MasterSchedule";
        }

        [HttpPost]
        [ActionName("CreateGrowerPayment")]
        public string CreateGrowerPayment(Payment payment)
        {
            if (payment.ID != -1)
            {
                var template = _service.GetPaymentByID(payment.ID);
                var request = new CreatePaymentRequest();
                var np = new Payment();

                np.AccountID = template.View.Payment.AccountID;
                np.Description = template.View.Payment.Description;
                np.GrowerID = payment.GrowerID;
                np.CropYear = payment.CropYear;
                np.Name = template.View.Payment.Name;
                np.TemplateID = template.View.Payment.ID;
                np.PaymentType = template.View.Payment.PaymentType;
                np.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
                np.DateCreated = DateTime.Now;
                np.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
                np.IsTemplate = false;
                np.LastUpdated = DateTime.Now;
                np.PaymentDate = DateTime.Now;
                request.Payment = np;
                _service.CreateGrowerPayment(request);

                foreach (var pv in template.View.Payment.Varieties)
                {
                    var pvrequest = new CreatePaymentVarietyRequest();
                    var variety = new PaymentVariety();
                    variety.PaymentID = np.ID;
                    variety.Price = pv.Price;
                    variety.VarietyID = pv.VarietyID;
                    variety.NutwareID = pv.Variety.NutwareID;
                    pvrequest.PaymentVariety = variety;
                    _varietyService.CreatePaymentVariety(pvrequest);
                }
            }
            else
            {
                var request = new CreatePaymentRequest();
                var np = new Payment();

                np.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
                np.Description = "Misc Transaction";
                np.GrowerID = payment.GrowerID;
                np.CropYear = payment.CropYear;
                np.Name = "Misc Transaction";
                np.TemplateID = -1;
                np.PaymentType = PaymentType.Progress_Payment_1;
                np.IsMiscPayment = true;
                np.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
                np.DateCreated = DateTime.Now;
                np.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
                np.IsTemplate = false;
                np.LastUpdated = DateTime.Now;
                np.PaymentDate = DateTime.Now;
                request.Payment = np;
                _service.CreateGrowerPayment(request);
            }
            return "1:Payment Successfully Created!:/MasterSchedule";
        }

        [HttpPost]
        [ActionName("UpdatePayment")]
        public string UpdatePayment(PaymentRequest payment)
        {
            var request = new UpdatePaymentRequest();
            request.Payment = payment.Payment;
            request.Payment.Varieties = payment.Varieties.ToList<IPaymentVariety>();
            PaymentView view = new PaymentView();
            _service.UpdatePayment(request);
            return "";
        }

        [HttpPost]
        [ActionName("UpdatePaymentByReport")]
        public string UpdatePaymentByReport(Payment payment)
        {
            var request = new UpdatePaymentRequest();

            request.Payment = _service.GetPaymentByID(payment.ID).View.Payment;
            request.Payment.Amount = payment.Amount;
            _service.UpdatePaymentByReport(request);
            return "";
        }

        [HttpPost]
        [ActionName("DeletePayment")]
        public string DeletePayment(Payment payment)
        {
            var request = new DeletePaymentRequest();
            request.Payment = payment;
            _service.DeletePayment(request);
            return "1:Payment Successfully Deleted!:/MasterSchedule";
        }

        [HttpPost]
        [ActionName("AddVarietyToPaymentTemplate")]
        public string AddVarietyToPaymentTemplate(PaymentVariety variety)
        {
            var request = new CreatePaymentVarietyRequest();
            var vrequest = new GetVarietyByIDRequest(variety.VarietyID);
            request.PaymentVariety = variety;
            request.PaymentVariety.NutwareID = _vService.GetVarietyByID(vrequest).View.Variety.NutwareID;
            _varietyService.CreatePaymentVariety(request);
            return "1:Payment Variety Created Successfully!:/MasterSchedule";
        }

        [HttpPost]
        [ActionName("DeletePaymentVarietyFromTemplate")]
        public string DeletePaymentVarietyFromTemplate(PaymentVariety variety)
        {
            var request = new DeletePaymentVarietyRequest();
            request.PaymentVariety = variety;
            _varietyService.DeletePaymentVariety(request);
            return "1:Payment Variety Deleted Successfully!:/MasterSchedule"; 
        }

        [HttpPost]
        [ActionName("UpdateGrowersPaymentVarieties")]
        public string UpdateGrowersPaymentVarieties(PaymentRequest payment)
        {
            var request = new GetPaymentsByTemplateIDRequest(payment.Payment.ID);
            var payments = _service.GetPaymentsByTemplateID(request);
            foreach (var p in payments.Payments)
            {
                var profile = _growerService.GetGrowerProfileByID(p.GrowerID);
                if (profile.IsStandardSchedule)
                {
                    foreach (var v in p.Varieties)
                    {
                        var delete = new DeletePaymentVarietyRequest();
                        delete.PaymentVariety = v;
                        _varietyService.DeletePaymentVariety(delete);
                        //var np = from price in payment.Varieties
                        //         where price.VarietyID == v.VarietyID
                        //         select price.Price;
                        //v.Price = np.FirstOrDefault<decimal>();
                        //var pv = new UpdatePaymentVarietyRequest();
                        //pv.PaymentVariety = v;
                        //_varietyService.UpdatePaymentVariety(pv);
                    }

                    foreach (var v in payment.Varieties)
                    {
                        var varietyRequest = new CreatePaymentVarietyRequest();
                        var variety = new PaymentVariety();

                        var vrequest = new GetVarietyByIDRequest(v.VarietyID);
                        variety.PaymentID = p.ID;
                        variety.VarietyID = v.VarietyID;
                        variety.Price = v.Price;
                        variety.NutwareID = _vService.GetVarietyByID(vrequest).View.Variety.NutwareID; ;
                        varietyRequest.PaymentVariety = variety;
                        _varietyService.CreatePaymentVariety(varietyRequest);
                    }
                }
            }
            UpdatePayment(payment);
            return "1:Payment Successfully Deleted!:/MasterSchedule";
        }

        [HttpGet]
        [ActionName("RunNewCropYearSetup")]
        public string RunNewCropYearSetup(string cropyear)
        {
            var paymentrequest = new GetPaymentsByGrowerIDCropYearRequest(0, (Convert.ToInt16(cropyear) - 1).ToString());
            var payments = _service.GetPaymentsForNewYearByCropYear(paymentrequest);
            foreach (var payment in payments.Payments)
            {
                var template = _service.GetPaymentByID(payment.TemplateID);
                var newpayment = new Payment();
                newpayment.AccountID = payment.AccountID;
                newpayment.Amount = 0;
                newpayment.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
                newpayment.CropYear = cropyear;
                newpayment.DateCreated = DateTime.Now;
                newpayment.Description = payment.Description;
                newpayment.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
                newpayment.GrowerID = payment.GrowerID;
                newpayment.IsTemplate = false;
                newpayment.LastUpdated = DateTime.Now;
                newpayment.Name = payment.Name;
                newpayment.Note = payment.Note;
                newpayment.PaymentDate = payment.PaymentDate.AddYears(1);
                newpayment.PaymentType = payment.PaymentType;
                newpayment.SplitHartley = payment.SplitHartley;
                newpayment.TemplateID = payment.TemplateID;
                newpayment.TransactionCompleted = false;
                newpayment.Type = payment.Type;
                var cpr = new CreatePaymentRequest();
                cpr.Payment = newpayment;
                _service.CreateGrowerPayment(cpr);

                foreach (var pv in template.View.Payment.Varieties)
                {
                    var pvrequest = new CreatePaymentVarietyRequest();
                    var variety = new PaymentVariety();
                    variety.PaymentID = newpayment.ID;
                    variety.Price = pv.Price;
                    variety.VarietyID = pv.VarietyID;
                    pvrequest.PaymentVariety = variety;
                    _varietyService.CreatePaymentVariety(pvrequest);
                }
            }

            var settingsrequest = new CropYearSettingRequest();
            var cys = new CropYearSetting();
            cys.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            cys.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            cys.CropYear = cropyear;
            cys.DateCreated = DateTime.Now;
            cys.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            cys.LastUpdated = DateTime.Now;
            cys.PaymentSetupComplete = true;
            
            var cysr = new CropYearSettingRequest();
            cysr.Setting = cys;
            _accountService.CreateCropYearSetting(cysr);

            return "1:New Crop Year Setting Run Successfully!:/MasterSchedule";
        }

    }


    public class PaymentRequest
    {
        public Payment Payment { get; set; }
        public IList<PaymentVariety> Varieties { get; set; }
    }
}
