using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using BusinessLogicLayer;
using BusinessObjectLayer;

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