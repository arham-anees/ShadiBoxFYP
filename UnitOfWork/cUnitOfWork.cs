using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersistenceLayer;
using Repositories;

namespace UnitOfWork {
	public class cUnitOfWork:IDisposable {

		#region FIELDS

		private AppDbContext _Context;

		#endregion

		#region PROPERTIES

		public cUserRepository UserRepository { get; set; }

		//public cBookingRepository BookingRepository { get; set; }

		public cBookingResponseRepository BookingResponseRepository { get; set; }

		public cBookingRequestRepository BookingRequestRepository { get; set; }

		public cCityRepository CityRepository { get; set; }

		public cProfileSectionRepository ProfileSectionRepository { get; set; }

		public cReviewRepository ReviewRepository { get; set; }

		public cSectionContentRepository SectionContentRepository { get; set; }

		public cServiceProviderRepository ServiceProviderRepository { get; set; }
		public cServiceCategoryRepository ServiceCategoryRepository { get; set; }

		#endregion



		public cUnitOfWork(AppDbContext context)
		{
			_Context = context;
			UserRepository = new cUserRepository(_Context);
			//BookingRepository = new cBookingRepository(_Context);
			BookingResponseRepository = new cBookingResponseRepository(_Context);
			BookingRequestRepository = new cBookingRequestRepository(_Context);
			CityRepository = new cCityRepository(_Context);
			ProfileSectionRepository = new cProfileSectionRepository(_Context);
			ReviewRepository = new cReviewRepository(_Context);
			SectionContentRepository = new cSectionContentRepository(_Context);
			ServiceProviderRepository = new cServiceProviderRepository(_Context);
			ServiceCategoryRepository = new cServiceCategoryRepository(_Context);
		}

		public void SaveChanges()
		{
			_Context.SaveChanges();
		}

		public void Dispose()
		{
			_Context?.Dispose();
		}
	}
}
