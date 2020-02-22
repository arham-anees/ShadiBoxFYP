using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using UI.Models;

namespace UI.ViewModels {
	public class SignUpServiceViewModel {
		private ICollection<cCity> _Cities = cHelper.GetCities();
		private ICollection<cServiceCategory> _ServiceCategories = cHelper.GetServiceCategories();

		public ICollection<cCity> Cities
		{
			get => _Cities;
		}

		public ICollection<cServiceCategory> ServiceCategories
		{
			get => _ServiceCategories;
		}

		public string ServiceName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }

	}
}