using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;

namespace UI.ViewModels {
	public class UserDashboardViewModel
	{
		private AppDbContext _Context;
		private cBookingRequestRepository _BookingRequestRepository;
		private cBookingRepository _BookingRepository;
		private cBookingResponseRepository _BookingResponseRepository;

		public UserDashboardViewModel(AppDbContext context)
		{
			_Context = context;
			_BookingRequestRepository = new cBookingRequestRepository(context);
			_BookingRepository = new cBookingRepository(context);
			_BookingResponseRepository = new cBookingResponseRepository(context);
		}

	private IEnumerable<cBookingRequest> Requests
	{
		get { return _BookingRequestRepository.GetAll().Where(x => x.UserId == cHelper.CurrentUser.Id); }
	}
   private IEnumerable<cBookingResponse> Responses
   {
	   get
	   {
		   return _BookingResponseRepository.GetAll()
			   //.Join(_BookingRepository.GetAll().ToList(),response => response.BookingRequestId,booking=>booking.Id,
			   //  (response, booking) => response)
			   .Where(x => x.BookingRequest.UserId == cHelper.CurrentUser.Id);
	   }
   }
		public int TotalRequests
		{
			get
			{
				if (Requests != null)
					return Requests.Count();
				return 0;
			}
		}
		public int TotalResponses
		{
			get { return _BookingResponseRepository.GetAll().Where(x => Requests.Select(r=>r.Id).Contains(x.Id))?.Count()??0; }
		}
		public int Pending
		{
			get
			{
				//return _BookingRepository.GetAll().Where(x => !(Requests.Select(r => r.Id).Contains(x.Id)))?.Count() ?? 0;
				return TotalRequests - TotalResponses;
			}
		}

		public int TotalEvents
		{
			get {
				return _BookingResponseRepository.GetAll()
					.Where(x => x.BookingRequest.UserId == cHelper.CurrentUser.Id && x.IsAccepted).ToList().Count;
			}
		}
		public int EventsUpcoming
		{
			get {
				return _BookingResponseRepository.GetAll()
					.Where(x => x.BookingRequest.UserId == cHelper.CurrentUser.Id && x.IsAccepted && x.BookingRequest.BookingDate>=DateTime.Now).ToList().Count;
			}
		}
		public int EventsDone
		{
			get {
				return _BookingResponseRepository.GetAll()
					.Where(x => x.BookingRequest.UserId == cHelper.CurrentUser.Id && x.IsAccepted && x.BookingRequest.BookingDate < DateTime.Now).ToList().Count;
			}
		}
	}
}