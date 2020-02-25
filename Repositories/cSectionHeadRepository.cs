using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cSectionHeadRepository
	{
		private AppDbContext _Context;

		public cSectionHeadRepository(AppDbContext context)
		{
			_Context = context;
		}

		public IQueryable<cSectionHead> GetAll()
		{
			return _Context.SectionHeads;
		}

		public cSectionHead Get(int id)
		{
			return GetAll().Where(x => x.Id == id).Single();
		}
	}
}
