using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using UI.Models;

namespace UI.ViewModels {
	public class ProfileIndexViewModel {
		
			public cServiceProvider _ServiceProvider { get; set; }
			public int ServiceProviderId { get; set; }
			public ICollection<cProfileSection> _ProfileSection;

			public string ServiceName {
				get => _ServiceProvider.Name;
			}

			public string City {
				get => _ServiceProvider.City.Name;
			}

			public string Category {
				get => _ServiceProvider.ServiceCategory.Name;
			}

			public string ServiceType {
				get => _ServiceProvider.ServiceType.Name;
			}

			public string Rent {
				get => _ServiceProvider.Rent.ToString("0.0");
			}

			public ICollection<cProfileSection> ProfileSection {
				get => _ProfileSection;
			}
			public IEnumerable<cSectionHead> ProfileSectionDistinct {
				get => _ProfileSection.GroupBy(x=>x.SectionHead).Select(x=>x.Key);
			}

			public ICollection<cServiceProvider> RelatedServiceProviders { get; set; }
			public string NewService { get; set; }
			public string ErrorMessage { get; set; }
			public string SuccessMessage { get; set; }
			public int NewContentTypeId { get; set; }
			public int NewContentHeadId { get; set; }
			public string NewContentBody { get; set; }
			public string NewPackageName { get; set; }
			public string NewPackageRate { get; set; }
			public ICollection<SelectListItem> ContentHeadSelectionList {
				get {
					var list = new List<SelectListItem>();
					list.Add(new SelectListItem() {
						Text = "Select Section Head",
						Value = ""
					});
					foreach (var item in cHelper.GetSectionHeads()) {
						list.Add(new SelectListItem() {
							Value = item.Id.ToString(),
							Text = item.Name
						});
					}

					return list;
				}
			}		
			public ICollection<SelectListItem> ContentTypeSelectionList {
				get {
					var list = new List<SelectListItem>();
					list.Add(new SelectListItem() {
						Text = "Select Content Type",
						Value = ""
					});
					foreach (var item in cHelper.GetContentTypes())
					{
						if (item.Id != 3)
							list.Add(new SelectListItem()
							{
								Value = item.Id.ToString(),
								Text = item.Name
							});
					}

					return list;
				}
			}

			public class Booking {
				public string Name { get; set; }
				public string Email { get; set; }
				public string Phone { get; set; }
				public int Guests { get; set; }
				public DateTime Date { get; set; }
				public string Message { get; set; }
				public int FunctionTime { get; set; }
			}
		
	}
}