using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;

namespace UI.ViewModels {
	public class ServiceProfileViewModel
	{

		public cServiceProvider _ServiceProvider;
		public ICollection<cProfileSection> _ProfileSection;

		public string ServiceName
		{
			get => _ServiceProvider.Name;
		}

		public string City
		{
			get => _ServiceProvider.City.Name;
		}

		public string Category
		{
			get => _ServiceProvider.ServiceCategory.Name;
		}

		public string ServiceType
		{
			get => _ServiceProvider.ServiceType.Name;
		}

		public string Rent
		{
			get => _ServiceProvider.Rent.ToString("0.0");
		}

		public ICollection<cProfileSection> ProfileSection
		{
			get => _ProfileSection;
		}
		public IEnumerable<cSectionHead> ProfileSectionDistinct
		{
			get => _ProfileSection.GroupBy(x=>x.SectionHead).Select(x=>x.Key);
		}

		public ICollection<cServiceProvider> RelatedServiceProviders { get; set; }
		public string NewService { get; set; }
		public string NewComment { get; set; }

		public class Booking
		{
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