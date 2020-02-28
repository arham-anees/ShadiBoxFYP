using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;

namespace UI.ViewModels {
	public class ServiceProviderReviewsVeiwModel
	{

		private cReviewRepository _ReviewRepository;

		public ServiceProviderReviewsVeiwModel()
		{
			_ReviewRepository=new cReviewRepository(new AppDbContext());
		}

		public List<cReview> Reviews
		{
			get { return _ReviewRepository.GetAll().Where(x => x.ServiceProviderId == cHelper.ServiceProvider.Id).ToList(); }
		}
	}
}