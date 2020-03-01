using BusinessLogicLayer;

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

			//context.Cities.AddOrUpdate(x => x.Id,
			//	new cCity() { Id = 1, Name = "Mardan" },
			//	new cCity() { Id = 2, Name = "Peshawar" },
			//	new cCity() { Id = 3, Name = "Islamabad" },
			//	new cCity() { Id = 4, Name = "Lahore" }
			//	);

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
				new cRole(){Id = 2,Name = "Admin"}
				);

			#endregion

			#region Content Type

			context.SectionContentTypes.AddOrUpdate(x=>x.Id,
				new cSectionContentType(){Id = 1,Name = "Text"},
				new cSectionContentType(){Id = 2,Name = "Images"},
				new cSectionContentType(){Id = 3,Name = "Packages"}
				);

			#endregion

			#region Service Categories

			context.ServiceCategories.AddOrUpdate(x => x.Id,
				new cServiceCategory() { Id = 1, Name = "Venues", Picture = "/Content/userassets/categories/images/794ca555be9dbed4c650c2f281866e4e.jpg" },
				new cServiceCategory() { Id = 2, Name = "Photographers", Picture = "/Content/userassets/categories/images/6c2f26fdc23505c38030c80a87aa04e4.jpg" },
				new cServiceCategory() { Id = 3, Name = "Caterers", Picture = "/Content/userassets/categories/images/fb644ebc3a344e4682100957ce2a5d97.jpg" },
				new cServiceCategory() { Id = 4, Name = "Car Rentals", Picture = "/Content/userassets/categories/images/7b3d16062f9a6e82c070d86b9449cd09.jpg" },
				new cServiceCategory() { Id = 5, Name = "Decorators", Picture = "/Content/userassets/categories/images/222d84340c8e0de708ca6d1ff2fb6099.jpg" },
				new cServiceCategory() { Id = 6, Name = "Event Managers", Picture = "/Content/userassets/categories/images/201c24125ee6aa852c92ee02bf1a6205.jpg" },
				new cServiceCategory() { Id = 7, Name = "Salons", Picture = "/Content/userassets/categories/images/ebea4e326afcc80bca89afa065ff5667.jpg" },
				new cServiceCategory() { Id = 8, Name = "Cakes", Picture = "/Content/userassets/categories/images/bf8d21a64ffc843d0cf369bccc794352.jpg" },
				new cServiceCategory() { Id = 9, Name = "Invitations", Picture = "/Content/userassets/categories/images/058a6ae2a140935753924ef2d008c16e.jpg" });

			#endregion

			#region Service Type

			context.ServiceTypes.AddOrUpdate(x => x.Id,
				new cServiceType() {Id = 1, Name = "Professional"},
				new cServiceType() {Id = 2, Name = "Freelancing"}
			);

			#endregion

			#region USERS

			context.Users.AddOrUpdate(x => x.Id,
				new cUser() { Id = 1, Username = "as", Password = "as", Email = "as@as.as", Name = "As", Phone = "as", RoleId = 1 });

			#endregion

			#region Section Head

			context.SectionHeads.AddOrUpdate(x => x.Id,
				new cSectionHead() { Id = 1, Name = "Services" },
				new cSectionHead() { Id = 2, Name = "Reviews" }
			);

			#endregion
		}
	}
}
