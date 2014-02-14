using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Controllers.ViewModels.UserAccount;
using Alpine.Controllers.ViewModels;
using Alpine.Infrastructure.CookieStorage;
using Alpine.Services.Interfaces;
using Alpine.Services.Messaging.UserService;
using Alpine.Infrastructure.Authentication;
using Alpine.Core.Domain.User;
using Alpine.Controllers.ActionArguments;
using Alpine.Controllers;
using System.Web.Mvc;
using Alpine.Core;

namespace Alpine.Controllers.Controllers
{
    public class TopNavBarController : BaseController
    {
        public TopNavBarController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {

        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var viewModel = new TopNavBarView();
            viewModel.SelectedUser = (IUser)SecurityContextManager.Current.CurrentUser;

            return PartialView("_TopNavBarPartial", viewModel);
        }
    }
}
