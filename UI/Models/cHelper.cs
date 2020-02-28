using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UnitOfWork;

namespace UI.Models {
	public static class cHelper
	{
		#region FIELDS

		private static readonly AppDbContext _Context=new AppDbContext();
		private static readonly cServiceCategoryRepository _ServiceCategoryRepository=new cServiceCategoryRepository(_Context);
		private static readonly cServiceProviderRepository _ServiceProviderRepository=new cServiceProviderRepository(_Context);
		private static readonly cCityRepository _CityRepository=new cCityRepository(_Context);
		private static readonly cServiceTypeRepository _ServiceTypeRepository=new cServiceTypeRepository(_Context);
		private static readonly cRentTypeRepository _RentTypeRepository=new cRentTypeRepository(_Context);
		private static readonly cSectionContentTypeRepository _SectionContentTypeRepository=new cSectionContentTypeRepository(_Context);
		private static readonly cSectionHeadRepository _SectionHeadRepository=new cSectionHeadRepository(_Context);
		private  static readonly cUserRepository _UserRepository=new cUserRepository(_Context);
		#endregion

		#region PROPERTIES

		private static cUser _CurrentUser;
		public static cUser CurrentUser {
			get
			{
				if (_CurrentUser == null)
					_CurrentUser = _UserRepository.Get(1);
				return _CurrentUser;
			}
			set { _CurrentUser = value; }
		}

		public static cServiceProvider ServiceProvider
		{
			get
			{
				if(IsServiceProvider)
					return _ServiceProviderRepository.GetAll().Where(x => x.UserAddedById == cHelper.CurrentUser.Id).Single();
				return null;
			}
		}

		public static bool IsServiceProvider
		{
			get
			{
				if (CurrentUser != null)
					return _ServiceProviderRepository.GetAll().Where(x => x.UserAddedById == CurrentUser.Id).Any();
				return false;
			}
		}

		#endregion

		#region METHODS

		public static ICollection<cServiceCategory> GetServiceCategories()
		{
			return _ServiceCategoryRepository.GetAll().ToList();
		}
		public static ICollection<cCity> GetCities()
		{
			return _CityRepository.GetAll().ToList();
		}
		public static ICollection<cServiceType> GeServiceTypes()
		{
			return _ServiceTypeRepository.GetAll().ToList();
		}
		public static ICollection<cRentType> GetRentTypes()
		{
			return _RentTypeRepository.GetAll().ToList();
		}
		public static ICollection<cSectionHead> GetSectionHeads()
		{
			return _SectionHeadRepository.GetAll().ToList();
		}
		public static ICollection<cSectionContentType> GetContentTypes()
		{
			return _SectionContentTypeRepository.GetAll().ToList();
		}


		#endregion

	}
}