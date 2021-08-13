using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTradersAPI.Models
{
    public class Log
    {
        public int logId { get; set; }
        public string logTxt { get; set; }
        public int userId { get; set; }
    }
}
