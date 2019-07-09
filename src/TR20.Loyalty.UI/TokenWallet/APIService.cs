using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TR20.Loyalty.API;

namespace TokenWallet
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

        public async Task<string> GetBalance(string tokenContractAddress, string userPubAddress)
        {
            return await this.proxyClient.GetBalanceAsync(tokenContractAddress, userPubAddress);
        }

        public async Task<TR20.Loyalty.API.TokenInfo> GetTokenInfo(string tokenContractAddress)
        {
            return await this.proxyClient.GetTokenInfoAsync(tokenContractAddress);
        }

        public async Task<bool> Transfer(string tokenContractAddress, string senderAddress, string recipientAddress, double tokenAmount)
        {
            return await this.proxyClient.TransferAsync(tokenContractAddress, senderAddress, recipientAddress, tokenAmount);
        }

        public async Task<bool> Approve(string tokenContractAddress, string approverAccountAddress, string spenderAccountAddress, double tokenAmount)
        {
            return await this.proxyClient.ApproveAsync(tokenContractAddress, approverAccountAddress, spenderAccountAddress, tokenAmount);
        }
    }
}
