﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer {
    public interface iServiceCategory {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        List<iServiceProvider> ServiceProviders { get; set; }
    }
}