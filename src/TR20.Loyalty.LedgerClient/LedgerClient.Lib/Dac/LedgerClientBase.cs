using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class LedgerClientBase
    {
        protected Web3 web3;

        protected LedgerClientBase(string connectionString, string address)
        {
            KeyVaultClient kvClient = new KeyVaultClient();
            var privateKey = kvClient.ReadSecret(address).GetAwaiter().GetResult().Value.Trim();
            web3 = new Web3(new Account(privateKey), url: connectionString);
        }
    }
}
