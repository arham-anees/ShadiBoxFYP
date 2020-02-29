using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;

namespace UI.ViewModels {
	public class AdminListViewModel
	{
		private cUserRepository _UserRepository;

		public AdminListViewModel()
		{
			_UserRepository=new cUserRepository(new AppDbContext());
		}

		public void Load()
		{
			Admins = _UserRepository.GetAdminList();
		}
		public string ErrorMessage { get; set; }
		public string SuccessMessage { get; set; }
		public List<cUser> Admins { get; set; }

	}
}