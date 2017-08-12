using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pktexiservice.Models.dynamic
{
    public class DriverStatus
    {
        public int id { get; set; }
        public string DriverId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public bool isOnline { get; set; }
        public DateTime lastSeen { get; set; }

    }
}