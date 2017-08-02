using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pktexiservice.Models.Level2
{
    public class PaysFor
    {
        public int id { get; set; }
        public int PaymentId { get; set; }
        public String CustomerId { get; set; }
    }
}