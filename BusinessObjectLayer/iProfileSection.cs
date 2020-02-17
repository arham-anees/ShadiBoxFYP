using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer {
    public interface iProfileSection {
        int Id { get; set; }
        iServiceProvider ServiceProvider { get; set; }
        iSectionHead SectionHead { get; set; }
        iSectionContent SectionContent { get; set; }
    }
}