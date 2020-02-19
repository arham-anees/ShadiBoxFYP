using System.Data.Entity.ModelConfiguration;
using BusinessLogicLayer;

namespace Mapper {
  public class cSectionHeadMapper :EntityTypeConfiguration<cSectionHead> {
	  public cSectionHeadMapper()
	  {
		  this.ToTable("tSectionHeads");
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