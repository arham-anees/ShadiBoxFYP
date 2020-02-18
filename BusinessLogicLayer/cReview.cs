using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer;

namespace BusinessLogicLayer {
    public class cReview :iReview{
	    private int _Id;
	    private iUser _User;
	    private iServiceProvider _ServiceProvider;
	    private int _StarCount;
	    private string _Message;
	    private DateTime _Date;

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

	    public int StarCount
	    {
		    get => _StarCount;
		    set => _StarCount = value;
	    }

	    public string Message
	    {
		    get => _Message;
		    set => _Message = value;
	    }

	    public DateTime Date
	    {
		    get => _Date;
		    set => _Date = value;
	    }
    }
}