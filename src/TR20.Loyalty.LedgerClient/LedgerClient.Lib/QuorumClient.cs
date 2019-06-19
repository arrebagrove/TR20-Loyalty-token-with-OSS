using System;
using TR20.Loyalty.LedgerClient.Contracts.EIP20;
using TR20.Loyalty.LedgerClient.Contracts.EIP20Factory;
using Nethereum.Web3;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class QuorumClient
    {

        EIP20FactoryService erc20FactorySvc;
        EIP20Service erc20Svc;
        Web3 web3;

        public QuorumClient(string connectionString)
        {
            web3 = new Web3();
        }


        public string SetupTokenFactory()
        {

        }
    }
}
