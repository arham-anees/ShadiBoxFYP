using System.Collections.Generic;

namespace BusinessLogicLayer {
	public class cServiceCategory {
	    private int _Id;
	    private string _Name;
	    private string _Description;
	    private ICollection<cServiceProvider> _ServiceProviders;
	    private string _Picture;

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

	    public string Picture
	    {
		    get => _Picture;
		    set => _Picture = value;
	    }

	    public ICollection<cServiceProvider> ServiceProviders
	    {
		    get => _ServiceProviders;
		    set => _ServiceProviders = value;
	    }
    }
}