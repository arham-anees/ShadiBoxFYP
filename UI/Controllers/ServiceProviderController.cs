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
using UnitOfWork;

namespace UI.Controllers {
	public class ServiceProviderController : Controller {

		private AppDbContext _Context;
		private cServiceProviderRepository _ProviderRepository;
		private cProfileSectionRepository _ProfileSectionRepository;
		private cReviewRepository _ReviewRepository;
		private cFunctionTimeRepository _FunctionTimeRepository;

		public ServiceProviderController() {
			_Context = new AppDbContext();
			_ProviderRepository = new cServiceProviderRepository(_Context);
			_ProfileSectionRepository = new cProfileSectionRepository(_Context);
			_ReviewRepository=new cReviewRepository(_Context);
			_FunctionTimeRepository=new cFunctionTimeRepository(_Context);
		}

		public ActionResult Index(int? categoryId, int? cityId) {
			IndexServiceProviderViewModel viewModel = new IndexServiceProviderViewModel {
				ServiceCategories = cHelper.GetServiceCategories(),
				Cities = cHelper.GetCities()
			};
			try {
				var serviceProviders = _ProviderRepository.GetAll();
				if (categoryId.HasValue)
					serviceProviders = serviceProviders.Where(x => x.ServiceCategoryId == categoryId.Value);
				if (cityId.HasValue)
					serviceProviders = serviceProviders.Where(x => x.CityId == cityId.Value);
				if (cHelper.IsLoggedIn)
					serviceProviders = serviceProviders.Where(x => x.UserAddedById != cHelper.CurrentUser.Id);

				viewModel.ServiceProviders = serviceProviders.ToList();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			return View(viewModel);
		}

		public ActionResult Profile(int id,string Message) {
			ServiceProfileViewModel serviceProfile = new ServiceProfileViewModel();

			serviceProfile._ServiceProvider = _ProviderRepository.Get(id);
			serviceProfile._ProfileSection = _ProfileSectionRepository.GetAll(serviceProfile._ServiceProvider.Id).ToList();
			serviceProfile.Reviews = _ReviewRepository.GetAll().Where(x => x.ServiceProviderId == serviceProfile._ServiceProvider.Id).ToList();
			serviceProfile.FunctionTimes = _FunctionTimeRepository.GetAll().ToList();
			serviceProfile.ServiceProviderId = id;
			serviceProfile.DisplayMessage = Message;
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
			try
			{
				if (ModelState.IsValid)
				{
					using (var unit = new cUnitOfWork(new AppDbContext())) {
						cServiceProvider serviceProvider = new cServiceProvider();
						serviceProvider.Name = signUpServiceViewModel.ServiceName;
						serviceProvider.Email = signUpServiceViewModel.Email;
						serviceProvider.Phone = signUpServiceViewModel.Phone;
						serviceProvider.CityId = signUpServiceViewModel.CityId;
						serviceProvider.ServiceCategoryId = signUpServiceViewModel.CategoryId;
						serviceProvider.ServiceTypeId = signUpServiceViewModel.ServiceTypeId;
						serviceProvider.RentTypeId = signUpServiceViewModel.RentTypeId;
						serviceProvider.Rent = signUpServiceViewModel.Rent;
						serviceProvider.UserAddedById = cHelper.CurrentUser.Id;
						unit.ServiceProviderRepository.Add(serviceProvider);
						unit.SaveChanges();

						//todo: navigate to profile page
						signUpServiceViewModel.SuccessMessage = "Service added successfully";
					}
				}
			}
			catch (Exception exception)
			{
				signUpServiceViewModel.ErrorMessage= exception.Message;
			}

			return View(signUpServiceViewModel);
		}
		#endregion

		[HttpPost]
		public ActionResult AddReview(ServiceProfileViewModel viewModel)
		{
			try
			{
					cReview review = new cReview();
					review.Date = DateTime.Now;
					review.ServiceProviderId = viewModel.ServiceProviderId;
					review.Message = viewModel.FeedbackMessage;
					review.StarCount = viewModel.StarCount;
					review.UserId = cHelper.CurrentUser.Id;

					using (var unit = new cUnitOfWork(new AppDbContext()))
					{
						unit.ReviewRepository.Add(review);
						unit.SaveChanges();
					}
			}
			catch (Exception exception)
			{
				viewModel.DisplayMessage = exception.Message;
			}

			return RedirectToAction("Profile","ServiceProvider",new{ @id = viewModel.ServiceProviderId });
		}
	}
}