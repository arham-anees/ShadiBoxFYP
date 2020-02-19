using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using BusinessLogicLayer;
using BusinessObjectLayer;

namespace Mapper {
    public class cBookingMapper :EntityTypeConfiguration<cBooking> {
	    public cBookingMapper()
	    {
		    this.HasKey(x => x.Id);

		    this.HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
		    this.HasRequired(x => x.ServiceProvider).WithMany().HasForeignKey(x => x.ServiceProviderId).WillCascadeOnDelete(false);
		    this.HasRequired(x => x.BookingResponse).WithMany().HasForeignKey(x => x.BookingResponseId).WillCascadeOnDelete(false);
		    this.HasRequired(x => x.FunctionTime).WithMany().HasForeignKey(x => x.FunctionTimeId).WillCascadeOnDelete(false);
	    }
    }
}