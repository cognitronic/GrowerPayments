using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Alpine.Controllers.ActionArguments;
using Alpine.Controllers.ViewModels.UserAccount;
using Alpine.Controllers.ViewModels.Assessments;
using Alpine.Controllers.ViewModels.Variety;
using Alpine.Controllers.ViewModels;
using Alpine.Controllers.Controllers.api;
using Alpine.Services.Messaging.AssessmentService;
using Alpine.Services.Messaging.PaymentService;
using Alpine.Services.Messaging.VarietyService;
using Alpine.Infrastructure.Authentication;
using Alpine.Infrastructure.Session;
using Alpine.Services.Interfaces;
using Alpine.Core.Domain.User;
using Alpine.Core.Domain.Payment;
using Alpine.Core.Domain.Assessment;
using Alpine.Core.Domain.Variety;
using Alpine.Core;
using Alpine.Web.Security;
using Alpine.Services.Messaging.UserService;
using Alpine.Services.Messaging.AccountService;
using Alpine.Services.ViewModels;
using AutoMapper;
using StructureMap;

namespace Alpine.Controllers.Controllers
{
    public class MasterScheduleController : BaseController
    {
        protected readonly IAssessmentService _assessmentService;
        private readonly IAccountService _accountService;
        protected readonly IVarietyService _varietyService;
        protected readonly IPaymentService _paymentService;
        public MasterScheduleController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IAccountService accountService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments, 
            IAssessmentService assessmentService,
            IVarietyService varietyService,
            IPaymentService paymentService)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {
            _assessmentService = assessmentService;
            _varietyService = varietyService;
            _paymentService = paymentService;
            _accountService = accountService;
        }


        public ActionResult Index()
        {
            UserAccountView accountView = new UserAccountView();
            accountView.Message = "It's Working!!!";
            accountView.CallBackSettings.ReturnUrl = "nav-masterschedule";
            accountView.SideBar.SelectedMenuItem = "nav-masterschedule";
            accountView.SideBar.SelectedSubMenuItem = "";
            return View(accountView);

        }

        public ActionResult Assessments(string cropyear)
        {
            var request = new GetAssessmentsByCropYearRequest();
            request.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            request.CropYear = cropyear;
            var response = _assessmentService.GetAssessmentsByCropYear(request);
            var assessmentView = new ViewModels.Assessments.AssessmentsView();
            assessmentView.Assessments = response.Assessments;

            var cyr = new CropYearSettingRequest();
            cyr.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            cyr.CropYear = cropyear;
            var setting = _accountService.GetSettingsByAccountCropYear(cyr);
            if (setting.Setting == null || 
                setting.Setting.PaymentSetupComplete == false)
            {
                assessmentView.CanRunSetup = true;
            }
            else
            {
                assessmentView.CanRunSetup = false;
            }

            return PartialView("Assessments", assessmentView);
        }

        public ActionResult Varieties()
        {
            var request = new GetVarietiesByAccountIDRequest(SecurityContextManager.Current.CurrentAccount.ID);
            var response = _varietyService.GetVarietiesByAccountID(request);
            var varietiesView = response.Varieties;
            return PartialView("Varieties", varietiesView);
        }

        public ActionResult Delete(IAssessment assessment)
        {
            var assessmentView = new AssessmentsView();
            var request = new DeleteAssessmentRequest();
            request.AssessmentID = assessment.ID.ToString();
            request.Assessment = assessment;
            var response = _assessmentService.DeleteAssessments(request);
            assessmentView.Assessments.Remove(response.Assessment.Assessment);
            return PartialView("Assessments", assessmentView);
        }

        public ActionResult Update(IAssessment assessment)
        {
            var assessmentView = new AssessmentsView();
            var request = new UpdateAssessmentsRequest();
            request.Assessment = assessment;
            var response = _assessmentService.UpdateAssessments(request);
            assessmentView.Assessments.Add(response.Assessment.Assessment);
            return PartialView("Assessments", assessmentView);
        }

        public ActionResult Create(IAssessment assessment)
        {
            var request = new CreateAssessmentRequest();
            assessment.LastUpdated = DateTime.Now;
            assessment.DateCreated = DateTime.Now;
            assessment.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            assessment.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            assessment.AccountID = SecurityContextManager.Current.CurrentAccount.ID;

            request.Assessment = assessment;
            var response = _assessmentService.CreateAssessments(request);
            if (response.Success)
            {
                var assrequest = new GetAssessmentsByCropYearRequest();
                assrequest.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
                assrequest.CropYear = response.Assessment.CropYear;
                var assresponse = _assessmentService.GetAssessmentsByCropYear(assrequest);
                var assessmentView = assresponse.Assessments;
            }
            return RedirectToAction("Index", "MasterSchedule");
        }

        public ActionResult Payments(string cropyear)
        {
            var request = new GetPaymentsByGrowerIDCropYearRequest(ResourceStrings.GrowerID_For_Payment_Templates, cropyear);
            request.IsTemplate = true;
            var response = _paymentService.GetPaymentsByGrowerIDCropYear(request);
            var paymentView = new ViewModels.PaymentView();
            var paymenttypes = from PaymentType e in Enum.GetValues(typeof(PaymentType))
                              select new { Value = e, Text = e.ToString().Replace("_", " ") };
            paymentView.PaymentTypes = new SelectList(paymenttypes, "Value", "Text");

            var varitiesRequest = new GetVarietiesByAccountIDRequest(SecurityContextManager.Current.CurrentAccount.ID);
            var varitiesResponse = _varietyService.GetVarietiesByAccountID(varitiesRequest);
            paymentView.VarietiesDDL = new SelectList(varitiesResponse.Varieties, "ID", "Name");

            paymentView.Payments = response.Payments;
            return PartialView("Payments", paymentView);
        }
    }
}
