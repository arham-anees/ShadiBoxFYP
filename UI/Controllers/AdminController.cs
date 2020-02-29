using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using PersistenceLayer;
using UI.ViewModels;
using UnitOfWork;

namespace UI.Controllers {
	[Authorize]
	public class AdminController : Controller {
		// GET: Admin
		public ActionResult Index() {
			AdminIndexViewModel viewModel = new AdminIndexViewModel();
			return View(viewModel);
		}

		#region Categories
		public ActionResult Categories(AdminCategoriesViewModel viewModel) {
			if (viewModel == null)
				viewModel = new AdminCategoriesViewModel();
			viewModel.Load();
			return View(viewModel);
		}
		public ActionResult AddCategory(AdminCategoriesViewModel viewModel) {
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
		public ActionResult Cities(CityViewModel viewModel)
		{
			if(viewModel==null)
				viewModel=new CityViewModel();

			return View(viewModel);

		}
		public ActionResult DeleteCity(int cityId) {
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
		public ActionResult AddCity(CityViewModel viewModel)
		{
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

		public ActionResult Admins(AdminListViewModel viewModel)
		{
			if(viewModel==null)
				viewModel=new AdminListViewModel();
			viewModel.Load();
			return View(viewModel);
		}

		#endregion

	}
}