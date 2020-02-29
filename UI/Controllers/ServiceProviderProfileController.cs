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

		public ActionResult Profile(ServiceProfileUpdateViewModel viewModel)
		{
			if (viewModel == null)
				viewModel = new ServiceProfileUpdateViewModel();
			return View(viewModel);
		}

		public ActionResult UpdateServiceDetails(ServiceProfileUpdateViewModel viewModel,HttpPostedFileBase  file)
		{
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