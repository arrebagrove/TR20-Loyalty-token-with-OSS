using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class ERC20FactoryService
    {

        private ERC20Factory erc20Factory;
        private string HttpRPCEndpoint;
        private string account;
        private string tokenContractAddress;

        public ERC20FactoryService(string httpRPCEndpoint, string tokenContractAddress, string account)
        {
            this.HttpRPCEndpoint = httpRPCEndpoint;
            this.tokenContractAddress = tokenContractAddress;
            this.account = account;
        }

        private ERC20FactoryService()
        {
        }

        public static async Task<string> DeployESC20FactoryContract(string httpRPCEndpoint, string account)
        {
            ERC20Factory erc20Factory = new ERC20Factory(httpRPCEndpoint, account);

            try
            {
                var txReciept = await erc20Factory.DeployContractAsync();
                //adding log to Offchain

                return txReciept.ContractAddress;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> IsERP20Async(string tokenFactoryContractAddress, 
            string tokenContractAddress)
        {
            ERC20Factory erc20Factory = new ERC20Factory(this.HttpRPCEndpoint,
    this.account);

            try
            {
                return await erc20Factory.IsEIP20(tokenFactoryContractAddress,
                    tokenContractAddress);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TokenInfo> SetupTokenAsync(string tokenFactoryContractAddress,
            BigInteger TotalAmountToken,
            string Name,
            byte Decimal,
            string Symbol)
        {
            ERC20Factory erc20Factory = new ERC20Factory(this.HttpRPCEndpoint, this.account);
            try
            {
                var txReciept = await erc20Factory.SetupTokenAsync(tokenFactoryContractAddress, TotalAmountToken, Name, Decimal, Symbol);
                //adding log

                var deployedTokenAddress = txReciept.Logs.SelectToken("[0].address").ToString();

                return new TokenInfo()
                {
                    ContractAddress = deployedTokenAddress,
                    Name = Name,
                    TotalSupplied = TotalAmountToken,
                    Symbol = Symbol
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
