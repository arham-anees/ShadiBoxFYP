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
	[Authorize]
	public class AccountController : Controller {
		//#region SIGN IN
		
		//[HttpGet]
		//public ActionResult Login()
		//{
		//	if (cHelper.CurrentUser != null)
		//		return RedirectToAction("Index", "Home");
		//	return View();
		//}

		//[HttpPost]
		//public ActionResult Login(LoginViewModel loginViewModel) {
		//	if (ModelState.IsValid) {
		//		try
		//		{
		//			cUserRepository userRepository = new cUserRepository(new AppDbContext());
		//			var user = userRepository.Authenticate(loginViewModel.Username, loginViewModel.Password);
		//			if (user != null)
		//			{
		//				cHelper.CurrentUser = user;
		//				return RedirectToAction("Index", "Home");
		//			}
		//			else
		//				loginViewModel.ErrorMessage = "Invalid Username and password";
		//		}
		//		catch (Exception e)
		//		{
		//			loginViewModel.ErrorMessage = e.Message;
		//		}
		//	}
		//	return View(loginViewModel);
		//}
		//#endregion


		public ActionResult Profile(UpdateProfileViewModel viewModel)
		{
			if (!cHelper.IsLoggedIn)
				return RedirectToAction("Index", "Home");
			if (cHelper.IsAdmin)
				return RedirectToAction("Index", "Admin");
			if (viewModel == null)
				viewModel = new UpdateProfileViewModel();
			return View(viewModel);
		}
		public ActionResult Dashboard() {
			if (!cHelper.IsLoggedIn)
				return RedirectToAction("Index", "Home");
			if (cHelper.IsAdmin)
				return RedirectToAction("Index", "Admin");
			UserDashboardViewModel userDashboardViewModel=new UserDashboardViewModel(new AppDbContext());
			return View(userDashboardViewModel);
		}

		public ActionResult Requests() {
			if (!cHelper.IsLoggedIn)
				return RedirectToAction("Index", "Home");
			if (cHelper.IsAdmin)
				return RedirectToAction("Index", "Admin");
			ProfileRequestsViewModel viewModel=new ProfileRequestsViewModel();
			return View(viewModel);
		}
		public ActionResult Responses() {
			if (!cHelper.IsLoggedIn)
				return RedirectToAction("Index", "Home");
			if (cHelper.IsAdmin)
				return RedirectToAction("Index", "Admin");
			ProfileResponsesViewModel viewModel=new ProfileResponsesViewModel();
			return View(viewModel);
		}
		public ActionResult Events() {
			if (!cHelper.IsLoggedIn)
				return RedirectToAction("Index", "Home");
			if (cHelper.IsAdmin)
				return RedirectToAction("Index", "Admin");
			ProfileEventsViewModel viewModel=new ProfileEventsViewModel();
			return View(viewModel);
		}

		public ActionResult Reviews() {
			if (!cHelper.IsLoggedIn)
				return RedirectToAction("Index", "Home");
			if (cHelper.IsAdmin)
				return RedirectToAction("Index", "Admin");
			ProfileReviewsViewModel viewModel=new ProfileReviewsViewModel();
			return View(viewModel);
		}

		public ActionResult UpdateProfile(UpdateProfileViewModel viewModel) {
			if (!cHelper.IsLoggedIn)
				return RedirectToAction("Index", "Home");
			if (cHelper.IsAdmin)
				return RedirectToAction("Index", "Admin");
			try
			{
				cUser user = cHelper.CurrentUser;
				user.Name = viewModel.User.Name;
				user.Email = viewModel.User.Email;
				user.Phone = viewModel.User.Phone;
				using (var unit=new cUnitOfWork(new AppDbContext()))
				{
					unit.UserRepository.Update(user);
					unit.SaveChanges();
				}
				viewModel.SuccessMessage = "Profile updated successfully";
			}
			catch (Exception exception)
			{
				viewModel.ErrorMessage=exception.Message;
			}
			return RedirectToAction("Profile", viewModel);
		}

		public ActionResult UpdatePassword(UpdateProfileViewModel viewModel) {
			if (!cHelper.IsLoggedIn)
					return RedirectToAction("Index", "Home");
			if (cHelper.IsAdmin)
				return RedirectToAction("Index", "Admin");
			try {
				if (viewModel.NewPasswornd == viewModel.ConfirmNewPassword) {
					if (viewModel.OldPassword == cHelper.CurrentUser.Password) {
						using (var unit=new cUnitOfWork(new AppDbContext()))
						{
							cUser user = cHelper.CurrentUser;
							user.Password = viewModel.NewPasswornd;
							unit.UserRepository.Update(user);
							unit.SaveChanges();
						}

						viewModel.SuccessMessage = "Password updated successfully";
					}
					else {
						viewModel.ErrorMessage = "Invalid old password. Please insert a valid password";
					}
				}
				else {
					viewModel.ErrorMessage = "New passwords do not match. Please enter identical passwords";
				}
			}
			catch (Exception exception) {
				viewModel.ErrorMessage = exception.Message;
			}
			return RedirectToAction("Profile", viewModel);
		}

	}
}