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
using Alpine.Services.ViewModels;
using Alpine.Controllers.ActionArguments;
using Alpine.Controllers.ViewModels.UserAccount;
using Alpine.Infrastructure.Authentication;
using Alpine.Infrastructure.Session;
using Alpine.Core.Domain.User;
using Alpine.Services.Messaging.UserService;
using Alpine.Services.Messaging.GrowerService;
using AutoMapper;
using StructureMap;
using Newtonsoft.Json;

namespace Alpine.Controllers.Controllers.api
{
    public class AssessmentsController : ApiController
    {
        private readonly IAssessmentService _service;
        private readonly IGrowerService _growerService;
        protected readonly ILocalAuthenticationService _authenticationService;
        protected readonly IUserService _userService;
        protected readonly IExternalAuthenticationService _externalAuthenticationService;
        protected readonly IFormsAuthentication _formsAuthentications;
        protected readonly IActionArguments _actionArguments;
        public AssessmentsController(IAssessmentService service,
            ILocalAuthenticationService authenticationService,
            IUserService userService,
            IGrowerService growerService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
        {
            _service = service;
            _growerService = growerService;
        }

        public AssessmentsController() { }

        [HttpGet]
        public string Get()
        { 
            var request = new GetAssessmentsByCropYearRequest();
            request.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            request.CropYear = "2013";
            return JsonHelper.SerializeCollection(_service.GetAssessmentsByCropYear(request));
        }

        [HttpGet]
        [ActionName("RemoveAssessment")]
        public string RemoveAssessment(string assessment)
        {
            var request = new DeleteAssessmentRequest();
            request.AssessmentID = assessment;
            request.Assessment = _service.GetAssessmentByID(new GetAssessmentByIDRequest(Convert.ToInt32(assessment))).Assessment.Assessment;
            var response = _service.DeleteAssessments(request);
            return response.Message;
        }

        [HttpPost]
        [ActionName("PostAssessment")]
        public string PostAssessment(AssessmentView assessment)
        {
            if (ModelState.IsValid && assessment != null)
            {
                if (string.IsNullOrEmpty(assessment.ID ) || assessment.ID.Equals("0"))
                {
                    var request = new CreateAssessmentRequest();
                    IAssessment newItem = ObjectFactory.GetInstance<IAssessment>();

                    newItem.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
                    newItem.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
                    newItem.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
                    newItem.CropYear = assessment.CropYear;
                    newItem.LastUpdated = DateTime.Now;
                    newItem.Name = assessment.Name;
                    newItem.PricePerInShellPound = Convert.ToDecimal(assessment.PricePerInShellPound);
                    newItem.DateCreated = DateTime.Now;

                    request.Assessment = newItem;
                    var response = _service.CreateAssessments(request);
                    return response.Message;
                }
                else
                {
                    var request = new UpdateAssessmentsRequest();
                    var item = _service.GetAssessmentByID(new GetAssessmentByIDRequest(Convert.ToInt32(assessment.ID)));
                    if (item != null)
                    {
                        item.Assessment.Assessment.Name = assessment.Name;
                        item.Assessment.Assessment.PricePerInShellPound = Convert.ToDecimal(assessment.PricePerInShellPound) ;
                        item.Assessment.Assessment.CropYear = assessment.CropYear;
                        item.Assessment.Assessment.AppliedToAll = assessment.AppliedToAll;
                        item.Assessment.Assessment.LastUpdated = DateTime.Now;

                        request.Assessment = item.Assessment.Assessment;
                        var response = _service.UpdateAssessments(request);
                        return response.Message;
                    }
                    return "";
                }
            }
            return "";
        }

        [HttpGet]
        [ActionName("ApplyAssessmentToAll")]
        public string ApplyAssessmentToAll(string assessment)
        {
            var growers = _growerService.GetAllGrowers();
            var assrequest = new GetAssessmentByIDRequest(Convert.ToInt32(assessment));
            var ass = _service.GetAssessmentByID(assrequest).Assessment.Assessment;
            var returnmsg = "";
            foreach (var grower in growers.Growers)
            {
                var ga = new GrowerAssessment();
                ga.AssessmentID = ass.ID;
                ga.ChangedBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
                ga.CropYear = ass.CropYear;
                ga.DateCreated = DateTime.Now;
                ga.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
                ga.GrowerID = grower.ID;
                ga.LastUpdated = DateTime.Now;
                try
                {
                    var garequest = new GrowerAssessmentRequest();
                    garequest.GrowerAssessment = ga;
                    var response = _growerService.CreateGrowerAssessment(garequest);
                    //returnmsg += response.Message;
                }
                catch (Exception exc)
                {
                    returnmsg += exc.Message;
                }
            }
            return returnmsg;
        }

        [HttpGet]
        [ActionName("UpdateAssessmentAppliedToAll")]
        public string UpdateAssessmentAppliedToAll(string assessment)
        {
            var request = new GetAssessmentByIDRequest(Convert.ToInt32(assessment));
            var ass = _service.GetAssessmentByID(request).Assessment.Assessment;
            var updaterequest = new UpdateAssessmentsRequest();
            ass.AppliedToAll = true;
            updaterequest.Assessment = ass;
            var response = _service.UpdateAssessments(updaterequest);
            return response.Message;
        }
    }
}
