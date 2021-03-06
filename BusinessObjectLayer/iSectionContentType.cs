﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer {
    public interface iSectionContentType {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        ICollection<iSectionContent> SectionContents { get; set; }
  }
}