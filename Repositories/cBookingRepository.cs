using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cBookingRepository :cRepository<cBooking>
	{
		private AppDbContext _Context;

		public DbSet Bookings
		{
			get { return _Context.Bookings; }
		}
		public cBookingRepository(AppDbContext context)
		{
			_Context = context;
		}

		public override IQueryable<cBooking> GetAll()
		{
			return _Context.Bookings;
		}

		public override cBooking Get(int id) {
			try {

				return GetAll().Where(x => x.Id == id).Single();
			}
			catch (Exception) {
				throw;
			}
		}

		public override cBooking Add(cBooking booking)
		{
			_Context.Bookings.Add(booking);
			return booking;
		}

		public override cBooking Update(cBooking booking) {
			_Context.Bookings.AddOrUpdate(booking);
			return booking;
		}

		public override cBooking Delete(cBooking booking) {
			_Context.Bookings.Remove(booking);
			return booking;
		}
	}
}
