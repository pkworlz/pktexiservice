using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pktexiservice.Models.dynamic
{
    public class RideRequest
    {
        public int id { get; set; }
        public String CustomerId { get; set; }
        public double PikupLat { get; set; }
        public double PikupLng { get; set; }
        public double? DropLat { get; set; }
        public double? DropLng { get; set; }
        public DateTime RideRequestTime { get; set; }

    }
}