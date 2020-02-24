using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogicLayer {
	public class cServiceProvider {
	    private int _Id;
	    private string _Name;
	    private string _Address;
	    private string _CoverPicture;
	    private string _Email;
	    private string _Phone;
	    private cRentType _RentType;
	    private double _Rent;
	    private cCity _City;
	    private cServiceType _ServiceType;
	    private DateTime _DateAddedOn;
	    private cUser _AddedBy;
	    private cServiceCategory _ServiceCategory;

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

	    public int RentTypeId { get; set; }
			[ForeignKey("RentTypeId")]
	    public virtual cRentType RentType
	    {
		    get => _RentType;
		    set => _RentType = value;
	    }

	    public double Rent
	    {
		    get => _Rent;
		    set => _Rent = value;
	    }

	    public int CityId { get; set; }
	    public virtual cCity City
	    {
		    get => _City;
		    set => _City = value;
	    }

	    public int ServiceTypeId { get; set; }
	    public virtual cServiceType ServiceType
	    {
		    get => _ServiceType;
		    set => _ServiceType = value;
	    }

	    public DateTime DateAddedOn
	    {
		    get => _DateAddedOn;
		    set => _DateAddedOn = value;
	    }

	    public int UserAddedById { get; set; }
	    public virtual cUser AddedBy
	    {
		    get => _AddedBy;
		    set => _AddedBy = value;
	    }

	    public virtual int ServiceCategoryId { get; set; }
	    public virtual cServiceCategory ServiceCategory { get; set; }
	}
}