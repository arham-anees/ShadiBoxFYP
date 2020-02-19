using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cCityRepository :cRepository<cCity>
	{
		private AppDbContext _Context;

		public cCityRepository(AppDbContext context)
		{
			_Context = context;
		}
		public override IQueryable<cCity> GetAll()
		{
			return _Context.Cities;
		}

		public override cCity Get(int id)
		{
			return GetAll().Where(x => x.Id == id).Single();
		}

		public override cCity Add(cCity t)
		{
			_Context.Cities.Add(t);
			return t;
		}

		public override cCity Update(cCity t) {
			_Context.Cities.AddOrUpdate(t);
			return t;
		}

		public override cCity Delete(cCity t) {
			_Context.Cities.Remove(t);
			return t;
		}
	}
}
