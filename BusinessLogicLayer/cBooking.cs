using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer;

namespace BusinessLogicLayer {
    public class cBooking  {
	    private int _Id;
	    private cUser _User;
	    private cServiceProvider _ServiceProvider;
	    private cFunctionTime _FunctionTime;
	    private DateTime _Date;
	    private DateTime _BookingDate;
	    private cBookingResponse _BookingResponse;

	    public int Id
	    {
		    get => _Id;
		    set => _Id = value;
	    }

	    public int UserId { get; set; }
	    public virtual cUser User
	    {
		    get => _User;
		    set => _User = value;
	    }

	    public int ServiceProviderId { get; set; }
	    public virtual cServiceProvider ServiceProvider
	    {
		    get => _ServiceProvider;
		    set => _ServiceProvider = value;
	    }

	    public int FunctionTimeId { get; set; }
	    public virtual cFunctionTime FunctionTime
	    {
		    get => _FunctionTime;
		    set => _FunctionTime = value;
	    }

	    public int BookingResponseId { get; set; }
	    public virtual cBookingResponse BookingResponse
	    {
		    get => _BookingResponse;
		    set => _BookingResponse = value;
	    }

	    public DateTime Date
	    {
		    get => _Date;
		    set => _Date = value;
	    }

	    public DateTime BookingDate
	    {
		    get => _BookingDate;
		    set => _BookingDate = value;
	    }
    }
}