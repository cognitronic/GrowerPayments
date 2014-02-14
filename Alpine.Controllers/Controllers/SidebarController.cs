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
    public class SidebarController : BaseController
    {
        public SidebarController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {

        }

        [ChildActionOnly]
        public ActionResult Navigation(SideBarView sideBar)
        {
            var accountView = new SideBarView();
            switch (((User)SecurityContextManager.Current.CurrentUser).Type)
            {
                case "Admin":
                    accountView.SelectedSideBar = SideBarTypes.AdminSideBar.ToString();
                    accountView.SelectedMenuItem = sideBar.SelectedMenuItem;
                    accountView.SelectedSubMenuItem = sideBar.SelectedSubMenuItem;
                    break;
            }
            return PartialView("_SideBarPartial", accountView);
        }
    }
}
