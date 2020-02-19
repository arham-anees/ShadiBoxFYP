using System.Data.Entity.ModelConfiguration;
using BusinessLogicLayer;

namespace Mapper {
	public class cProfileSectionMapper :EntityTypeConfiguration<cProfileSection> {
	    public cProfileSectionMapper()
	    {
		    this.ToTable("tProfileSections");
		    this.HasKey(x => x.Id);

		    this.HasRequired(x => x.SectionContent)
			    .WithMany()
			    .HasForeignKey(x => x.SectionContentId)
			    .WillCascadeOnDelete(false);
			this.HasRequired(x => x.SectionHead)
				.WithMany()
				.HasForeignKey(x => x.SectionHeadId)
				.WillCascadeOnDelete(false);
			this.HasRequired(x => x.ServiceProvider)
			    .WithMany()
			    .HasForeignKey(x => x.ServiceProviderId)
			    .WillCascadeOnDelete(false);

	    }
    }
}