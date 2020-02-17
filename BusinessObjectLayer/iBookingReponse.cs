using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer {
    public interface iBookingReponse {
        int Id { get; set; }
        iBookingRequest BookingRequest { get; set; }
        DateTime Date { get; set; }
        bool IsAccepted { get; set; }
        /// <summary>
        /// Any personal message from service provider to client
        /// </summary>
        string Message { get; set; }
    }
}