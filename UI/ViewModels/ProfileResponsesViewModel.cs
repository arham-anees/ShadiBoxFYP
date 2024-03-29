﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using PersistenceLayer;
using Repositories;
using UI.Models;

namespace UI.ViewModels {
	public class ProfileResponsesViewModel
	{
		private cBookingResponseRepository _BookingResponseRepository;

		public ProfileResponsesViewModel()
		{
			_BookingResponseRepository=new cBookingResponseRepository(new AppDbContext());
		}

		public List<cBookingResponse> BookingResponses
		{
			get
			{
				return _BookingResponseRepository.GetAll().Where(x => x.BookingRequest.UserId == cHelper.CurrentUser.Id)
					.ToList();
			}
		}
	}
}