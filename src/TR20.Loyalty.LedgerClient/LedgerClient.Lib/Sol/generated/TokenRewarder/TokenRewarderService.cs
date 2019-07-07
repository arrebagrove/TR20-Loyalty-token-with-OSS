using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;


namespace TR20.Loyalty.LedgerClient.Contracts.TokenRewarder
{
    public partial class TokenRewarderService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, TokenRewarderDeployment tokenRewarderDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<TokenRewarderDeployment>().SendRequestAndWaitForReceiptAsync(tokenRewarderDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, TokenRewarderDeployment tokenRewarderDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<TokenRewarderDeployment>().SendRequestAsync(tokenRewarderDeployment);
        }

        public static async Task<TokenRewarderService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, TokenRewarderDeployment tokenRewarderDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, tokenRewarderDeployment, cancellationTokenSource);
            return new TokenRewarderService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public TokenRewarderService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> TokenContractAddressQueryAsync(TokenContractAddressFunction tokenContractAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenContractAddressFunction, string>(tokenContractAddressFunction, blockParameter);
        }

        
        public Task<string> TokenContractAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenContractAddressFunction, string>(null, blockParameter);
        }

        public Task<string> SendRewardTokenRequestAsync(SendRewardTokenFunction sendRewardTokenFunction)
        {
             return ContractHandler.SendRequestAsync(sendRewardTokenFunction);
        }

        public Task<TransactionReceipt> SendRewardTokenRequestAndWaitForReceiptAsync(SendRewardTokenFunction sendRewardTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sendRewardTokenFunction, cancellationToken);
        }

        public Task<string> SendRewardTokenRequestAsync(string recipient, BigInteger amount)
        {
            var sendRewardTokenFunction = new SendRewardTokenFunction();
                sendRewardTokenFunction.Recipient = recipient;
                sendRewardTokenFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(sendRewardTokenFunction);
        }

        public Task<TransactionReceipt> SendRewardTokenRequestAndWaitForReceiptAsync(string recipient, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var sendRewardTokenFunction = new SendRewardTokenFunction();
                sendRewardTokenFunction.Recipient = recipient;
                sendRewardTokenFunction.Amount = amount;
            sendRewardTokenFunction.Gas = new BigInteger(999999);
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sendRewardTokenFunction, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }
    }
}
