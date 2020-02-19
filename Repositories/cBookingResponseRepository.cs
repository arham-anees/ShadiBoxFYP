using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cBookingResponseRepository :cRepository<cBookingResponse>
	{
		private AppDbContext _Context;

		public cBookingResponseRepository(AppDbContext context)
		{
			_Context = context;
		}
		public override IQueryable<cBookingResponse> GetAll()
		{
			return _Context.BookingsResponses;
		}

		public override cBookingResponse Get(int id) {
			try {

				return GetAll().Where(x => x.Id == id).Single();
			}
			catch (Exception) {

				throw;
			}
		}

		public override cBookingResponse Add(cBookingResponse t)
		{
			_Context.BookingsResponses.Add(t);
			return t;
		}

		public override cBookingResponse Update(cBookingResponse t) {
			_Context.BookingsResponses.AddOrUpdate(t);
			return t;
		}

		public override cBookingResponse Delete(cBookingResponse t) {
			_Context.BookingsResponses.Remove(t);
			return t;
		}
	}
}
