using System.Data.Entity.ModelConfiguration;
using BusinessLogicLayer;

namespace Mapper {
	public class cBookingResponseMapper :EntityTypeConfiguration<cBookingResponse> {
	    public cBookingResponseMapper()
	    {
		    this.ToTable("tBookingResponses");
		    this.HasKey(x => x.Id);

		    this.HasRequired(x => x.BookingRequest).WithMany().HasForeignKey(x => x.BookingRequestId).WillCascadeOnDelete(false);

	    }
    }
}