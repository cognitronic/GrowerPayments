using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Alpine.Controllers.ActionArguments;
using Alpine.Controllers.ViewModels.UserAccount;
using Alpine.Controllers.ViewModels;
using Alpine.Infrastructure.Authentication;
using Alpine.Infrastructure.Session;
using Alpine.Services.Interfaces;
using Alpine.Core.Domain.User;
using Alpine.Core;
using Alpine.Web.Security;
using Alpine.Services.Messaging.UserService;
using Alpine.Services.ViewModels;
using AutoMapper;

namespace Alpine.Controllers.Controllers
{
    public class ReportsController : BaseController
    {
        public ReportsController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {

        }

        
        public ActionResult Index()
        {
            UserAccountView accountView = new UserAccountView();
            accountView.Message = "It's Working!!!";
            accountView.CallBackSettings.ReturnUrl = "nav-reports";
            return View(accountView);

        }

        public ActionResult GrowerPaymentReport()
        {
            var accountView = new ReportView();
            accountView.UserAccount.Message = "It's Working!!!";
            accountView.UserAccount.CallBackSettings.ReturnUrl = "nav-reports";
            accountView.UserAccount.SideBar.SelectedMenuItem = "nav-reports";
            accountView.UserAccount.SideBar.SelectedSubMenuItem = "subnav-growerpaymentreport";
            return PartialView("GrowerPaymentReport",accountView);

        }

        public ActionResult Header()
        {
            
            return PartialView("_ReportHeader");
        }
    }
}
