using System.Data.Entity.ModelConfiguration;
using BusinessLogicLayer;

namespace Mapper {
	public class cServiceProviderMapper : EntityTypeConfiguration<cServiceProvider> {
		public cServiceProviderMapper()
		{
			this.ToTable("tServiceProvider");
			this.HasKey(c => c.Id);

			this.Property(x => x.Name).IsRequired();
			this.Property(x => x.Phone).IsRequired();
			this.Property(x => x.Rent).IsRequired();
			this.Property(x => x.DateAddedOn).IsRequired().HasColumnType("datetime2");

			//this.HasRequired(x => x.City).WithMany().WillCascadeOnDelete(false);
			//this.HasRequired(x => x.RentType).WithRequiredPrincipal();
			//this.HasRequired(x => x.ServiceType).WithMany().HasForeignKey(x=>x.ServiceTypeId);
			//this.HasRequired(x => x.AddedBy).WithRequiredPrincipal();
		}
	}
}