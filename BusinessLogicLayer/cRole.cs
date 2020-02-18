using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer;

namespace BusinessLogicLayer {
    public class cRole :iRole{
	    private int _Id;
	    private string _Name;
	    private string _Description;
	    private List<iUser> _Users;

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

	    public string Description
	    {
		    get => _Description;
		    set => _Description = value;
	    }

	    public List<iUser> Users
	    {
		    get => _Users;
		    set => _Users = value;
	    }
    }
}