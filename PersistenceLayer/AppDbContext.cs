using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using BusinessObjectLayer;
using Mapper;

namespace PersistenceLayer {
	public class AppDbContext :DbContext{

		#region DbSets

		public DbSet<cCity> Cities { get; set; }


		#endregion

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations
				.Add(new cCityMapper());

			base.OnModelCreating(modelBuilder);
		}
	}
}
