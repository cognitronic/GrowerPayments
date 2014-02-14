using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Controllers.ViewModels.UserAccount;
using Alpine.Infrastructure.CookieStorage;
using Alpine.Services.Interfaces;
using Alpine.Services.Messaging.UserService;
using Alpine.Infrastructure.Authentication;
using Alpine.Core.Domain.User;
using Alpine.Controllers.ActionArguments;
using Alpine.Controllers;
using System.Web.Mvc;
using EO.Pdf;

namespace Alpine.Controllers.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILocalAuthenticationService authenticationService,
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
            accountView.CallBackSettings.ReturnUrl = "nav-dashboard";
            accountView.SideBar.SelectedMenuItem = "nav-dashboard";
            accountView.SideBar.SelectedSubMenuItem = "";
            return View(accountView);

        }

        [AllowAnonymous]
        public ActionResult PrintPdf()
        {
            using (HtmlToPdfSession session = HtmlToPdfSession.Create())
            {
                session.LoadUrl("http://alpine.localhost/Login");
                session.Fill("Email", "danny@ravenartmedia.com");
                //session.Fill("Email_ClientState", "{\"enabled\":true,\"emptyMessage\":\"\",\"validationText\":\"danny@ravenartmedia.com\",\"valueAsString\":\"danny@ravenartmedia.com\"}");
                session.Fill("Password", "password");
                //session.Fill("Password_ClientState", "{\"enabled\":true,\"emptyMessage\":\"\",\"validationText\":\"password\",\"valueAsString\":\"password\"}");

                session.Submit("lbLogin");
                session.LoadUrl("http://alpine.localhost/Reports");
                try
                {
                    session.RenderAsPDF("c:\\GrowerPaymentReport.pdf");
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }
            UserAccountView accountView = new UserAccountView();
            return View(accountView);
        }
    }
}
