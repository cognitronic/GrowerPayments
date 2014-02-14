using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Alpine.Controllers.ActionArguments;
using Alpine.Controllers.ViewModels.UserAccount;
using Alpine.Controllers.ViewModels.Growers;
using Alpine.Infrastructure.Authentication;
using Alpine.Infrastructure.Session;
using Alpine.Services.Interfaces;
using Alpine.Core.Domain.User;
using Alpine.Core;
using Alpine.Core.Domain.Grower;
using Alpine.Core.Domain.Assessment;
using Alpine.Core.Domain.Payment;
using Alpine.Web.Security;
using Alpine.Services.Messaging.UserService;
using Alpine.Services.Messaging.AssessmentService;
using Alpine.Services.Messaging.GrowerService;
using Alpine.Services.Messaging.PaymentService;
using Alpine.Services.Messaging.PayeeService;
using Alpine.Services.ViewModels;
using AutoMapper;

namespace Alpine.Controllers.Controllers
{
    public class GrowerProfileController: BaseController
    {
        private readonly IGrowerService _growerService;
        private readonly IAssessmentService _assessmentService;
        private readonly IPaymentService _paymentService;
        private readonly IPayeeService _payeeService;
        public GrowerProfileController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IGrowerService growerService,
            IPaymentService paymentService,
            IAssessmentService assessmentService,
            IPayeeService payeeService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {
            _payeeService = payeeService;
            _growerService = growerService;
            _assessmentService = assessmentService;
            _paymentService = paymentService;
        }

        
        public ActionResult Index()
        {
            UserAccountView view = new UserAccountView();
            view.SideBar.SelectedMenuItem = "nav-growerprofile";
            view.SideBar.SelectedSubMenuItem = "";
            var growers = from Grower g in _growerService.GetAllGrowers().Growers.OrderBy(o => o.Name)
                              select new {Value = g.ID, Text = g.Name};

            view.Growers = new SelectList(growers, "Value", "Text");

            
            return View(view);

        }

        public ActionResult Assessments(string cropyear, string growerid)
        {
            GrowersView view = new GrowersView();
            view.SideBar.SelectedMenuItem = "nav-growerprofile";
            view.SideBar.SelectedSubMenuItem = "";
            var assessmentRequest = new GetAssessmentsByCropYearRequest();
            assessmentRequest.CropYear = cropyear;
            assessmentRequest.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            view.Assessments = _assessmentService.GetAssessmentsByCropYear(assessmentRequest).Assessments;

            var ga = new GrowerAssessmentRequest();
            ga.CropYear = cropyear;
            ga.GrowerID = Convert.ToInt32(growerid);
            view.GrowerAssessments = _growerService.GetGrowerAssessments(ga).View.GrowerAssessments.ToList<IGrowerAssessment>();
            view.AssessmentsDDL = new SelectList(view.Assessments, "ID", "Name");

            

            return PartialView("Assessments", view);
        }

        public ActionResult Notes(string cropyear, string growerid, string status)
        {
            GrowersView view = new GrowersView();
            view.SideBar.SelectedMenuItem = "nav-growerprofile";
            view.SideBar.SelectedSubMenuItem = "";

            var gn = new GrowerNoteRequest();
            gn.GrowerNote = new GrowerNote();
            gn.GrowerID = Convert.ToInt32(growerid);
            gn.GrowerNote.GrowerID = Convert.ToInt32(growerid);
            if (string.IsNullOrEmpty(status))
                status = "True";
            gn.IsActive = Convert.ToBoolean(status);
            gn.GrowerNote.IsActive = Convert.ToBoolean(status);
            view.GrowerNotes = _growerService.GetGrowerNotes(gn).View.GrowerNotes.ToList<IGrowerNote>();
            var profile = _growerService.GetGrowerProfileByID(gn.GrowerID);
            if (profile == null)
            {
                var p = new GrowerProfile();
                p.GrowerID = Convert.ToInt16(growerid);
                p.IsStandardSchedule = true;
                _growerService.UpdateGrowerProfile(p);
                profile = p;
            }
            view.IsStandardSchedule = profile.IsStandardSchedule;
            view.GrowerProfileID = profile.ID;
            return PartialView("Notes", view);
        }

        public ActionResult Settings(string cropyear, string growerid)
        {
            GrowersView view = new GrowersView();
            view.SideBar.SelectedMenuItem = "nav-growerprofile";
            view.SideBar.SelectedSubMenuItem = "";

            var profile = _growerService.GetGrowerProfileByID(Convert.ToInt32(growerid));
            
            view.IsStandardSchedule = profile.IsStandardSchedule;
            view.GrowerProfileID = profile.ID;
            return PartialView("Settings", view);
        }

        public ActionResult Payments(string cropyear, string growerid)
        {
            GrowersView view = new GrowersView();
            view.SideBar.SelectedMenuItem = "nav-growerprofile";
            view.SideBar.SelectedSubMenuItem = "";

            var request = new GetPaymentsByGrowerIDCropYearRequest(Convert.ToInt32(growerid), cropyear);
            request.IsTemplate = false;
            
            if(!string.IsNullOrEmpty(growerid))
                view.GrowerProfileID = Convert.ToInt16(growerid);

            var paymenttypes = from PaymentType e in Enum.GetValues(typeof(PaymentType))
                               select new { Value = e, Text = e.ToString().Replace("_", " ") };
            view.PaymentTypes = new SelectList(paymenttypes, "Value", "Text");

            view.GrowerPayments = _paymentService.GetPaymentsByGrowerIDCropYear(request).Payments;


            var paymentRequest = new GetPaymentTemplatesByCropYearRequest(cropyear);
            if (SecurityContextManager.Current.CurrentAccessLevel >= 60)
            {
                var payments = from Payment p in _paymentService.GetPaymentTemplatesByCropYear(paymentRequest).Payments
                               select new { Value = p.ID, Text = p.Name };

                var pt = new SelectList(payments, "Value", "Text").ToList<SelectListItem>();

                view.GrowerPaymentsDDL = new SelectList(payments, "Value", "Text").ToList<SelectListItem>();
                pt.Insert(0, new SelectListItem()
                {
                    Text = PaymentType.Misc_Transaction.ToString().Replace("_", " "),
                    Value = "-1"
                });

                view.GrowerPaymentsDDL = pt;
            }
            else
            {
                var payments = from Payment p in _paymentService.GetPaymentTemplatesByCropYear(paymentRequest).Payments
                               select new { Value = p.ID, Text = p.Name };

                var pt = new SelectList(payments, "Value", "Text").ToList<SelectListItem>();
                pt.Insert(0, new SelectListItem()
                {
                    Text = PaymentType.Misc_Transaction.ToString().Replace("_", " "),
                    Value = "-1"
                });

                view.GrowerPaymentsDDL = pt;
            }


            return PartialView("Payments", view);
        }

        public ActionResult Payees(string cropyear, string growerid)
        {
            GrowersView view = new GrowersView();
            view.SideBar.SelectedMenuItem = "nav-growerprofile";
            view.SideBar.SelectedSubMenuItem = "";

            var request = new GetPayeesRequest(Convert.ToInt32(growerid));

            view.Payees = _payeeService.GetPayeesByGrowerID(request).Payees;

            return PartialView("Payees", view);
        }
    }
}
