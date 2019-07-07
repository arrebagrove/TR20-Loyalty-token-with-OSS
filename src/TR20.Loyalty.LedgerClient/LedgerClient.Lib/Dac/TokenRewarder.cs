using System;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.RPC.Eth.DTOs;
using System.Threading.Tasks;
using System.Numerics;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class TokenRewarder : LedgerClientBase
    {
        //string contractAddress = "";

        public TokenRewarder(string connectionString, string address) : base(connectionString, address)
        {

        }

        public async Task<TransactionReceipt> DeployContractAsync(string rewarderName, string tokenContractAddress)
        {
            return await Contracts.TokenRewarder.TokenRewarderService.DeployContractAndWaitForReceiptAsync(web3, new Contracts.TokenRewarder.TokenRewarderDeployment()
            {
                RewarderName = rewarderName,
                TokenContractAddress = tokenContractAddress
            });
        }

        public async Task<TransactionReceipt> SendRewardTokenAsync(string contractAddress, string recipientAddress, BigInteger amount)
        {
            var tokenRewarderService = new Contracts.TokenRewarder.TokenRewarderService(web3, contractAddress);
            return await tokenRewarderService.SendRewardTokenRequestAndWaitForReceiptAsync(recipientAddress, amount);
        }

        public async Task<SCInfo> GetContractInformation(string contractAddress)
        {
            var tokenRewarderService = new Contracts.TokenRewarder.TokenRewarderService(web3, contractAddress);

            var scinfo = new SCInfo()
            {
                Name = await tokenRewarderService.NameQueryAsync(),
                ContractAddress = await tokenRewarderService.TokenContractAddressQueryAsync()
            };

            return scinfo;
        }

        public class SCInfo
        {
            public string Name { get; set; }
            public string ContractAddress { get; set; }
        }
    }
}
