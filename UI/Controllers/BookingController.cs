using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using PersistenceLayer;
using UI.Models;
using UI.ViewModels;
using UnitOfWork;

namespace UI.Controllers
{
    public class BookingController : Controller
    {
	    public ActionResult AddBookingRequest(ServiceProfileViewModel profileViewModel)
	    {
		    try
		    {
					cBookingRequest request=new cBookingRequest();
					request.BookingDate = profileViewModel.Date;
					request.Message = profileViewModel.Message;
					request.NumberOfGuests = profileViewModel.Guests;
					request.UserId = cHelper.CurrentUser.Id;
					request.ServiceProviderId = profileViewModel.ServiceProviderId;
					request.Date=DateTime.Now;
					request.FunctionTimeId = profileViewModel.FunctionTime;

					using (var unit=new cUnitOfWork(new AppDbContext()))
					{
						unit.BookingRequestRepository.Add(request);
						unit.SaveChanges();
					}

					profileViewModel.DisplayMessage = "Booking Request successfully made";
		    }
				catch (Exception exception)
		    {
			    profileViewModel.DisplayMessage = exception.Message;
		    }

		    return RedirectToAction("Profile", "ServiceProvider",
			    new {@id = profileViewModel.ServiceProviderId, @Message = profileViewModel.DisplayMessage});
	    }
    }
}