using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR20.Loyalty.API;

namespace MileageTokenService
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

        public async Task<string> DeployRewardMileageContract(string tokenContractAddress, string tokenOwnerAccountAddress, string rewarderName)
        {
            return await this.proxyClient.DeployTokenRewarderAsync(tokenContractAddress, tokenOwnerAccountAddress, rewarderName);
        }

        public async Task<bool> SendRewardToken(string tokenContractAddress,
            string tokenContractOwner, string receipientAddress, double tokenAmount)
        {
           return await this.proxyClient.SendRewardTokenAsync(tokenContractAddress,
                tokenContractOwner, receipientAddress, tokenAmount);
        }

    }
}
