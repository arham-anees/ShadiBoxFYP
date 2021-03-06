﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;

namespace UI.ViewModels {
	public class SignUpViewModel {
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public string ErrorMessage { get; set; }
	}
}