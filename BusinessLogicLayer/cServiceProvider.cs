using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer;

namespace BusinessLogicLayer {
    public class cServiceProvider :iServiceProvider{
	    private int _Id;
	    private string _Name;
	    private string _Address;
	    private string _CoverPicture;
	    private string _Email;
	    private string _Phone;
	    private iRentType _RentType;
	    private double _Rent;
	    private iCity _City;
	    private iServiceType _ServiceType;
	    private DateTime _DateAddedOn;
	    private iUser _AddedBy;
	    private List<iServiceCategory> _ServiceCategories;

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

	    public string Address
	    {
		    get => _Address;
		    set => _Address = value;
	    }

	    public string CoverPicture
	    {
		    get => _CoverPicture;
		    set => _CoverPicture = value;
	    }

	    public string Email
	    {
		    get => _Email;
		    set => _Email = value;
	    }

	    public string Phone
	    {
		    get => _Phone;
		    set => _Phone = value;
	    }

	    public iRentType RentType
	    {
		    get => _RentType;
		    set => _RentType = value;
	    }

	    public double Rent
	    {
		    get => _Rent;
		    set => _Rent = value;
	    }

	    public iCity City
	    {
		    get => _City;
		    set => _City = value;
	    }

	    public iServiceType ServiceType
	    {
		    get => _ServiceType;
		    set => _ServiceType = value;
	    }

	    public DateTime DateAddedOn
	    {
		    get => _DateAddedOn;
		    set => _DateAddedOn = value;
	    }

	    public iUser AddedBy
	    {
		    get => _AddedBy;
		    set => _AddedBy = value;
	    }

	    public List<iServiceCategory> ServiceCategories
	    {
		    get => _ServiceCategories;
		    set => _ServiceCategories = value;
	    }
    }
}