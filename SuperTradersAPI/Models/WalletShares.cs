using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTradersAPI.Models
{
    public class WalletShares
    {
        public int walletSharesId { get; set; }
        public string shareSymbol{ get; set; }
        public double shareAmount { get; set; }
    }
}
