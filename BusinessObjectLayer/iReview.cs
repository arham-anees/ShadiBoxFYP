using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer {
    public interface iReview {
        int Id { get; set; }
        iUser User { get; set; }
        iServiceProvider ServiceProvider { get; set; }
        int StarCount { get; set; }
        string Message { get; set; }
        DateTime Date { get; set; }
    }
}