using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer {
    public interface iCity {
        /// <summary>
        /// this is unique ID of city
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// this is name of city
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// this is description of city
        /// </summary>
        string Description { get; set; }
    }
}