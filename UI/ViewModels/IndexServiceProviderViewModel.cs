using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;

namespace UI.ViewModels {
	public class IndexServiceProviderViewModel {
		public ICollection<cServiceProvider> ServiceProviders { get; set; }
		public ICollection<cServiceCategory> ServiceCategories { get; set; }
		public ICollection<cCity> Cities { get; set; }
	}
}