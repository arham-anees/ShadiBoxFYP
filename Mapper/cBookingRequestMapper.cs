using System.Data.Entity.ModelConfiguration;
using BusinessLogicLayer;

namespace Mapper {
	public class cBookingRequestMapper :EntityTypeConfiguration<cBookingRequest> {
	    public cBookingRequestMapper()
	    {
		    this.HasKey(x => x.Id);

		    this.HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
		    this.HasRequired(x => x.FunctionTime).WithMany().HasForeignKey(x => x.FunctionTimeId).WillCascadeOnDelete(false);
		    this.HasRequired(x => x.ServiceProvider).WithMany().HasForeignKey(x => x.ServiceProviderId).WillCascadeOnDelete(false);
	    }
    }
}