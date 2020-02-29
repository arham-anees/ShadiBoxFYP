using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;

namespace UI.ViewModels {
	public class ServiceProfileUpdateViewModel
	{
		private cServiceProviderRepository _ServiceProviderRepository;

		public ServiceProfileUpdateViewModel()
		{
			_ServiceProviderRepository=new cServiceProviderRepository(new AppDbContext());
		}
		public cServiceProvider ServiceProvider
		{
			get { return _ServiceProviderRepository.Get(cHelper.ServiceProvider.Id); }
		}

		public HttpPostedFileBase[] FileBase { get; set; }

		public string ErrorMessage { get; set; }
		public string SuccessMessage { get; set; }

		#region SELECT LIST ITEMS

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
		public List<SelectListItem> CategoriesSelectList {
			get {
				var list = new List<SelectListItem>();
				list.Add(new SelectListItem() {
					Text = "Select Category",
					Value = ""
				});
				foreach (var item in cHelper.GetServiceCategories()) {
					list.Add(new SelectListItem() {
						Value = item.Id.ToString(),
						Text = item.Name
					});
				}

				return list;
			}
		}

		public List<SelectListItem> ServiceTypesSelectList {
			get {
				var list = new List<SelectListItem>();
				list.Add(new SelectListItem() {
					Text = "Select Service Type",
					Value = ""
				});
				foreach (var item in cHelper.GeServiceTypes()) {
					list.Add(new SelectListItem() {
						Value = item.Id.ToString(),
						Text = item.Name
					});
				}

				return list;
			}
		}
		public List<SelectListItem> RentTypesSelectList {
			get {
				var list = new List<SelectListItem>();
				list.Add(new SelectListItem() {
					Text = "Select Rent Type",
					Value = ""
				});
				foreach (var item in cHelper.GetRentTypes()) {
					list.Add(new SelectListItem() {
						Value = item.Id.ToString(),
						Text = item.Name
					});
				}

				return list;
			}
		}

		#endregion


	}
}