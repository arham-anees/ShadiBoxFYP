using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;

namespace UI.ViewModels
{
	public class ProfileRequestsViewModel
	{
		private cBookingRequestRepository _BookingRequestRepository;
		public ProfileRequestsViewModel()
		{
			_BookingRequestRepository=new cBookingRequestRepository(new AppDbContext());
		}
		public List<cBookingRequest> BookingRequests
		{
			get { return _BookingRequestRepository.GetAll().Where(x => x.UserId == cHelper.CurrentUser.Id).ToList(); }
		}
	}
}