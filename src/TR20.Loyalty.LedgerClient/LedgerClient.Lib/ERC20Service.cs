using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class ERC20Service
    {
        private string HttpRPCEndpoint;
        private string account;
        private string tokenContractAddress;

        public ERC20Service(string httpRPCEndpoint, string tokenContractAddress, string account)
        {
            this.HttpRPCEndpoint = httpRPCEndpoint;
            this.tokenContractAddress = tokenContractAddress;
            this.account = account;
        }

        private ERC20Service()
        {
        }

        public async Task<BigInteger> GetBalanceAsync(string address)
        {
            ERC20 erc20 = new ERC20(this.HttpRPCEndpoint, this.tokenContractAddress, this.account);
            return await erc20.GetBalanceAsync(address);
        }

        public async Task<bool> TransferFromAsync(string senderAddress, string recepientAddress, BigInteger amount)
        {
            ERC20 erc20 = new ERC20(this.HttpRPCEndpoint, this.tokenContractAddress, this.account);

            try
            {
                var txReceipt = await erc20.TransferFromAsync(senderAddress, recepientAddress, amount);
                //adding log to Offchain


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> TransferAsync(string recepientAddress, BigInteger amount)
        {
            ERC20 erc20 = new ERC20(this.HttpRPCEndpoint, this.tokenContractAddress, this.account);

            try
            {
                var txReceipt = await erc20.TransferAsync(recepientAddress, amount);
                //adding log to Offchain


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //User1 approve Application's transaction.
        //User1 have to login to ledger and approve Application's tranfer
        public async Task<bool> ApproveAsync(string spenderAddress, BigInteger amount)
        {
            ERC20 erc20 = new ERC20(this.HttpRPCEndpoint, this.tokenContractAddress, this.account);

            try
            {
                var txReceipt = await erc20.ApproveAsync(spenderAddress, amount);
                //adding log to Offchain

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TokenInfo> GetTokenInfoAsync()
        {
            ERC20 erc20 = new ERC20(this.HttpRPCEndpoint, this.tokenContractAddress, this.account);

            try
            {
                return await erc20.GetTokenInfoAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
}