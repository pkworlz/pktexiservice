using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pktexiservice.Models.Level1
{
    public class Cab
    {
        public int id { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public int SeatCapacity { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public int Type { get; set; }
    }
}