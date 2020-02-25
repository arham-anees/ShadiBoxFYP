using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
 	public class cSectionContentTypeRepository
  {
	  private AppDbContext _Context;

	  public cSectionContentTypeRepository(AppDbContext context)
	  {
		  _Context = context;
	  }

	  public IQueryable<cSectionContentType> GetAll()
	  {
		  return _Context.SectionContentTypes;
	  }

	  public cSectionContentType Get(int id)
	  {
		  return GetAll().Where(x => x.Id == id).Single();
	  }
  }
}
