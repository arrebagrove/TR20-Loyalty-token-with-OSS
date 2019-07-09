using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR20.Loyalty.API;

namespace TokenManager
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

        public async Task<TokenInfo> CreateTokenAsync(double totalAmountToken, string tokenName, int decimalDigit, string symbol)
        {
           return  await this.proxyClient.CreateERC20TokenAsync(
                totalAmountToken,
                tokenName,
                decimalDigit,
                symbol);
        }
    }
}

