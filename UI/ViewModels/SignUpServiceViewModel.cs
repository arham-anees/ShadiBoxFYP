using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

		public List<SelectListItem> CitiesSelectList
		{
			get
			{
				var list=new List<SelectListItem>();
				list.Add(new SelectListItem()
				{
					Text = "Select City",
					Value = ""
				});
				foreach (var cCity in _Cities)
				{
						list.Add(new SelectListItem()
						{
							Value = cCity.Id.ToString(),
							Text = cCity.Name
						});
				}

				return list;
			}
		}
		public List<SelectListItem> CategoriesSelectList
		{
			get
			{
				var list=new List<SelectListItem>();
				list.Add(new SelectListItem()
				{
					Text = "Select Category",
					Value = ""
				});
				foreach (var item in _ServiceCategories)
				{
						list.Add(new SelectListItem()
						{
							Value = item.Id.ToString(),
							Text = item.Name
						});
				}

				return list;
			}
		}

		public string ServiceName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public int CityId { get; set; }
		public int CategoryId { get; set; }

	}
}