using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using UI.Models;

namespace UI.ViewModels {
	public class UpdateProfileViewModel {

		public UpdateProfileViewModel()
		{
			User = cHelper.CurrentUser;
		}
		public cUser User { get; set; }

		public List<SelectListItem> CitiesSelectList {
			get {
				var list = new List<SelectListItem>();
				list.Add(new SelectListItem() {
					Text = "Select City",
					Value = ""
				});
				foreach (var cCity in cHelper.GetCities()) {
					list.Add(new SelectListItem() {
						Value = cCity.Id.ToString(),
						Text = cCity.Name
					});
				}

				return list;
			}
		}
		#region PASSWORDS
		public string OldPassword { get; set; }
		public string NewPasswornd { get; set; }
		public string ConfirmNewPassword { get; set; }

		#endregion

		public string ErrorMessage { get; set; }
		public string SuccessMessage { get; set; }
	}
}