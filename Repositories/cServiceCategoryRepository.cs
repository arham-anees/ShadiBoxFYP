using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cServiceCategoryRepository :cRepository<cServiceCategory> {
		private AppDbContext _Context;

		public cServiceCategoryRepository(AppDbContext context)
		{
			_Context = context;
		}
		public override IQueryable<cServiceCategory> GetAll()
		{
			return _Context.ServiceCategories;
		}

		public override cServiceCategory Get(int id)
		{
			return GetAll().Where(x => x.Id == id).Single();
		}

		public override cServiceCategory Add(cServiceCategory t)
		{
			_Context.ServiceCategories.Add(t);
			return t;
		}

		public override cServiceCategory Update(cServiceCategory t) {
			_Context.ServiceCategories.AddOrUpdate(t);
			return t;
		}

		public override cServiceCategory Delete(cServiceCategory t) {
			_Context.ServiceCategories.Remove(t);
			return t;
		}
	}
}
