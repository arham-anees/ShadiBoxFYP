using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using PersistenceLayer;
using UI.ViewModels;
using UnitOfWork;

namespace UI.Controllers {
	public class ServiceProviderProfileController : Controller {
		// GET: ServiceProviderProfile
		public ActionResult Index() {
			ServiceProviderProfileViewModel viewModel = new ServiceProviderProfileViewModel();
			return View(viewModel);
		}

		public ActionResult Requests() {
			ServiceProviderRequestsViewModel viewModel = new ServiceProviderRequestsViewModel();
			return View(viewModel);
		}

		public ActionResult PostResponse(ServiceProviderRequestsViewModel viewModel) {
			try {
				cBookingResponse response = new cBookingResponse();
				response.BookingRequestId = viewModel.BookingRequestId;
				response.Message = viewModel.Reply;
				response.IsAccepted = viewModel.IsAccepted == 1 ? true : false;
				response.Date = DateTime.Now;
				using (var unit = new cUnitOfWork(new AppDbContext())) {
					unit.BookingResponseRepository.Add(response);
					unit.SaveChanges();
				}
			}
			catch (Exception exception) {
			}
			return RedirectToAction("Requests");
		}

		public ActionResult Responses() {
			ServiceProviderResponsesViewModel viewModel = new ServiceProviderResponsesViewModel();
			return View(viewModel);
		}

		public ActionResult Events() {
			ServiceProviderEventsViewModel viewModel = new ServiceProviderEventsViewModel();
			return View(viewModel);
		}

		public ActionResult Reviews() {
			ServiceProviderReviewsVeiwModel viewModel = new ServiceProviderReviewsVeiwModel();
			return View(viewModel);
		}
	}
}