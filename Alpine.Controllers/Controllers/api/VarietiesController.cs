using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;
using Alpine.Core.Domain.Variety;
using Alpine.Core;
using Alpine.Web.Security;
using Alpine.Services.Interfaces;
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
    public class VarietiesController : ApiController
    {
        private readonly IVarietyService _service;
        protected readonly ILocalAuthenticationService _authenticationService;
        protected readonly IUserService _userService;
        protected readonly IExternalAuthenticationService _externalAuthenticationService;
        protected readonly IFormsAuthentication _formsAuthentications;
        protected readonly IActionArguments _actionArguments;
        public VarietiesController(IVarietyService service,
            ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
        {
            _service = service;
        }

        public VarietiesController() { }

        [HttpPost]
        [ActionName("CreateVariety")]
        public string CreateVariety(VarietyView variety)
        {
            if (ModelState.IsValid && variety != null)
            {
                if (variety.ID.Equals(0))
                {
                    var request = new CreateVarietyRequest();
                    IVariety newItem = ObjectFactory.GetInstance<IVariety>();

                    newItem.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
                    newItem.Description = variety.Description;
                    newItem.Name = variety.Name;

                    request.Variety = newItem;
                    var response = _service.CreateVariety(request);
                    return response.Message;
                }
                else
                {
                    var request = new UpdateVarietyRequest();
                    var item = _service.GetVarietyByID(new GetVarietyByIDRequest(Convert.ToInt32(variety.ID)));
                    if (item != null)
                    {
                        item.View.Variety.Name = variety.Name;
                        item.View.Variety.Description = variety.Description;
                        item.View.Variety.ID = variety.ID;
                        request.Variety = item.View.Variety;
                        var response = _service.UpdateVariety(request);
                        return response.Message;
                    }
                    return "";
                }
            }
            return "";
        }

        [HttpGet]
        [ActionName("RemoveVariety")]
        public string RemoveVariety(string variety)
        {
            var request = new DeleteVarietyRequest();
            request.VarietyID = variety;
            request.Variety = _service.GetVarietyByID(new GetVarietyByIDRequest(Convert.ToInt32(variety))).View.Variety;
            var response = _service.DeleteVariety(request);
            return response.Message;
        }

    }
}
