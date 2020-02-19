using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories {
	public abstract class cRepository<T>
	{
		public abstract IQueryable<T> GetAll();
		public abstract T Get(int id);
		public abstract T Add(T t);
		public abstract T Update(T t);
		public abstract T Delete(T t);
	}
}
