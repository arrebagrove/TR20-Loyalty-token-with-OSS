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
    public class TokenRewarderService
    {
        private string HttpRPCEndpoint;
        private string account;
        private string tokenContractAddress;
        private Indexer.IndexerServiceProxy indexerProxy;

        public TokenRewarderService(string httpRPCEndpoint, string account)
        {
            this.HttpRPCEndpoint = httpRPCEndpoint;
            this.account = account;
            indexerProxy = new Indexer.IndexerServiceProxy("http://txindexer/",
                new System.Net.Http.HttpClient());

        }
        public TokenRewarderService()
        {
        }

        public async Task<TokenRewarder.SCInfo> GetSCInfoAsync(string tokenContractAddress)
        {
            TokenRewarder tokenRewarder = new TokenRewarder(this.HttpRPCEndpoint, this.account);
            return await tokenRewarder.GetContractInformation(tokenContractAddress);
        }

        public async Task<string> DeployTokenRewarderContract(string tokenContractAddress, string rewarderName)
        {
            TokenRewarder tokenRewarder = new TokenRewarder(this.HttpRPCEndpoint, this.account);

            try
            {
                var txReciept =  await tokenRewarder.DeployContractAsync(rewarderName, tokenContractAddress);
                return txReciept.ContractAddress;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> SendRewardTokenAsync(string contractAddress, string recipientAddress, BigInteger amount)
        {
            TokenRewarder tokenRewarder = new TokenRewarder(this.HttpRPCEndpoint, this.account);
            try
            {
                var txReceipt =  await tokenRewarder.SendRewardTokenAsync(contractAddress, recipientAddress, amount);
                //add indexer log


                return true;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }






    }
}
