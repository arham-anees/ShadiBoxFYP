using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cServiceProviderRepository :cRepository<cServiceProvider>
	{
		private AppDbContext _Context;

		public cServiceProviderRepository(AppDbContext context)
		{
			_Context = context;
		}

		public override IQueryable<cServiceProvider> GetAll()
		{
			return _Context.ServiceProviders;
		}

		public override cServiceProvider Get(int id)
		{
			return GetAll().Where(x => x.Id == id).Single();
		}

		public override cServiceProvider Add(cServiceProvider t)
		{
			_Context.ServiceProviders.Add(t);
			return t;
		}

		public override cServiceProvider Update(cServiceProvider t) {
			_Context.ServiceProviders.AddOrUpdate(t);
			return t;
		}

		public override cServiceProvider Delete(cServiceProvider t) {
			_Context.ServiceProviders.Remove(t);
			return t;
		}
	}
}
