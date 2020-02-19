using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cBookingRequestRepository :cRepository<cBookingRequest>
	{
		private AppDbContext _Context;

		public cBookingRequestRepository(AppDbContext context)
		{
			_Context = context;
		}

		public override IQueryable<cBookingRequest> GetAll()
		{
			return _Context.BookingsRequests;
		}

		public override cBookingRequest Get(int id)
		{
			return GetAll().Where(x => x.Id == id).Single();
		}

		public override cBookingRequest Add(cBookingRequest t)
		{
			_Context.BookingsRequests.Add(t);
			return t;
		}

		public override cBookingRequest Update(cBookingRequest t) {
			_Context.BookingsRequests.AddOrUpdate(t);
			return t;
		}

		public override cBookingRequest Delete(cBookingRequest t)
		{
			_Context.BookingsRequests.Remove(t);
			return t;
		}
	}
}
