using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;
using UI.ViewModels;
using UnitOfWork;

namespace UI.Controllers {
	public class AccountController : Controller {
		#region SIGN IN
		
		[HttpGet]
		public ActionResult Login()
		{
			if (cHelper.CurrentUser != null)
				return RedirectToAction("Index", "Home");
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginViewModel loginViewModel) {
			if (ModelState.IsValid) {
				try
				{
					cUserRepository userRepository = new cUserRepository(new AppDbContext());
					var user = userRepository.Authenticate(loginViewModel.Username, loginViewModel.Password);
					if (user != null)
					{
						cHelper.CurrentUser = user;
						return RedirectToAction("Index", "Home");
					}
					else
						loginViewModel.ErrorMessage = "Invalid Username and password";
				}
				catch (Exception e)
				{
					loginViewModel.ErrorMessage = e.Message;
				}
			}
			return View(loginViewModel);
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
				if (signUpViewModel.Password == signUpViewModel.ConfirmPassword)
				{
					try
					{
						cUser user = new cUser();
						user.Name = signUpViewModel.Name;
						user.Email = signUpViewModel.Email;
						user.Phone = signUpViewModel.Phone;
						user.Password = signUpViewModel.Password;
						user.Username = signUpViewModel.Username;
						using (var unit = new cUnitOfWork(new AppDbContext()))
						{
							unit.UserRepository.Add(user);
							unit.SaveChanges();
						}
						LoginViewModel loginViewModel = new LoginViewModel();
						loginViewModel.Username = signUpViewModel.Username;
						loginViewModel.Password = signUpViewModel.Password;
						return Login(loginViewModel);
						return RedirectToAction("Index", "Home");
					}
					catch (Exception e)
					{
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