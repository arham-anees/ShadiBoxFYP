using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;

namespace UI.ViewModels
{
	public class ProfileEventsViewModel
	{
		//private cBookingRepository _BookingRepository;

		public ProfileEventsViewModel()
		{
			//_BookingRepository=new cBookingRepository(new AppDbContext());
		}

		public List<cBooking> Bookings
		{
			get
			{
				return null; // _BookingRepository.GetAll().Where(x => x.UserId == cHelper.CurrentUser.Id).ToList(); }
			}
		}
	}
}