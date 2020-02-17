using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer {
    public interface iUser {
    int Id { get; set; }
    string Name { get; set; }
    string Phone { get; set; }
    string Email { get; set; }
    string Username { get; set; }
    string Password { get; set; }
  }
}