using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cReviewRepository :cRepository<cReview>
	{
		private AppDbContext _Context;

		public cReviewRepository(AppDbContext context)
		{
			_Context = context;
		}
		public override IQueryable<cReview> GetAll()
		{
			return _Context.Reviews;
		}

		public override cReview Get(int id)
		{
			return GetAll().Where(x => x.Id == id).Single();
		}

		public override cReview Add(cReview t)
		{
			_Context.Reviews.Add(t);
			return t;
		}

		public override cReview Update(cReview t)
		{
			_Context.Reviews.AddOrUpdate(t);
			return t;
		}

		public override cReview Delete(cReview t)
		{
			_Context.Reviews.Remove(t);
			return t;
		}
	}
}
