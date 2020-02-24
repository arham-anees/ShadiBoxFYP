using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;

namespace UI.ViewModels {
	public class CityViewModel {
		public ICollection<cCity> Cities { get; set; }
		public string NewCityName { get; set; }
		public string NewCityDescription { get; set; }
		public string ErrorMessage { get; set; }
		public string Message { get; set; }
	}
}