using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pktexiservice.Models.Level2
{
    public class Owns
    {
        public int id { get; set; }
        public int DriverId { get; set; }
        public int CabId { get; set; }
        public bool isActive { get; set; }
    }
}