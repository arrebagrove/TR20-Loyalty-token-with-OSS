using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenWallet
{
    public class TokenInfo
    {
        public string TokenName { get; set; }
        public string TokenSymbol { get; set; }
        public double TotalAmountToken { get; set; }
        public string TokenContractAddress { get; set; }
    }

    public class AccountInfo
    {
        public string AccountName { get; set; }
        public string AccountPubAddress { get; set; }
    }
}
