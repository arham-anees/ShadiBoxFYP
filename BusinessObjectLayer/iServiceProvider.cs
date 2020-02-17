using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer {
    public interface iServiceProvider {
        int Id { get; set; }
    /// <summary>
    /// Name of service
    /// </summary>
    string Name { get; set; }
    /// <summary>
    /// Address of service
    /// </summary>
    string Address { get; set; }
    string CoverPicture { get; set; }
    string Email { get; set; }
    string Phone { get; set; }
    iRentType RentType { get; set; }
    double Rent { get; set; }
    iCity City { get; set; }
    iServiceType ServiceType { get; set; }
    DateTime DateAddedOn { get; set; }
    iUser AddedBy { get; set; }
    List<iServiceCategory> ServiceCategories { get; set; }
  }
}