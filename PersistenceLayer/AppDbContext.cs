using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using BusinessObjectLayer;
using Mapper;

namespace PersistenceLayer {
	public class AppDbContext :DbContext{

		#region DbSets

		public DbSet<cCity> Cities { get; set; }
		public DbSet<cFunctionTime> FunctionTimes  { get; set; }
		public DbSet<cRentType> RentTypes { get; set; }
		public DbSet<cRole> Roles { get; set; }
		public DbSet<cSectionContentType> SectionContentTypes { get; set; }
		public DbSet<cSectionHead> SectionHeads { get; set; }
		public DbSet<cServiceCategory> ServiceCategories { get; set; }
		public DbSet<cServiceType> ServiceTypes { get; set; }
		public DbSet<cUser> Users { get; set; }
		public DbSet<cServiceProvider> ServiceProviders { get; set; }
		public DbSet<cSectionContent> SectionContents { get; set; }
		public DbSet<cReview> Reviews { get; set; }
		public DbSet<cBooking> Bookings { get; set; }
		public DbSet<cBookingResponse> BookingsResponses { get; set; }
		public DbSet<cBookingRequest> BookingsRequests { get; set; }


		#endregion

		public AppDbContext():base("ShadiBoxDb")
		{
			
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations
				.Add(new cCityMapper())
				.Add(new cFunctionTimeMapper())
				.Add(new cServiceProviderMapper())
				.Add(new cUserMapper())
				.Add(new cRentTypeMapper())
				.Add(new cSectionContentMapper())
				.Add(new cReviewMapper())
				.Add(new cBookingMapper())
				.Add(new cBookingRequestMapper())
				.Add(new cBookingResponseMapper())
				.Add(new cRoleMapper())
				.Add(new cSectionContentTypeMapper())
				.Add(new cSectionHeadMapper())
				.Add(new cServiceCategoryMapper())
				.Add(new cServiceTypeMapper())
				;

			base.OnModelCreating(modelBuilder);
		}

		
	}
}
