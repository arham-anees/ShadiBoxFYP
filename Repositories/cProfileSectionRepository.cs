using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cProfileSectionRepository :cRepository<cProfileSection>
	{
		private AppDbContext _Context;

		public cProfileSectionRepository(AppDbContext context)
		{
			_Context = context;
		}
		public override IQueryable<cProfileSection> GetAll()
		{
			return _Context.ProfileSections;
		}

		public override cProfileSection Get(int id)
		{
			return GetAll().Where(x => x.Id == id).Single();
		}

		public override cProfileSection Add(cProfileSection t)
		{
			_Context.ProfileSections.Add(t);
			return t;
		}

		public override cProfileSection Update(cProfileSection t) {
			_Context.ProfileSections.AddOrUpdate(t);
			return t;
		}

		public override cProfileSection Delete(cProfileSection t) {
			_Context.ProfileSections.Remove(t);
			return t;
		}
	}
}
