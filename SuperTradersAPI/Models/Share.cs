using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTradersAPI.Models
{
    public class Share
    {
        public int shareId { get; set; }
        public string shareSymbol { get; set; }
        public double shareTotal { get; set; }
        public double sharePrice { get; set; }
        public double shareAmount { get; set; }
    }
}
