using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	 public class cRentTypeRepository {
		 private AppDbContext _AppDbContext;

		 public cRentTypeRepository(AppDbContext appDbContext) {
			 _AppDbContext = appDbContext;
		 }
		 public IQueryable<cRentType> GetAll() {
			 return _AppDbContext.RentTypes;
		 }
		 public cRentType Get(int id) => GetAll().Where(x => x.Id == id).Single();
	 }
}
