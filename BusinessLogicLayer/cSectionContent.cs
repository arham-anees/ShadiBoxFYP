using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer;

namespace BusinessLogicLayer {
    public class cSectionContent {
	    private int _Id;
	    private string _Content;
	    private cServiceProvider _ServiceProvider;
	    private cSectionContentType _ContentType;

	    public int Id
	    {
		    get => _Id;
		    set => _Id = value;
	    }

	    public string Content
	    {
		    get => _Content;
		    set => _Content = value;
	    }

	    public int ServiceProviderId { get; set; }
	    public virtual cServiceProvider ServiceProvider
	    {
		    get => _ServiceProvider;
		    set => _ServiceProvider = value;
	    }

	    public int ContentTypeId { get; set; }
	    public virtual cSectionContentType ContentType
	    {
		    get => _ContentType;
		    set => _ContentType = value;
	    }
    }
}