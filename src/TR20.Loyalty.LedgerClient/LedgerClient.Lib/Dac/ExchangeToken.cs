using System;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.RPC.Eth.DTOs;
using System.Threading.Tasks;
using System.Numerics;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class ExchangeToken : LedgerClientBase
    {
        public ExchangeToken(string connectionString, string address) : base(connectionString, address)
        {
        }

        public async Task<TransactionReceipt> DeployContractAsync()
        {
            return await Contracts.ExchangeToken.ExchangeTokenService.DeployContractAndWaitForReceiptAsync(web3, new Contracts.ExchangeToken.ExchangeTokenDeployment());
        }

        public async Task<TransactionReceipt> ExchangeTokens(
            string contractAddress,
            string exchangeMarketAddress,
            string txOwner,
            string sourceTokenAddress,
            string targetTokenAddress,
            BigInteger exchangeRate,
            BigInteger tokenAmount)
        {
            var exchangeTokenService = new Contracts.ExchangeToken.ExchangeTokenService(web3, contractAddress);
            return await exchangeTokenService.ExchangeRequestAndWaitForReceiptAsync(
                txOwner,
                exchangeMarketAddress,
                sourceTokenAddress,
                targetTokenAddress,
                exchangeRate,
                tokenAmount
                );
        }
    }
}
