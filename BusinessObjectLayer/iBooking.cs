using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer {
    public interface iBooking {
        int Id { get; set; }
        iUser User { get; set; }
        iServiceProvider ServiceProvider { get; set; }
        iFunctionTime FunctionTime { get; set; }
        DateTime Date { get; set; }
        DateTime BookingDate { get; set; }
    }
}