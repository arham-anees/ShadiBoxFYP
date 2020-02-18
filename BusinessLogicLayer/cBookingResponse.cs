using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer;

namespace BusinessLogicLayer {
    public class cBookingResponse :iBookingReponse{
	    private int _Id;
	    private iBookingRequest _BookingRequest;
	    private DateTime _Date;
	    private bool _IsAccepted;
	    private string _Message;

	    public int Id
	    {
		    get => _Id;
		    set => _Id = value;
	    }

	    public iBookingRequest BookingRequest
	    {
		    get => _BookingRequest;
		    set => _BookingRequest = value;
	    }

	    public DateTime Date
	    {
		    get => _Date;
		    set => _Date = value;
	    }

	    public bool IsAccepted
	    {
		    get => _IsAccepted;
		    set => _IsAccepted = value;
	    }

	    public string Message
	    {
		    get => _Message;
		    set => _Message = value;
	    }
    }
}