using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using BusinessLogicLayer;
using BusinessObjectLayer;

namespace Mapper {
    public class cFunctionTimeMapper :EntityTypeConfiguration<cFunctionTime> {
	    public cFunctionTimeMapper()
	    {
		    this.ToTable("tFunctionTimes");
		    this.HasKey(x => x.Id);
		    this.HasIndex(x => x.Name);

		    this.Property(x => x.Name)
			    .IsRequired()
			    .HasMaxLength(20);
		    this.Property(x => x.Description)
			    .IsOptional()
			    .HasMaxLength(100);
	    }
    }
}