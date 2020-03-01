using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersistenceLayer;
using Repositories;
using UI.Models;

namespace UI.ViewModels {
	public class AdminIndexViewModel
	{
		private cUserRepository _UserRepository;
		private cCityRepository _CityRepository;
		private cServiceCategoryRepository _ServiceCategoryRepository;
		private cServiceProviderRepository _ServiceProviderRepository;
		private cBookingResponseRepository _BookingResponseRepository;

		public AdminIndexViewModel()
		{
			AppDbContext context=new AppDbContext();
			_BookingResponseRepository=new cBookingResponseRepository(context);
			_ServiceCategoryRepository=new cServiceCategoryRepository(context);
			_CityRepository=new cCityRepository(context);
			_ServiceProviderRepository=new cServiceProviderRepository(context);
			_UserRepository=new cUserRepository(context);
			_Load();
		}

		private void _Load()
		{
			Admins = _UserRepository.GetAdminList().Count;
			Customers = _UserRepository.GetAll().Count() - Admins;
			Cities = _CityRepository.GetAll().Count();
			ServiceProviders = _ServiceProviderRepository.GetAll().Count();
			Categories = _ServiceCategoryRepository.GetAll().Count();
			Events = _BookingResponseRepository.GetAll()
				.Count(x => x.IsAccepted && x.BookingRequest.BookingDate > DateTime.Now);
		}

		public string ErrorMessage { get; set; }
		public string SuccessMessage { get; set; }


		public int Customers { get; set; }
		public int Admins { get; set; }
		public int Cities { get; set; }
		public int ServiceProviders { get; set; }
		public int Categories { get; set; }
		public int Events { get; set; }
	}
}