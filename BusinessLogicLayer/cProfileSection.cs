using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer;

namespace BusinessLogicLayer {
    public class cProfileSection :iProfileSection{
	    private int _Id;
	    private iServiceProvider _ServiceProvider;
	    private iSectionHead _SectionHead;
	    private iSectionContent _SectionContent;

	    public int Id
	    {
		    get => _Id;
		    set => _Id = value;
	    }

	    public iServiceProvider ServiceProvider
	    {
		    get => _ServiceProvider;
		    set => _ServiceProvider = value;
	    }

	    public iSectionHead SectionHead
	    {
		    get => _SectionHead;
		    set => _SectionHead = value;
	    }

	    public iSectionContent SectionContent
	    {
		    get => _SectionContent;
		    set => _SectionContent = value;
	    }
    }
}