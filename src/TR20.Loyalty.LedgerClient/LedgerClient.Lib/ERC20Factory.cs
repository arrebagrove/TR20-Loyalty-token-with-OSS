using System;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.RPC.Eth.DTOs;
using System.Threading.Tasks;
using System.Numerics;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class ERC20Factory : ERC20Base
    {
        //Web3 web3;

        //string appAddress = "0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD";
        //string connectionString = "http://127.0.0.1:8545";
           //"https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt";

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
