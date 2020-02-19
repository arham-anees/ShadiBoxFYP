using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer;

namespace BusinessLogicLayer {
    public class cUser {
	    private int _Id;
	    private string _Name;
	    private string _Phone;
	    private string _Email;
	    private string _Username;
	    private string _Password;

	    public int Id
	    {
		    get => _Id;
		    set => _Id = value;
	    }

	    public string Name
	    {
		    get => _Name;
		    set => _Name = value;
	    }

	    public string Phone
	    {
		    get => _Phone;
		    set => _Phone = value;
	    }

	    public string Email
	    {
		    get => _Email;
		    set => _Email = value;
	    }

	    public string Username
	    {
		    get => _Username;
		    set => _Username = value;
	    }

	    public string Password
	    {
		    get => _Password;
		    set => _Password = value;
	    }
    }
}