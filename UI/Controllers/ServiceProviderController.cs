using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;
using UI.ViewModels;

namespace UI.Controllers {
	public class ServiceProviderController : Controller {

		private AppDbContext _Context;
		private cServiceProviderRepository _ProviderRepository;
		private cProfileSectionRepository _ProfileSectionRepository;

		public ServiceProviderController() {

			_Context = new AppDbContext();
			_ProviderRepository = new cServiceProviderRepository(_Context);
			_ProfileSectionRepository = new cProfileSectionRepository(_Context);
		}

		public ActionResult Index(int? categoryId, int? cityId) {
			//todo: refine collection send to view
			IndexServiceProviderViewModel viewModel=new IndexServiceProviderViewModel();
			viewModel.ServiceCategories = cHelper.GetServiceCategories();
			viewModel.Cities = cHelper.GetCities();
			try {
				var serviceProviders = _ProviderRepository.GetAll();
				if (categoryId.HasValue)
					serviceProviders = serviceProviders.Where(x => x.ServiceCategoryId == categoryId.Value);
				if (cityId.HasValue)
					serviceProviders = serviceProviders.Where(x => x.CityId == cityId.Value);

				viewModel.ServiceProviders = serviceProviders.ToList();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			return View(viewModel);
		}

		public ActionResult Profile(int id) {
			ServiceProfileViewModel serviceProfile = new ServiceProfileViewModel();

			serviceProfile._ServiceProvider = _ProviderRepository.Get(id);
			serviceProfile._ProfileSection = _ProfileSectionRepository.GetAll(serviceProfile._ServiceProvider.Id).ToList();
			//serviceProfile.RelatedServiceProviders
			return View(serviceProfile);
		}



		#region SIGN UP
		[HttpGet]
		public ActionResult SignUp() {
			SignUpServiceViewModel model = new SignUpServiceViewModel();
			return View(model);
		}

		[HttpPost]
		public ActionResult SignUp(SignUpServiceViewModel signUpServiceViewModel) {
			if (ModelState.IsValid) {
				cServiceProvider serviceProvider=new cServiceProvider();
				serviceProvider.CityId = signUpServiceViewModel.CityId;
				serviceProvider.ServiceCategoryId = signUpServiceViewModel.CategoryId;
			}
			return View(signUpServiceViewModel);
		}
		#endregion

	}
}