using System.Data.Entity.ModelConfiguration;
using BusinessLogicLayer;

namespace Mapper {
	public class cServiceProviderMapper : EntityTypeConfiguration<cServiceProvider> {
		public cServiceProviderMapper()
		{
			this.ToTable("tServiceProviders");
			this.HasKey(c => c.Id);

			this.Property(x => x.Name).IsRequired();
			this.Property(x => x.Phone).IsRequired();
			this.Property(x => x.Rent).IsRequired();
			this.Property(x => x.DateAddedOn).IsRequired().HasColumnType("datetime2");

			//required
			this.HasRequired(x => x.City).WithMany().HasForeignKey(x=>x.CityId).WillCascadeOnDelete(false);
			this.HasRequired(x => x.ServiceCategory).WithMany().HasForeignKey(x => x.ServiceCategoryId).WillCascadeOnDelete(false);
			this.HasRequired(x => x.AddedBy).WithMany().HasForeignKey(x=>x.UserAddedById).WillCascadeOnDelete(false);

			//optional
			this.HasRequired(x => x.RentType).WithMany().HasForeignKey(x => x.RentTypeId).WillCascadeOnDelete(false);
			this.HasRequired(x => x.ServiceType).WithMany().HasForeignKey(x => x.ServiceTypeId).WillCascadeOnDelete(false);

		}
	}
}