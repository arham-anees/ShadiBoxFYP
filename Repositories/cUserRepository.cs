using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
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
			if (!this.IsUsernameUnique(user.Username))
				throw new InvalidDataException("Username already exists");
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

		public cUser Authenticate(string username, string password)
		{
			return GetAll().Where(x => x.Username == username && x.Password == password).FirstOrDefault();
		}

		public List<cUser> GetAdminList()
		{
			return GetAll().Where(x=>x.RoleId==2).ToList();
		}

		private bool IsUsernameUnique(string username)
		{
			return !_Context.Users.Where(x => x.Username == username).Any();
		}
	}
}
