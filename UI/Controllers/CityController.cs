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
	public class CityController : Controller {
		// GET: City
		public ActionResult Index(CityViewModel cityViewModel)
		{
			if (cityViewModel == null)
				cityViewModel = new CityViewModel();
			cityViewModel.Cities = cHelper.GetCities();
			return View(cityViewModel);
		}

		// GET: City/Details/5
		public ActionResult Details(int id) {
			return View();
		}

		// GET: City/Create
		public ActionResult Create() {
			return View();
		}

		// POST: City/Create
		[HttpPost]
		public ActionResult Create(CityViewModel cityViewModel) {
			try {
				// TODO: Add insert logic here
				using (var unit = new cUnitOfWork(new AppDbContext())) {
					cCity city=new cCity();
					city.Name = cityViewModel.NewCityName;
					city.Description = cityViewModel.NewCityDescription;
					unit.CityRepository.Add(city);
					unit.SaveChanges();
					cityViewModel.Message = city.Name + " added successfully.";
				}
			}
			catch (Exception exception)
			{
				cityViewModel.ErrorMessage = exception.Message;
			}
			return RedirectToAction("Index",cityViewModel);

		}



		// GET: City/Delete/5
		//public ActionResult Delete(int id)
		//{
		//    return View();
		//}

		// POST: City/Delete/5
		[HttpPost]
		public ActionResult Delete(int cityId) {
			try {
				// TODO: Add delete logic here
				using (var unit = new cUnitOfWork(new AppDbContext())) {
					unit.CityRepository.Delete(unit.CityRepository.Get(cityId));
					unit.SaveChanges();
				}

			}
			catch { }
			return RedirectToAction("Index");
		}
	}
}
