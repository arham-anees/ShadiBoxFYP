using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;

namespace UI.ViewModels {
	public class HomeIndexViewModel
	{
		private cServiceCategoryRepository _ServiceCategoryRepository;

		public HomeIndexViewModel()
		{
			AppDbContext dbContext=new AppDbContext();
			_ServiceCategoryRepository=new cServiceCategoryRepository(dbContext);
		}

		public List<cServiceCategory> ServiceCategories
		{
			get { return _ServiceCategoryRepository.GetAll().ToList(); }
		}
	}
}