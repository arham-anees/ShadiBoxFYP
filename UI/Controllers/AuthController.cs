using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;
using UI.ViewModels;
using UnitOfWork;

namespace UI.Controllers
{
    public class AuthController : Controller
    {
	    #region LOG IN

		[HttpGet]
	    public ActionResult Index(string ReturnUrl)
	    {
		    bool val1 = (System.Web.HttpContext.Current.User != null) &&
		                System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
		    if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
			    if (string.IsNullOrWhiteSpace(ReturnUrl))
				    return RedirectToAction("Dashboard", "Account");
			    else
				    return Redirect(ReturnUrl);


				LoginViewModel viewModel=new LoginViewModel();
				viewModel.ReturnUrl = ReturnUrl;
		    return View(viewModel);
	    }
			[HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
	        if (ModelState.IsValid) {
		        try {
			        cUserRepository userRepository = new cUserRepository(new AppDbContext());
			        var user = userRepository.Authenticate(loginViewModel.Username, loginViewModel.Password);
			        if (user != null) {
				        cHelper.CurrentUser = user;
				        FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
				        if (loginViewModel.ReturnUrl != null)
					        return Redirect(loginViewModel.ReturnUrl);
				        return RedirectToAction("Index", "Home");
			        }
			        else
				        loginViewModel.ErrorMessage = "Invalid Username and password";
		        }
		        catch (Exception e) {
			        loginViewModel.ErrorMessage = e.Message;
		        }
	        }
	        return View(loginViewModel);
		}
        #endregion

		public ActionResult LogOut()
        {
	        FormsAuthentication.SignOut();
	        HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
	        return RedirectToAction("Index", "Home");
        }


        #region SIGN UP

        [HttpGet]
        public ActionResult SignUp() {
	        return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpViewModel signUpViewModel) {
	        if (ModelState.IsValid) {
		        if (signUpViewModel.Password == signUpViewModel.ConfirmPassword) {
			        try {
				        cUser user = new cUser();
				        user.Name = signUpViewModel.Name;
				        user.Email = signUpViewModel.Email;
				        user.Phone = signUpViewModel.Phone;
				        user.Password = signUpViewModel.Password;
				        user.Username = signUpViewModel.Username;
				        using (var unit = new cUnitOfWork(new AppDbContext())) {
					        unit.UserRepository.Add(user);
					        unit.SaveChanges();
				        }
				        LoginViewModel loginViewModel = new LoginViewModel();
				        loginViewModel.Username = signUpViewModel.Username;
				        loginViewModel.Password = signUpViewModel.Password;
				        return Index(loginViewModel);
			        }
			        catch (Exception e) {
				        signUpViewModel.ErrorMessage = e.Message;
			        }
		        }
	        }
	        return View(signUpViewModel);
        }
		#endregion


		#region FORGOT PASSWORD

		[HttpGet]
		public ActionResult ForgotPassword() {
			return View();
		}

		[HttpPost]
		public ActionResult ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel) {
			if (ModelState.IsValid) {

			}
			return View();
		}

		#endregion

		public ActionResult ResetPassword() {
			return View();
		}

	}
}