using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer {
    public interface iBookingRequest {
        int Id { get; set; }
        iUser User { get; set; }
        iServiceProvider ServiceProvider { get; set; }
        DateTime Date { get; set; }
        DateTime BookingDate { get; set; }
        int NumberOfGuests { get; set; }
        iFunctionTime FunctionTime { get; set; }
        /// <summary>
        /// this is any personal message from client
        /// </summary>
        string Message { get; set; }
    }
}