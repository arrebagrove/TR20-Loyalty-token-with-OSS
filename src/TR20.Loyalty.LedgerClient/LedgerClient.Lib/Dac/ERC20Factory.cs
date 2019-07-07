using System;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.RPC.Eth.DTOs;
using System.Threading.Tasks;
using System.Numerics;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class ERC20Factory : LedgerClientBase
    {
        public ERC20Factory(string connectionString, string address) : base(connectionString, address)
        {
        }

        public async Task<TransactionReceipt> DeployContractAsync()
        {
            return await Contracts.EIP20Factory.EIP20FactoryService.DeployContractAndWaitForReceiptAsync(web3,
                new Contracts.EIP20Factory.EIP20FactoryDeployment());
        }

        public async Task<TransactionReceipt> SetupTokenAsync(string tokenFactoryContractAddress, BigInteger initialAmount, string name, byte decimals, string symbol)
        {
            var erc20FactoryService = new Contracts.EIP20Factory.EIP20FactoryService(this.web3, tokenFactoryContractAddress);
            return await erc20FactoryService.CreateEIP20RequestAndWaitForReceiptAsync(initialAmount, name, decimals, symbol);
        }

        public async Task<bool> CheckEIP20(string tokenFactoryContractAddress, string tokenContractAddress)
        {
            var erc20FactoryService = new Contracts.EIP20Factory.EIP20FactoryService(this.web3, tokenFactoryContractAddress);
            return await erc20FactoryService.VerifyEIP20QueryAsync(tokenContractAddress);
        }

        public async Task<bool> IsEIP20(string tokenFactoryContractAddress, string tokenContractAddress)
        {
            var erc20FactoryService = new Contracts.EIP20Factory.EIP20FactoryService(this.web3, tokenFactoryContractAddress);
            return await erc20FactoryService.IsEIP20QueryAsync(tokenContractAddress);
        }
    }
}
