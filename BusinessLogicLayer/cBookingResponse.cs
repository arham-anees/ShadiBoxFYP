using System;

namespace BusinessLogicLayer {
	public class cBookingResponse {
	    private int _Id;
	    private cBookingRequest _BookingRequest;
	    private DateTime _Date;
	    private bool _IsAccepted;
	    private string _Message;

	    public int Id
	    {
		    get => _Id;
		    set => _Id = value;
	    }

	    public int BookingRequestId { get; set; }
	    public virtual cBookingRequest BookingRequest
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