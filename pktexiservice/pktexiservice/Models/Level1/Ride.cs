using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pktexiservice.Models.Level1
{
    public class Ride
    {
        public int id { get; set; }
        public string PikupLocation { get; set; }
        public string DropLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Rating { get; set; }
        public int Fare { get; set; }
        public string Distance { get; set; }
        public string Offer { get; set; }
    }
}