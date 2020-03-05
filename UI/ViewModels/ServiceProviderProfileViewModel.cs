using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;

namespace UI.ViewModels {
	public class ServiceProviderProfileViewModel
	{
		//private cBookingRepository _BookingRepository;
		private cBookingResponseRepository _BookingResponseRepository;
		private cBookingRequestRepository _BookingRequestRepository;
		public ServiceProviderProfileViewModel()
		{
			var context=new AppDbContext();
			//_BookingRepository=new cBookingRepository(context);
			_BookingRequestRepository=new cBookingRequestRepository(context);
			_BookingResponseRepository=new cBookingResponseRepository(context);
		}

		public int TotalRequests
		{
			get
			{
				return _BookingRequestRepository.GetAll().Where(x => x.ServiceProviderId == cHelper.ServiceProvider.Id).Count();
			}
		}

		public int Responses
		{
			get
			{
				return _BookingResponseRepository.GetAll()
					.Where(x => x.BookingRequest.ServiceProviderId == cHelper.ServiceProvider.Id).Count();
			}
		}
		public int Pending
		{
			get { return TotalRequests - Responses; }
		}
		public int TotalEvents
		{
			get {
				return _BookingResponseRepository.GetAll()
					.Where(x => x.BookingRequest.ServiceProviderId == cHelper.ServiceProvider.Id && x.IsAccepted).ToList().Count;
			}
		}
		public int CompletedEvents
		{
			get {
				return _BookingResponseRepository.GetAll()
					.Where(x => x.BookingRequest.ServiceProviderId == cHelper.ServiceProvider.Id && x.IsAccepted && x.BookingRequest.BookingDate<DateTime.Now).ToList().Count;
			}
		}
		public int UpcomingEvents
		{
			get { return TotalEvents - CompletedEvents; }
		}
	}
}