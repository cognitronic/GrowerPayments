﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Alpine.Controllers.ActionArguments;
using Alpine.Controllers.ViewModels.UserAccount;
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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        protected readonly ILocalAuthenticationService _authenticationService;
        protected readonly IUserService _userService;
        protected readonly IExternalAuthenticationService _externalAuthenticationService;
        protected readonly IFormsAuthentication _formsAuthentications;
        protected readonly IActionArguments _actionArguments;
        public LoginController(
            ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
        {
            _actionArguments = actionArguments;
            _authenticationService = authenticationService;
            _formsAuthentications = formsAuthentication;
            _externalAuthenticationService = externalAuthenticationService;
            _userService = userService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            UserAccountView accountView = InitializeAccountViewWithIssue(false, "");
            return View(accountView);
        }

        [AllowAnonymous]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Authenticate(UserAccountView account, string returnUrl)
        {
            var user = _userService.AuthenticateUser(account.Email, account.Password);

            if (user.IsAuthenticated)
            {
                SecurityContextManager.Current.CurrentUser = user.SelectedUser;
                SecurityContextManager.Current.IsAuthenticated = true;
                SecurityContextManager.Current.CurrentAccount = user.SelectedUser.Account;
                SecurityContextManager.Current.CurrentAccessLevel = user.SelectedUser.AccessLevel;

                _formsAuthentications.SetAuthenticationToken(user.SelectedUser.ID.ToNullSafeString());
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "GrowerProfile");
            }
            else
            {
                UserAccountView accountView = InitializeAccountViewWithIssue(true, "Invalid credentials. Please try again.");
                accountView.CallBackSettings.ReturnUrl = "";
                return View(accountView);
            }
        }

        [AllowAnonymous]
        public ActionResult ReceiveTokenAndLogon(string token, string returnUrl)
        {
            IUserAccount user = _externalAuthenticationService.GetUserDetailsFrom(token);
            if (user.IsAuthenticated)
            {
                _formsAuthentications.SetAuthenticationToken(user.AuthenticationToken);
                GetUserRequest getUserRequest = new GetUserRequest();
                getUserRequest.UserID = user.UserID;

                GetUserResponse getUserResponse = _userService.GetUser(getUserRequest);

                if (getUserResponse.UserFound)
                {
                    //return RedirectBasedOn(returnUrl);
                    return RedirectToAction("Index", "GrowerProfile");
                }
                else
                {
                    UserAccountView accountView = InitializeAccountViewWithIssue(true, "Sorry we could not find your user account.  If you don't have an account with us please register.");
                    accountView.CallBackSettings.ReturnUrl = returnUrl;
                    return View("Login", accountView);
                }
            }
            else
            {
                UserAccountView accountView = InitializeAccountViewWithIssue(true, "Sorry we could not log you in.  Please try again.");
                accountView.CallBackSettings.ReturnUrl = returnUrl;
                return View("Login", accountView);
            }
        }

        public ActionResult SignOut()
        {
            SecurityContextManager.Current.CurrentUser = null;
            SecurityContextManager.Current.IsAuthenticated = false;
            _formsAuthentications.SignOut();
            return RedirectToAction("Index", "Login");
        }

        [AllowAnonymous]
        private UserAccountView InitializeAccountViewWithIssue(bool hasIssue, string message)
        {
            UserAccountView userAccountView = new UserAccountView();
            userAccountView.CallBackSettings.Action = "Index";
            userAccountView.CallBackSettings.Controller = "Login";
            userAccountView.HasIssue = hasIssue;
            userAccountView.Message = message;

            string returnUrl = _actionArguments
                .GetValueForArgument(ActionArgumentKey.ReturnUrl);
            userAccountView.CallBackSettings.ReturnUrl = returnUrl;// GetReturnActionFrom(returnUrl).ToString();
            return userAccountView;
        }
    }
}
