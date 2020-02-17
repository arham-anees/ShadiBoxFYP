using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer {
    public interface iFunctionTime {
        /// <summary>
        /// this is unique id of user
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// this is name of function time
        /// </summary>
        string Name { get; set; }
    /// <summary>
    /// this is description of Function time
    /// </summary>
    string Description { get; set; }
  }
}