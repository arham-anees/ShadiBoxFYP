using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using PersistenceLayer;
using Repositories;
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
			return View();
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

			}
			return View(signUpServiceViewModel);
		}
		#endregion

	}
}