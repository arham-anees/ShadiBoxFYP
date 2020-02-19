using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using PersistenceLayer;

namespace Repositories {
	public class cUserRepository :cRepository<cUser>
	{
		private AppDbContext _Context;
		public cUserRepository(AppDbContext context)
		{
			_Context = context;
		}
		public override IQueryable<cUser> GetAll()
		{
			return _Context.Users;
		}

		public override cUser Get(int id)
		{
			return GetAll().Where(x => x.Id == id).Single();
		}

		public override cUser Add(cUser user)
		{
			_Context.Users.Add(user);
			return user;
		}

		public override cUser Update(cUser user)
		{
			_Context.Users.AddOrUpdate(user);
			return user;
		}

		public override cUser Delete(cUser user)
		{
			_Context.Users.Remove(user);
			return user;
		}
	}
}
