using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;

namespace UI.ViewModels {
	public class ProfileReviewsViewModel
	{
		private cReviewRepository _ReviewRepository;

		public ProfileReviewsViewModel()
		{
			_ReviewRepository=new cReviewRepository(new AppDbContext());
		}

		public List<cReview> Reviews
		{
			get { return _ReviewRepository.GetAll().Where(x => x.UserId == cHelper.CurrentUser.Id).ToList(); }
		}
	}
}