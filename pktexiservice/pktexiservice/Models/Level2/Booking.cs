﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pktexiservice.Models.Level2
{
    public class Booking
    {
        public int id { get; set; }
        public String CustomerId { get; set; }
        public int RideId { get; set; }
    }
}