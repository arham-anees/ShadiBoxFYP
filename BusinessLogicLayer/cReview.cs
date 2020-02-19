using System;

namespace BusinessLogicLayer {
	public class cReview {
	    private int _Id;
	    private cUser _User;
	    private cServiceProvider _ServiceProvider;
	    private int _StarCount;
	    private string _Message;
	    private DateTime _Date;

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