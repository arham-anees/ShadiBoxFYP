using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer;

namespace BusinessLogicLayer {
    public class cBooking :iBooking {
	    private int _Id;
	    private iUser _User;
	    private iServiceProvider _ServiceProvider;
	    private iFunctionTime _FunctionTime;
	    private DateTime _Date;
	    private DateTime _BookingDate;

	    public int Id
	    {
		    get => _Id;
		    set => _Id = value;
	    }

	    public iUser User
	    {
		    get => _User;
		    set => _User = value;
	    }

	    public iServiceProvider ServiceProvider
	    {
		    get => _ServiceProvider;
		    set => _ServiceProvider = value;
	    }

	    public iFunctionTime FunctionTime
	    {
		    get => _FunctionTime;
		    set => _FunctionTime = value;
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