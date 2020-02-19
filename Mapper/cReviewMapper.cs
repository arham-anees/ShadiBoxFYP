using System.Data.Entity.ModelConfiguration;
using BusinessLogicLayer;

namespace Mapper {
	public class cReviewMapper :EntityTypeConfiguration<cReview> {
	    public cReviewMapper()
	    {
		    this.ToTable("tReviews");
		    this.HasKey(x => x.Id);

			this.HasRequired(x => x.ServiceProvider)
				.WithMany()
				.HasForeignKey(x => x.ServiceProviderId)
				.WillCascadeOnDelete(false);
			this.HasRequired(x => x.User)
				.WithMany()
				.HasForeignKey(x => x.UserId)
				.WillCascadeOnDelete(false);
		}
    }
}