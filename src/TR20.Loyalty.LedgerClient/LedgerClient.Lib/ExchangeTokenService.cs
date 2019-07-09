using System.Text;
using System.Threading.Tasks;
using OffChain = TR20.Loyalty.OffChainRepository.Mongo.Model;
using Indexer = TR20.Loyalty.TxIndexer.Proxy;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Numerics;
using Nethereum.RPC.Eth.DTOs;

namespace TR20.Loyalty.LedgerClient.Lib
{

    public class ExchangeTokenService
    {
        private string HttpRPCEndpoint;
        private string account;
        private Indexer.IndexerServiceProxy indexerProxy;

        public ExchangeTokenService(string httpRPCEndpoint,  string account)
        {
            this.HttpRPCEndpoint = httpRPCEndpoint;
            this.account = account;

            indexerProxy = new Indexer.IndexerServiceProxy("http://txindexer/",
                new System.Net.Http.HttpClient());
        }

        public ExchangeTokenService()
        {
        }

        public async Task<bool> ExchangeTokens(
            string contractAddress,
            string exchangeMarketAddress,
            string txOwner,
            string sourceTokenAddress,
            string targetTokenAddress,
            BigInteger exchangeRate,
            BigInteger tokenAmount)
        {
            ExchangeToken exchangeToken = new ExchangeToken(this.HttpRPCEndpoint, this.account);
            try
            {
                var txReciept = await exchangeToken.ExchangeTokens(
                    contractAddress,
                    exchangeMarketAddress,
                    txOwner,
                    sourceTokenAddress,
                    targetTokenAddress,
                    exchangeRate,
                    tokenAmount);

                //adding log to OffChain

                return true;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeployExchangeTokenContract()
        {
            ExchangeToken exchangeToken = new ExchangeToken(this.HttpRPCEndpoint, this.account);
            try
            {
                var txReceipt = await exchangeToken.DeployContractAsync();
                return txReceipt.ContractAddress;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }


    }
}
