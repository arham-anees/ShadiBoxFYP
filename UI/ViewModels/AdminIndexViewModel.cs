using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.ViewModels {
	public class AdminIndexViewModel {
		public string ErrorMessage { get; set; }
		public string SuccessMessage { get; set; }
		public List<SelectListItem> Cities { get; set; }
		public List<SelectListItem> Categories { get; set; }
	}
}