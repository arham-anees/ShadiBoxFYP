using System.Data.Entity.ModelConfiguration;
using BusinessLogicLayer;

namespace Mapper {
  public class cServiceTypeMapper :EntityTypeConfiguration<cServiceType> {
	  public cServiceTypeMapper()
	  {
		  this.ToTable("tServiceTypes");
			this.HasKey(x => x.Id);
			this.HasIndex(x => x.Name)
				.IsUnique(true);

			this.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(20);
			this.Property(x => x.Description)
				.IsOptional()
				.HasMaxLength(100);

		}
	}
}