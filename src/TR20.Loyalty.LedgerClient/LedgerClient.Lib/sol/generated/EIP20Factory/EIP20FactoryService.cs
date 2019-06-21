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
using TR20.Loyalty.LedgerClient.Lib.Contracts.EIP20Factory;

namespace TR20.Loyalty.LedgerClient.Lib.Contracts.EIP20Factory
{
    public partial class EIP20FactoryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, EIP20FactoryDeployment eIP20FactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<EIP20FactoryDeployment>().SendRequestAndWaitForReceiptAsync(eIP20FactoryDeployment);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, EIP20FactoryDeployment eIP20FactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<EIP20FactoryDeployment>().SendRequestAsync(eIP20FactoryDeployment);
        }

        public static async Task<EIP20FactoryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, EIP20FactoryDeployment eIP20FactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, eIP20FactoryDeployment);
            return new EIP20FactoryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public EIP20FactoryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CreateEIP20RequestAsync(CreateEIP20Function createEIP20Function)
        {
             return ContractHandler.SendRequestAsync(createEIP20Function);
        }

        public Task<TransactionReceipt> CreateEIP20RequestAndWaitForReceiptAsync(CreateEIP20Function createEIP20Function)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createEIP20Function);
        }

        public Task<string> CreateEIP20RequestAsync(BigInteger initialAmount, string name, byte decimals, string symbol)
        {
            var createEIP20Function = new CreateEIP20Function();
                createEIP20Function.InitialAmount = initialAmount;
                createEIP20Function.Name = name;
                createEIP20Function.Decimals = decimals;
                createEIP20Function.Symbol = symbol;
            
             return ContractHandler.SendRequestAsync(createEIP20Function);
        }

        public Task<TransactionReceipt> CreateEIP20RequestAndWaitForReceiptAsync(BigInteger initialAmount, string name, byte decimals, string symbol)
        {
            var createEIP20Function = new CreateEIP20Function();
                createEIP20Function.InitialAmount = initialAmount;
                createEIP20Function.Name = name;
                createEIP20Function.Decimals = decimals;
                createEIP20Function.Symbol = symbol;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createEIP20Function);
        }

        public Task<string> CreatedQueryAsync(CreatedFunction createdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CreatedFunction, string>(createdFunction, blockParameter);
        }

        
        public Task<string> CreatedQueryAsync(string returnValue1, BigInteger returnValue2, BlockParameter blockParameter = null)
        {
            var createdFunction = new CreatedFunction();
                createdFunction.ReturnValue1 = returnValue1;
                createdFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryAsync<CreatedFunction, string>(createdFunction, blockParameter);
        }

        public Task<bool> IsEIP20QueryAsync(IsEIP20Function isEIP20Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsEIP20Function, bool>(isEIP20Function, blockParameter);
        }

        
        public Task<bool> IsEIP20QueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var isEIP20Function = new IsEIP20Function();
                isEIP20Function.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<IsEIP20Function, bool>(isEIP20Function, blockParameter);
        }

        public Task<byte[]> EIP20ByteCodeQueryAsync(EIP20ByteCodeFunction eIP20ByteCodeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EIP20ByteCodeFunction, byte[]>(eIP20ByteCodeFunction, blockParameter);
        }

        
        public Task<byte[]> EIP20ByteCodeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EIP20ByteCodeFunction, byte[]>(null, blockParameter);
        }

        public Task<bool> VerifyEIP20QueryAsync(VerifyEIP20Function verifyEIP20Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VerifyEIP20Function, bool>(verifyEIP20Function, blockParameter);
        }

        
        public Task<bool> VerifyEIP20QueryAsync(string tokenContract, BlockParameter blockParameter = null)
        {
            var verifyEIP20Function = new VerifyEIP20Function();
                verifyEIP20Function.TokenContract = tokenContract;
            
            return ContractHandler.QueryAsync<VerifyEIP20Function, bool>(verifyEIP20Function, blockParameter);
        }
    }
}
