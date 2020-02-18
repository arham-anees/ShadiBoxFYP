using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using BusinessLogicLayer;

namespace Mapper {
  public class cSectionContentMapper :EntityTypeConfiguration<cSectionContent> {
	  public cSectionContentMapper()
	  {
		  this.HasKey(x => x.Id);

		  //this.HasRequired(x => x.ContentType)
			 // .WithMany(x=>(ICollection<cSectionContent>) x.SectionContents)
			 // .HasForeignKey(x=>x.ContentTypeId);
	  }
    }
}