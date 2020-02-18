﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectLayer;

namespace BusinessLogicLayer {
    public class cSectionContent :iSectionContent{
	    private int _Id;
	    private string _Content;
	    private iServiceProvider _ServiceProvider;
	    private iSectionContentType _ContentType;

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

	    public iServiceProvider ServiceProvider
	    {
		    get => _ServiceProvider;
		    set => _ServiceProvider = value;
	    }

	    public iSectionContentType ContentType
	    {
		    get => _ContentType;
		    set => _ContentType = value;
	    }
    }
}