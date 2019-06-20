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
        string tokenAddress = "";

        public ERC20(string connectionString,string tokenAddress, string address): base(connectionString, address)
        {
            this.tokenAddress = tokenAddress;
        }

        public async Task<BigInteger> GetBalanceAsync(string address)
        {
            var erc20Service = new Contracts.EIP20.EIP20Service(this.web3, this.tokenAddress);
            return await erc20Service.BalanceOfQueryAsync(address);
        }

        public async Task<TransactionReceipt> TransferFromAsync(string senderAddress, string recepientAddress, BigInteger amount)
        {
            var erc20Service = new Contracts.EIP20.EIP20Service(this.web3, this.tokenAddress);
            return await erc20Service.TransferFromRequestAndWaitForReceiptAsync(senderAddress, recepientAddress, amount);
        }

        public async Task<TransactionReceipt> TransferAsync(string recepientAddress, BigInteger amount)
        {
            var erc20Service = new Contracts.EIP20.EIP20Service(this.web3, this.tokenAddress);
            return await erc20Service.TransferRequestAndWaitForReceiptAsync(recepientAddress, amount);
        }

        public async Task<TransactionReceipt> ApproveAsync(string spenderAddress, BigInteger amount)
        {
            var erc20Service = new Contracts.EIP20.EIP20Service(this.web3, this.tokenAddress);
            return await erc20Service.ApproveRequestAndWaitForReceiptAsync(spenderAddress, amount);
        }

        public async Task<BigInteger> AllowanceAsync(string ownerAddress, string spenderAddress)
        {
            var erc20Service = new Contracts.EIP20.EIP20Service(this.web3, this.tokenAddress);
            return await erc20Service.AllowanceQueryAsync(ownerAddress, spenderAddress);
        }

        public async Task<TokenInfo> GetTokenInfoAsync()
        {
            var erc20Service = new Contracts.EIP20.EIP20Service(this.web3, this.tokenAddress);
            return new TokenInfo()
            {
                Name = await erc20Service.NameQueryAsync(),
                Symbol = await erc20Service.SymbolQueryAsync(),
                TotalSupplied = await erc20Service.TotalSupplyQueryAsync()
            };
        }
    }

    public class TokenInfo
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public BigInteger TotalSupplied { get; set; }
    }
}
