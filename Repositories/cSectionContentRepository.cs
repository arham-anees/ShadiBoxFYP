using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cSectionContentRepository :cRepository<cSectionContent>
	{
		private AppDbContext _Context;

		public cSectionContentRepository(AppDbContext context)
		{
			_Context = context;
		}
		public override IQueryable<cSectionContent> GetAll()
		{
			return _Context.SectionContents;
		}

		public override cSectionContent Get(int id)
		{
			return GetAll().Where(x => x.Id == id).Single();
		}

		public override cSectionContent Add(cSectionContent t)
		{
			_Context.SectionContents.Add(t);
			return t;
		}

		public override cSectionContent Update(cSectionContent t) {
			_Context.SectionContents.AddOrUpdate(t);
			return t;
		}

		public override cSectionContent Delete(cSectionContent t) {
			_Context.SectionContents.Remove(t);
			return t;
		}
	}
}
