﻿namespace BusinessLogicLayer {
	public class cUser {
	    private int _Id;
	    private string _Name;
	    private string _Phone;
	    private string _Email;
	    private string _Username;
	    private string _Password;
	    private bool _IsAdmin = false;

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

	    public int RoleId { get; set; } 
	    public virtual cRole Role { get; set; }

	}
}