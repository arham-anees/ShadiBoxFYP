using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;

namespace UI.ViewModels {
	public class AdminCategoriesViewModel
	{
		private cServiceCategoryRepository _ServiceCategoryRepository;

		public AdminCategoriesViewModel()
		{
			_ServiceCategoryRepository=new cServiceCategoryRepository(new AppDbContext());
		}

		public void Load()
		{
			Categories = _ServiceCategoryRepository.GetAll().ToList();
		}
		public List<cServiceCategory> Categories { get; set; }

		public string ErrorMessage { get; set; }
		public string SuccessMessage { get; set; }


		public string NewCategoryName { get; set; }
		public string NewCategoryDescription { get; set; }
	}
}