using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class ERC20 : LedgerClientBase
    {
        public ERC20(string connectionString, string address): base(connectionString, address)
        {

        }

        public async Task<string> DeployToken(string tokenName, string tokenSymbol, BigInteger initialAmount, byte decimalUnit)
        {
            return (await Contracts.EIP20.EIP20Service.DeployContractAndWaitForReceiptAsync(web3, 
                new Contracts.EIP20.EIP20Deployment() {
                    TokenName = tokenName,
                    DecimalUnits = decimalUnit ,
                    TokenSymbol =  tokenSymbol,
                    InitialAmount = initialAmount
                })).ContractAddress;
        }


        public async Task<BigInteger> GetBalanceAsync(string tokenContractAddress, string address)
        {
            var erc20Service = new Contracts.EIP20.EIP20Service(this.web3, tokenContractAddress);
            return await erc20Service.BalanceOfQueryAsync(address);
        }

        public async Task<TransactionReceipt> TransferFromAsync(string tokenContractAddress, string senderAddress, string recepientAddress, BigInteger amount)
        {
            var erc20Service = new Contracts.EIP20.EIP20Service(this.web3, tokenContractAddress);
            return await erc20Service.TransferFromRequestAndWaitForReceiptAsync(senderAddress, recepientAddress, amount);
        }

        public async Task<TransactionReceipt> TransferAsync(string tokenContractAddress, string recepientAddress, BigInteger amount)
        {
            var erc20Service = new Contracts.EIP20.EIP20Service(this.web3, tokenContractAddress);
            return await erc20Service.TransferRequestAndWaitForReceiptAsync(recepientAddress, amount);
        }

      
        public async Task<TransactionReceipt> ApproveAsync(string tokenContractAddress, string spenderAddress, BigInteger amount)
        {
            var erc20Service = new Contracts.EIP20.EIP20Service(this.web3, tokenContractAddress);
            return await erc20Service.ApproveRequestAndWaitForReceiptAsync(spenderAddress, amount);
        }

        public async Task<BigInteger> AllowanceAsync(string tokenContractAddress, string ownerAddress, string spenderAddress)
        {
            var erc20Service = new Contracts.EIP20.EIP20Service(this.web3, tokenContractAddress);
            return await erc20Service.AllowanceQueryAsync(ownerAddress, spenderAddress);
        }

        public async Task<TokenInfo> GetTokenInfoAsync(string tokenContractAddress)
        {
            var erc20Service = new Contracts.EIP20.EIP20Service(this.web3, tokenContractAddress);
            return new TokenInfo()
            {
                Name = await erc20Service.NameQueryAsync(),
                Symbol = await erc20Service.SymbolQueryAsync(),
                TotalSupplied = await erc20Service.TotalSupplyQueryAsync(),
                ContractAddress = tokenContractAddress
            };
        }
    }

    public class TokenInfo
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public BigInteger TotalSupplied { get; set; }
        public string ContractAddress { get; set; }
    }
}
