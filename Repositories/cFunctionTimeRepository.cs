using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cFunctionTimeRepository
	{
		private AppDbContext _Context;

		public cFunctionTimeRepository(AppDbContext context)
		{
			_Context = context;
		}

		public IQueryable<cFunctionTime> GetAll()
		{
			return _Context.FunctionTimes;
		}

		public cFunctionTime Get(int id)
		{
			return GetAll().Where(x => x.Id == id).Single();
		}
	}
}
