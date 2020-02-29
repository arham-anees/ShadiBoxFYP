using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;
using UI.ViewModels;
using UnitOfWork;

namespace UI.Controllers {
	[Authorize]
	public class ServiceProviderProfileController : Controller {
		public ActionResult Index()
		{
			//AuthenticateServiceProvider();

			if (!cHelper.IsServiceProvider)
				return RedirectToAction("Dashboard", "Account");
			ServiceProviderProfileViewModel viewModel = new ServiceProviderProfileViewModel();
			return View(viewModel);
		}

		public ActionResult Requests() {

			if (!cHelper.IsServiceProvider)
				return RedirectToAction("Dashboard", "Account");
			ServiceProviderRequestsViewModel viewModel = new ServiceProviderRequestsViewModel();
			return View(viewModel);
		}

		public ActionResult PostResponse(ServiceProviderRequestsViewModel viewModel) {

			if (!cHelper.IsServiceProvider)
				return RedirectToAction("Dashboard", "Account");
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

			if (!cHelper.IsServiceProvider)
				return RedirectToAction("Dashboard", "Account");
			ServiceProviderResponsesViewModel viewModel = new ServiceProviderResponsesViewModel();
			return View(viewModel);
		}

		public ActionResult Events() {

			if (!cHelper.IsServiceProvider)
				return RedirectToAction("Dashboard", "Account");
			ServiceProviderEventsViewModel viewModel = new ServiceProviderEventsViewModel();
			return View(viewModel);
		}

		public ActionResult Reviews() {

			if (!cHelper.IsServiceProvider)
				return RedirectToAction("Dashboard", "Account");
			ServiceProviderReviewsVeiwModel viewModel = new ServiceProviderReviewsVeiwModel();
			return View(viewModel);
		}

		public ActionResult Profile(ServiceProfileUpdateViewModel viewModel) {

			if (!cHelper.IsServiceProvider)
				return RedirectToAction("Dashboard", "Account");
			if (viewModel == null)
				viewModel = new ServiceProfileUpdateViewModel();
			return View(viewModel);
		}

		public ActionResult UpdateServiceDetails(ServiceProfileUpdateViewModel viewModel,HttpPostedFileBase  file) {

			if (!cHelper.IsServiceProvider)
				return RedirectToAction("Dashboard", "Account");
			try
			{
				if (Request.Files.Count > 0)
				{

					if (file != null && file.ContentLength > 0)
					{
						var fileName = Path.GetFileName(file.FileName);
						var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
						file.SaveAs(path);
						viewModel.ServiceProvider.CoverPicture = path;
					}
				}
				else
				{
					if (file == null)
						viewModel.ErrorMessage = "No file uploaded";
				}


				using (var unit = new cUnitOfWork(new AppDbContext()))
				{
					unit.ServiceProviderRepository.Update(viewModel.ServiceProvider);
					unit.SaveChanges();

				}

				viewModel.SuccessMessage = "Details updated successfully";
			}
			catch (Exception exception)
			{
				viewModel.ErrorMessage = exception.Message;
			}
			return RedirectToAction("Profile", viewModel);
		}
	}
}