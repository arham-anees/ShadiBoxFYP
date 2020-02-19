using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using BusinessLogicLayer;
using BusinessObjectLayer;

namespace Mapper {
    public class cReviewMapper :EntityTypeConfiguration<cReview> {
	    public cReviewMapper()
	    {
		    this.ToTable("tReviews");
		    this.HasKey(x => x.Id);

		    //this.HasRequired(x => x.ServiceProvider).WithMany().HasForeignKey(x => x.ServiceProviderId);
		    //this.HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserId);
	    }
    }
}