using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using BusinessLogicLayer;

namespace Mapper {
  public class cSectionContentMapper :EntityTypeConfiguration<cSectionContent> {
	  public cSectionContentMapper()
	  {
		  this.ToTable("tSectionContents");
		  this.HasKey(x => x.Id);

			this.HasRequired(x => x.ContentType)
				.WithMany()
				.HasForeignKey(x => x.ContentTypeId)
				.WillCascadeOnDelete(false);
		}
    }
}