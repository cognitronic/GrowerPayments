using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;
using Alpine.Core.Domain.Assessment;
using Alpine.Core.Domain.Grower;
using Alpine.Core;
using Alpine.Web.Security;
using Alpine.Services.Interfaces;
using Alpine.Services.Messaging.AssessmentService;
using Alpine.Services.Messaging.GrowerService;
using Alpine.Services.Messaging.PayeeService;
using Alpine.Services.ViewModels;

using Alpine.Controllers.ActionArguments;
using Alpine.Controllers.ViewModels.UserAccount;
using Alpine.Controllers.ViewModels.Growers;
using Alpine.Infrastructure.Authentication;
using Alpine.Infrastructure.Session;
using Alpine.Core.Domain.User;
using Alpine.Services.Messaging.UserService;
using AutoMapper;
using StructureMap;
using Newtonsoft.Json;

namespace Alpine.Controllers.Controllers.api
{
    public class GrowerProfileController : ApiController
    {
        private readonly IAssessmentService _assessmentService;
        private readonly IPayeeService _payeeService;
        private readonly IGrowerService _growerService;
        protected readonly ILocalAuthenticationService _authenticationService;
        protected readonly IUserService _userService;
        protected readonly IExternalAuthenticationService _externalAuthenticationService;
        protected readonly IFormsAuthentication _formsAuthentications;
        protected readonly IActionArguments _actionArguments;
        public GrowerProfileController(IPayeeService payeeService, IAssessmentService assessmentService,
            ILocalAuthenticationService authenticationService,
            IGrowerService growerService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
        {
            _payeeService = payeeService;
            _assessmentService = assessmentService;
            _growerService = growerService;
        }

        public GrowerProfileController() { }

        [HttpPost]
        [ActionName("CreateGrowerAssessment")]
        public string CreateGrowerAssessment(GrowerAssessment assessment)
        {
            var request = new GrowerAssessmentRequest();
            assessment.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            assessment.DateCreated = DateTime.Now;
            assessment.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            assessment.LastUpdated = DateTime.Now;
            request.GrowerAssessment = assessment;
            _growerService.CreateGrowerAssessment(request);
            SecurityContextManager.Current.CurrentGrowerID = assessment.GrowerID.ToString();
            return "1:Grower Assessment Created Successfully!:/GrowerProfile";
        }

        [HttpPost]
        [ActionName("DeleteGrowerAssessment")]
        public string DeleteGrowerAssessment(GrowerAssessment assessment)
        {
            var request = new GrowerAssessmentRequest();
            request.GrowerAssessment = assessment;
            _growerService.DeleteGrowerAssessment(request);
            SecurityContextManager.Current.CurrentGrowerID = assessment.GrowerID.ToString();
            return "1:Grower Assessment Created Successfully!:/GrowerProfile";
        }

        [HttpPost]
        [ActionName("DeleteGrowerNote")]
        public string DeleteGrowerNote(GrowerNote note)
        {
            var request = new GrowerNoteRequest();
            request.GrowerNote = note;
            _growerService.DeleteGrowerNote(request);
            SecurityContextManager.Current.CurrentGrowerID = note.GrowerID.ToString();
            return "1:Grower Note Deleted Successfully!:/GrowerProfile";
        }

        [HttpPost]
        [ActionName("InactivateGrowerNote")]
        public string InactivateGrowerNote(GrowerNote note)
        {
            var request = new GrowerNoteRequest();
            note.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            note.LastUpdated = DateTime.Now;
            request.GrowerNote = note;
            _growerService.InactivateGrowerNote(request);
            SecurityContextManager.Current.CurrentGrowerID = note.GrowerID.ToString();
            return "1:Grower Note Created Successfully!:/GrowerProfile";
        }

        [HttpPost]
        [ActionName("CreateGrowerNote")]
        public string CreateGrowerNote(GrowerNote note)
        {
            var request = new GrowerNoteRequest();
            note.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            note.DateCreated = DateTime.Now;
            note.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            note.LastUpdated = DateTime.Now;
            request.GrowerNote = note;
            _growerService.CreateGrowerNote(request);
            SecurityContextManager.Current.CurrentGrowerID = note.GrowerID.ToString();
            return "1:Grower Note Created Successfully!:/GrowerProfile";
        }

        [HttpPost]
        [ActionName("CreatePayee")]
        public string CreatePayee(Payee payee)
        {
            var request = new CreatePayeeRequest();
            payee.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            payee.DateCreated = DateTime.Now;
            payee.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            payee.LastUpdated = DateTime.Now;
            request.Payee = payee;
            _payeeService.CreatePayee(request);
            SecurityContextManager.Current.CurrentGrowerID = payee.GrowerID.ToString();
            return "1:Payee Created Successfully!:/GrowerProfile";
        }

        [HttpPost]
        [ActionName("DeletePayee")]
        public string DeletePayee(Payee payee)
        {
            var request = new DeletePayeeRequest();
            var p = _payeeService.GetPayeeID(payee.ID);
            request.Payee = p;
            _payeeService.DeletePayee(request);
            SecurityContextManager.Current.CurrentGrowerID = payee.GrowerID.ToString();
            return "1:Payee Created Successfully!:/GrowerProfile";
        }

        [HttpPost]
        [ActionName("UpdatePayee")]
        public string UpdatePayee(Payee payee)
        {
            var request = new CreatePayeeRequest();
            var p = _payeeService.GetPayeeID(payee.ID);
            p.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            p.LastUpdated = DateTime.Now;
            p.SplitPercent = payee.SplitPercent;
            request.Payee = p;
            _payeeService.CreatePayee(request);
            SecurityContextManager.Current.CurrentGrowerID = payee.GrowerID.ToString();
            return "1:Payee Created Successfully!:/GrowerProfile";
        }

        [HttpPost]
        [ActionName("GetGrowerNotesByStatus")]
        public string GetGrowerNotesByStatus(GrowerNote note)
        {
            var request = new GrowerNoteRequest();
            request.GrowerNote = note;
            _growerService.GetGrowerNotes(request);
            SecurityContextManager.Current.CurrentGrowerID = note.GrowerID.ToString();
            return "1:Grower Note Created Successfully!:/GrowerProfile";
        }

        [HttpPost]
        [ActionName("SaveGrowerProfile")]
        public string SaveGrowerProfile(GrowerProfile profile)
        {
            _growerService.UpdateGrowerProfile(profile);
            return "1:Grower Profile Updated Successfully!:/GrowerProfile";
        }
    }
}
