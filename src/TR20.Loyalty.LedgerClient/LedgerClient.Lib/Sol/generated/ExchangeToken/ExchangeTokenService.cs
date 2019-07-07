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

namespace TR20.Loyalty.LedgerClient.Contracts.ExchangeToken
{
    public partial class ExchangeTokenService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ExchangeTokenDeployment exchangeTokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ExchangeTokenDeployment>().SendRequestAndWaitForReceiptAsync(exchangeTokenDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ExchangeTokenDeployment exchangeTokenDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ExchangeTokenDeployment>().SendRequestAsync(exchangeTokenDeployment);
        }

        public static async Task<ExchangeTokenService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ExchangeTokenDeployment exchangeTokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, exchangeTokenDeployment, cancellationTokenSource);
            return new ExchangeTokenService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ExchangeTokenService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ExchangeRequestAsync(ExchangeFunction exchangeFunction)
        {
             return ContractHandler.SendRequestAsync(exchangeFunction);
        }

        public Task<TransactionReceipt> ExchangeRequestAndWaitForReceiptAsync(ExchangeFunction exchangeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(exchangeFunction, cancellationToken);
        }

        public Task<string> ExchangeRequestAsync(string txOwner, string exchangeMarketAddress, string sourceTokenAddress, string targetTokenAddress, BigInteger exchangerate, BigInteger tokenAmount)
        {
            var exchangeFunction = new ExchangeFunction();
                exchangeFunction.TxOwner = txOwner;
                exchangeFunction.ExchangeMarketAddress = exchangeMarketAddress;
                exchangeFunction.SourceTokenAddress = sourceTokenAddress;
                exchangeFunction.TargetTokenAddress = targetTokenAddress;
                exchangeFunction.Exchangerate = exchangerate;
                exchangeFunction.TokenAmount = tokenAmount;
            
             return ContractHandler.SendRequestAsync(exchangeFunction);
        }

        public Task<TransactionReceipt> ExchangeRequestAndWaitForReceiptAsync(string txOwner, string exchangeMarketAddress, string sourceTokenAddress, string targetTokenAddress, BigInteger exchangerate, BigInteger tokenAmount, CancellationTokenSource cancellationToken = null)
        {
            var exchangeFunction = new ExchangeFunction();
                exchangeFunction.TxOwner = txOwner;
                exchangeFunction.ExchangeMarketAddress = exchangeMarketAddress;
                exchangeFunction.SourceTokenAddress = sourceTokenAddress;
                exchangeFunction.TargetTokenAddress = targetTokenAddress;
                exchangeFunction.Exchangerate = exchangerate;
                exchangeFunction.TokenAmount = tokenAmount;
            exchangeFunction.Gas = new BigInteger(999999);
            return ContractHandler.SendRequestAndWaitForReceiptAsync(exchangeFunction, cancellationToken);
        }

        public Task<MappingHistoryOutputDTO> MappingHistoryQueryAsync(MappingHistoryFunction mappingHistoryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<MappingHistoryFunction, MappingHistoryOutputDTO>(mappingHistoryFunction, blockParameter);
        }

        public Task<MappingHistoryOutputDTO> MappingHistoryQueryAsync(string returnValue1, BigInteger returnValue2, BlockParameter blockParameter = null)
        {
            var mappingHistoryFunction = new MappingHistoryFunction();
                mappingHistoryFunction.ReturnValue1 = returnValue1;
                mappingHistoryFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryDeserializingToObjectAsync<MappingHistoryFunction, MappingHistoryOutputDTO>(mappingHistoryFunction, blockParameter);
        }
    }
}
