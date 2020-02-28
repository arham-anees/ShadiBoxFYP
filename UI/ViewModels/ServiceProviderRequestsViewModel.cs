using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;

namespace UI.ViewModels {
	public class ServiceProviderRequestsViewModel {
		private cBookingRequestRepository _BookingRequestRepository;
		private cBookingResponseRepository _BookingResponseRepository;
		public ServiceProviderRequestsViewModel() {
			var _Context=new AppDbContext();
			_BookingRequestRepository = new cBookingRequestRepository(_Context);
			_BookingResponseRepository=new cBookingResponseRepository(_Context);
		}
		public List<cBookingRequest> BookingRequests {
			get { return _BookingRequestRepository.GetAll().Where(x => x.ServiceProviderId == cHelper.ServiceProvider.Id).ToList(); }
		}


		public int BookingRequestId { get; set; }
		public string Reply { get; set; }
		public int IsAccepted { get; set; }


		public bool IsResponded(int requestId)
		{
			return _BookingResponseRepository.GetAll().Where(x => x.BookingRequestId == requestId).Any();
		}
	}
}