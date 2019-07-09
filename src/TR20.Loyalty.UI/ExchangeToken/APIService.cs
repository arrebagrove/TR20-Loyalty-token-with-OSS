using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR20.Loyalty.API;

namespace ExchangeToken
{
    public class APIService
    {
        private string httpEndPoint;
        private Client proxyClient;
        public APIService(string httpEndPoint)
        {
            this.httpEndPoint = httpEndPoint;
            this.proxyClient = new Client(this.httpEndPoint, new System.Net.Http.HttpClient());
        }

        public async Task<string> GetBalance(string tokenContractAddress,
            string account)
        {
            return await this.proxyClient.GetBalanceAsync(tokenContractAddress, account);
        }

        public async Task<bool> Approve(string tokenContractAddress, string approverAccountAddress, string spenderAccountAddress, double tokenAmount)
        {
            return await this.proxyClient.ApproveAsync(tokenContractAddress, approverAccountAddress, spenderAccountAddress, tokenAmount);
        }

        public async Task<bool> ExchangeTokens(string tokenExchangeContractAddreee,
            string txOwner, string exchangerMarketAddress, string sourceTokenContractAddress, string targetTokenContractAddress,
            int exchangeRatePercentage, int tokenAmount)
        {
            return await this.proxyClient.ExchangeTokenAsync(tokenExchangeContractAddreee,
                txOwner, exchangerMarketAddress, sourceTokenContractAddress, targetTokenContractAddress, exchangeRatePercentage, tokenAmount);
        }

    }
}
