using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.ViewModels;
using UnitOfWork;

namespace UI.Controllers {
	public class ProfileController : Controller {
		private AppDbContext _Context;
		private cServiceProviderRepository _ProviderRepository;
		private cProfileSectionRepository _ProfileSectionRepository;
		

		public ProfileController() {

			_Context = new AppDbContext();
			_ProviderRepository = new cServiceProviderRepository(_Context);
			_ProfileSectionRepository = new cProfileSectionRepository(_Context);
		}
		// GET: Profile
		public ActionResult Index(ProfileIndexViewModel indexViewModel) {
			int id = 4;//todo: replace this with proper id for service provider
			if (indexViewModel == null)
				indexViewModel = new ProfileIndexViewModel();
			
			indexViewModel._ServiceProvider = _ProviderRepository.Get(id);
			indexViewModel._ProfileSection = _ProfileSectionRepository
				.GetAll(indexViewModel._ServiceProvider.Id)
				.Include(x=>x.SectionContent)
				.Include(x=>x.SectionHead)
				.ToList();
			indexViewModel.ServiceProviderId = indexViewModel._ServiceProvider.Id;
			return View(indexViewModel);
		}

		[HttpPost]
		public ActionResult AddContent(ProfileIndexViewModel indexViewModel)
		{
			try
			{
				using (var unit = new cUnitOfWork(new AppDbContext()))
				{
					cSectionContent content = new cSectionContent();
					cProfileSection newSection = new cProfileSection();


					content.ContentTypeId = indexViewModel.NewContentTypeId;
					if (indexViewModel.NewPackageName!=null)//for package
					{
						content.ContentTypeId = 3;
					  newSection.SectionHeadId = 4;
						content.Content = indexViewModel.NewPackageName + "+-*-+" + indexViewModel.NewPackageRate;
					}
					else
					{
						content.Content = indexViewModel.NewContentBody;
						newSection.SectionHeadId = indexViewModel.NewContentHeadId;
					}

					content.ServiceProviderId = indexViewModel.ServiceProviderId;
					unit.SectionContentRepository.Add(content);

					newSection.SectionContent = content;
					newSection.ServiceProviderId = indexViewModel.ServiceProviderId;

					unit.ProfileSectionRepository.Add(newSection);
					unit.SaveChanges();

					indexViewModel.SuccessMessage = "Section added successfully";
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
				indexViewModel.ErrorMessage = exception.Message;
			}

			return RedirectToAction("Index", "Profile");
		}

	}
}