using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
		private static readonly cCityRepository _CityRepository=new cCityRepository(_Context);

		#endregion

		#region PROPERTIES

		public static cUser CurrentUser { get; set; }

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

		#endregion

	}
}