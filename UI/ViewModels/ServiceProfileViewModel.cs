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
		public int ServiceProviderId { get; set; }
		public cServiceProvider _ServiceProvider { get; set; }
		public ICollection<cProfileSection> _ProfileSection { get; set; }
		public int NewStartCount { get; set; }
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

		public string Cover
		{
			get
			{
				if (_ServiceProvider.CoverPicture == null)
					return "https://www.apsa.co.za/xenforo/styles/brivium/ProfileCover/default.jpg";
				return _ServiceProvider.CoverPicture;
			}
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

		#region REVIEWS

		public ICollection<cReview> Reviews { get; set; }

		public int TotalReview
		{
			get
			{
				return Reviews == null ? 0 : Reviews.Count;
			}
		}

		public double AverageRate
		{
			get
			{
				if (Reviews == null) return 0;
				return Reviews.Average(x => x.StarCount); }
		}

		public int StarCount { get; set; }
		public string FeedbackMessage { get; set; }

		public int Stars1
		{
			get { return Reviews?.Where(x => x.StarCount == 1).Count() ?? 0; }
		}
		public int Stars2 {
			get { return Reviews?.Where(x => x.StarCount == 2).Count() ?? 0; }
		}
		public int Stars3 {
			get { return Reviews?.Where(x => x.StarCount == 3).Count() ?? 0; }
		}
		public int Stars4 {
			get { return Reviews?.Where(x => x.StarCount == 4).Count() ?? 0; }
		}
		public int Stars5 {
			get { return Reviews?.Where(x => x.StarCount == 5).Count() ?? 0; }
		}
		#endregion

		public ICollection<cServiceProvider> RelatedServiceProviders { get; set; }
		public ICollection<cFunctionTime> FunctionTimes { get; set; }


			public int Guests { get; set; }
			public DateTime Date { get; set; }
			public string Message { get; set; }
			public int FunctionTime { get; set; }
			public string ErrorMessage { get; set; }
			public string DisplayMessage { get; set; }




	}
}