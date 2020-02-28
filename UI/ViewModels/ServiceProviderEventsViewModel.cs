using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;

namespace UI.ViewModels {
	public class ServiceProviderEventsViewModel
	{
		private cBookingResponseRepository _BookingResponseRepository;

		public ServiceProviderEventsViewModel()
		{
			_BookingResponseRepository=new cBookingResponseRepository(new AppDbContext());
		}

		public List<cBookingResponse> BookingResponses
		{
			get
			{
				return _BookingResponseRepository.GetAll()
					.Where(x => x.BookingRequest.ServiceProviderId == cHelper.ServiceProvider.Id && x.IsAccepted).ToList();
			}
		}

	}
}