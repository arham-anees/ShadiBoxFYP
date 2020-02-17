using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer {
    public interface iSectionContent {
        int Id { get; set; }
        string Content { get; set; }
        iServiceProvider ServiceProvider { get; set; }
        iSectionContentType ContentType { get; set; }
    }
}