using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cServiceTypeRepository
	{
		private AppDbContext _AppDbContext;

		public cServiceTypeRepository(AppDbContext appDbContext)
		{
			_AppDbContext = appDbContext;
		}
		public IQueryable<cServiceType> GetAll()
		{
			return _AppDbContext.ServiceTypes;
		}
		public cServiceType Get(int id)
		{
			return GetAll().Where(x => x.Id == id).Single();
		}
}
}
