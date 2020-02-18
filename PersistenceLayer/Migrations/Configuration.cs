﻿using BusinessLogicLayer;

namespace PersistenceLayer.Migrations {
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<PersistenceLayer.AppDbContext> {
		public Configuration() {
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(PersistenceLayer.AppDbContext context) {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method
			//  to avoid creating duplicate seed data.

			#region Function Times

			context.FunctionTimes.AddOrUpdate(x => x.Id,
							new cFunctionTime() { Id = 1, Name = "Morning Time" },
							new cFunctionTime() { Id = 2, Name = "Evening Time" }
						);
			#endregion

			#region Cities

			context.Cities.AddOrUpdate(x => x.Id,
				new cCity() { Id = 1, Name = "Mardan" },
				new cCity() { Id = 2, Name = "Peshawar" },
				new cCity() { Id = 3, Name = "Islamabad" },
				new cCity() { Id = 4, Name = "Lahore" }
				);

			#endregion

			#region Rent Types

			context.RentTypes.AddOrUpdate(x=>x.Id,
				new cRentType(){Id = 1, Name = "Per Head"},
				new cRentType(){Id = 2, Name = "Per Day"}
				);

			#endregion

			#region Role

			context.Roles.AddOrUpdate(x=>x.Id,
				new cRole(){Id = 1,Name = "Customer"},
				new cRole(){Id = 2,Name = "Admin"},
				new cRole(){Id = 3,Name = "ServiceProvider"}
				);

			#endregion

			#region Content Type

			context.SectionContentTypes.AddOrUpdate(x=>x.Id,
				new cSectionContentType(){Id = 1,Name = "Features"},
				new cSectionContentType(){Id = 2,Name = "Images"},
				new cSectionContentType(){Id = 3,Name = "Packages"},
				new cSectionContentType(){Id = 4,Name = "Text"},
				new cSectionContentType(){Id = 5,Name = "Reviews"}
				);

			#endregion

			#region Section Head

			context.SectionHeads.AddOrUpdate(x=>x.Id,
				new cSectionHead(){Id = 1,Name = "Services"},
				new cSectionHead(){Id = 2,Name = "Reviews"}
				);

			#endregion

			#region Service Categories

			context.ServiceCategories.AddOrUpdate(x=>x.Id,
				new cServiceCategory(){Id = 1,Name = "Venues"},
				new cServiceCategory(){Id = 2,Name = "Photographers"},
				new cServiceCategory(){Id = 3,Name = "Caterers"},
				new cServiceCategory(){Id = 4,Name = "Car Rentals"},
				new cServiceCategory(){Id = 5,Name = "Decorators"},
				new cServiceCategory(){Id = 6,Name = "Event Managers"},
				new cServiceCategory(){Id = 7,Name = "Salons"},
				new cServiceCategory(){Id = 8,Name = "Cakes"},
				new cServiceCategory(){Id = 9,Name = "Invitations"});

			#endregion

			#region Service Type

			context.ServiceTypes.AddOrUpdate(x => x.Id,
				new cServiceType() {Id = 1, Name = "Professional"},
				new cServiceType() {Id = 2, Name = "Freelancing"}
			);

			#endregion

			#region USERS

			context.Users.AddOrUpdate(x=>x.Id,
				new cUser(){Id = 1,Username = "as",Password = "as",Email = "as@as.as",Name = "As",Phone = "as"});

			#endregion
		}
	}
}
