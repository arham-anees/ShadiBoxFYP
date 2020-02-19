using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer;

namespace BusinessLogicLayer {
    public class cRole {
	    private int _Id;
	    private string _Name;
	    private string _Description;
	    private ICollection<cUser> _Users;

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

	    public virtual ICollection<cUser> Users
	    {
		    get => _Users;
		    set => _Users = value;
	    }
    }
}