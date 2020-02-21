using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.ViewModels;

namespace UI.Controllers {
	public class AccountController : Controller {
		#region SIGN IN



		// GET: Account
		[HttpGet]
		public ActionResult Login() {
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginViewModel loginViewModel) {
			if (ModelState.IsValid) {

			}
			return View();
		}
		#endregion

		#region SIGN UP



		[HttpGet]
		public ActionResult SignUp() {
			return View();
		}
		[HttpPost]
		public ActionResult SignUp(SignUpViewModel signUpViewModel) {
			if (ModelState.IsValid) {

			}
			return View();
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