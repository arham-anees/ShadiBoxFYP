using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using PersistenceLayer;
using UI.Models;
using UI.ViewModels;
using UnitOfWork;

namespace UI.Controllers {
	[Authorize]
	public class AdminController : Controller {
		// GET: Admin
		public ActionResult Index()
		{
			if (!cHelper.IsAdmin)
				return RedirectToAction("Dashboard", "Account");
			AdminIndexViewModel viewModel = new AdminIndexViewModel();
			return View(viewModel);
		}

		#region Categories
		public ActionResult Categories(AdminCategoriesViewModel viewModel) {
			if (!cHelper.IsAdmin)
				return RedirectToAction("Dashboard", "Account");
			if (viewModel == null)
				viewModel = new AdminCategoriesViewModel();
			viewModel.Load();
			return View(viewModel);
		}
		public ActionResult AddCategory(AdminCategoriesViewModel viewModel) {
			if (!cHelper.IsAdmin)
				return RedirectToAction("Dashboard", "Account");
			try {
				cServiceCategory category = new cServiceCategory();
				category.Name = viewModel.NewCategoryName;
				category.Description = viewModel.NewCategoryDescription;
				using (var unit = new cUnitOfWork(new AppDbContext())) {
					unit.ServiceCategoryRepository.Add(category);
					unit.SaveChanges();
				}
				viewModel.SuccessMessage = "Category added Successfully";
			}
			catch (Exception exception) {
				viewModel.ErrorMessage = exception.Message;
			}
			return RedirectToAction("Categories", viewModel);
		}
		public ActionResult DeleteCategory(int id) {
			if (!cHelper.IsAdmin)
				return RedirectToAction("Dashboard", "Account");
			AdminCategoriesViewModel viewModel = new AdminCategoriesViewModel();
			try {
				using (var unit = new cUnitOfWork(new AppDbContext())) {
					unit.ServiceCategoryRepository.Delete(unit.ServiceCategoryRepository.Get(id));
					unit.SaveChanges();
				}
				viewModel.SuccessMessage = "Category added Successfully";
			}
			catch (Exception exception) {
				viewModel.ErrorMessage = exception.Message;
			}
			return RedirectToAction("Categories", viewModel);
		}
		#endregion

		#region CITIES
		public ActionResult Cities(CityViewModel viewModel) {
			if (!cHelper.IsAdmin)
				return RedirectToAction("Dashboard", "Account");
			if (viewModel==null)
				viewModel=new CityViewModel();

			return View(viewModel);

		}
		public ActionResult DeleteCity(int cityId) {
			if (!cHelper.IsAdmin)
				return RedirectToAction("Dashboard", "Account");
			AdminCategoriesViewModel viewModel = new AdminCategoriesViewModel();
			try {
				using (var unit = new cUnitOfWork(new AppDbContext())) {
					unit.CityRepository.Delete(unit.CityRepository.Get(cityId));
					unit.SaveChanges();
				}
				viewModel.SuccessMessage = "City added Successfully";
			}
			catch (Exception exception) {
				viewModel.ErrorMessage = exception.Message;
			}
			return RedirectToAction("Cities", viewModel);
		}
		public ActionResult AddCity(CityViewModel viewModel) {
			if (!cHelper.IsAdmin)
				return RedirectToAction("Dashboard", "Account");
			try {
				// TODO: Add insert logic here
				using (var unit = new cUnitOfWork(new AppDbContext())) {
					cCity city = new cCity();
					city.Name = viewModel.NewCityName;
					city.Description = viewModel.NewCityDescription;
					unit.CityRepository.Add(city);
					unit.SaveChanges();
					viewModel.Message = city.Name + " added successfully.";
				}
			}
			catch (Exception exception) {
				viewModel.ErrorMessage = exception.Message;
			}

			return RedirectToAction("Cities", viewModel);
		}
		#endregion

		#region ADMINS

		public ActionResult Admins(AdminListViewModel viewModel) {
			if (!cHelper.IsAdmin)
				return RedirectToAction("Dashboard", "Account");
			if (viewModel==null)
				viewModel=new AdminListViewModel();
			viewModel.Load();
			return View(viewModel);
		}

		public ActionResult AddAdmin(AdminListViewModel viewModel) {
			if (!cHelper.IsAdmin)
				return RedirectToAction("Dashboard", "Account");
			try
			{
				using (var unit=new cUnitOfWork(new AppDbContext()))
				{
					viewModel.NewAdmin.RoleId = 2;//admin id
					unit.UserRepository.Add(viewModel.NewAdmin);
					unit.SaveChanges();
				}
				viewModel.SuccessMessage = "Admin Added successfully";
			}
			catch (Exception exception)
			{
				viewModel.ErrorMessage = exception.Message;
			}
			return RedirectToAction("Admins", viewModel);
		}

		public ActionResult DeleteAdmin(int id) {
			if (!cHelper.IsAdmin)
				return RedirectToAction("Dashboard", "Account");
			AdminListViewModel viewModel = new AdminListViewModel();
			try {
				using (var unit = new cUnitOfWork(new AppDbContext())) {
					unit.UserRepository.Delete(unit.UserRepository.Get(id));
					unit.SaveChanges();
				}
				viewModel.SuccessMessage = "Admin Deleted Successfully";
			}
			catch (Exception exception) {
				viewModel.ErrorMessage = exception.Message;
			}
			return RedirectToAction("Admins", viewModel);
		}

		#endregion

		#region PROFILE

		public ActionResult Profile(UpdateProfileViewModel viewModel) {
			if (!cHelper.IsLoggedIn)
				return RedirectToAction("Index", "Home");
			if (viewModel == null)
				viewModel = new UpdateProfileViewModel();
			return View(viewModel);
		}

		public ActionResult UpdateProfile(UpdateProfileViewModel viewModel) {
			if (!cHelper.IsLoggedIn)
				return RedirectToAction("Index", "Home");
			try {
				cUser user = cHelper.CurrentUser;
				user.Name = viewModel.User.Name;
				user.Email = viewModel.User.Email;
				user.Phone = viewModel.User.Phone;
				using (var unit = new cUnitOfWork(new AppDbContext())) {
					unit.UserRepository.Update(user);
					unit.SaveChanges();
				}
				viewModel.SuccessMessage = "Profile updated successfully";
			}
			catch (Exception exception) {
				viewModel.ErrorMessage = exception.Message;
			}
			return RedirectToAction("Profile", viewModel);
		}

		public ActionResult UpdatePassword(UpdateProfileViewModel viewModel) {
			if (!cHelper.IsLoggedIn)
				return RedirectToAction("Index", "Home");
			try {
				if (viewModel.NewPasswornd == viewModel.ConfirmNewPassword) {
					if (viewModel.OldPassword == cHelper.CurrentUser.Password) {
						using (var unit = new cUnitOfWork(new AppDbContext())) {
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

		#endregion

	}
}