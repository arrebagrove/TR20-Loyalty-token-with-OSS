using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class ERC20Base
    {
        protected Web3 web3;

        protected ERC20Base(string connectionString, string address)
        {
            KeyVaultClient kvClient = new KeyVaultClient();
            var privateKey = kvClient.ReadSecret(address).GetAwaiter().GetResult().Value;
            web3 = new Web3(new Account(privateKey), url: connectionString);
        }
    }
}
