using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OffChain = TR20.Loyalty.OffChainRepository.Mongo.Model;
using TR20.Loyalty.TxIndexer.Proxy;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class ERC20FactoryService
    {

        private string HttpRPCEndpoint;
        private string account;
        private string tokenContractAddress;
        private IndexerServiceProxy indexerProxy;

        public ERC20FactoryService(string httpRPCEndpoint, string tokenContractAddress, string account)
        {
            this.HttpRPCEndpoint = httpRPCEndpoint;
            this.tokenContractAddress = tokenContractAddress;
            this.account = account;
            indexerProxy = new IndexerServiceProxy("http://txindexer/",
             new System.Net.Http.HttpClient());
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
                var txReceipt = await erc20Factory.SetupTokenAsync(tokenFactoryContractAddress, TotalAmountToken, Name, Decimal, Symbol);
                var deployedTokenAddress = txReceipt.Logs.SelectToken("[0].address").ToString();

                 //adding log
                var transactionContext = new OffChain.ContractTransaction(this.account,
                    new OffChain.TokenTransfer()
                      {
                          Description = "Created",
                          FromAccount = tokenFactoryContractAddress,
                          ToAccount = this.account,
                          TokenAmount = TotalAmountToken.ToString(),
                          TokenAddress = this.tokenContractAddress
                      },
                         new OffChain.TransactionReceipt()
                         {
                             BlockHash = txReceipt.BlockHash,
                             BlockNumber = txReceipt.BlockNumber.HexValue,
                             ContractAddress = txReceipt.ContractAddress,
                             CumulativeGasUsed = txReceipt.CumulativeGasUsed.HexValue,
                             GasUsed = txReceipt.GasUsed.HexValue,
                             Logs = txReceipt.Logs.ToString(),
                             Status = txReceipt.Status.HexValue,
                             TransactionHash = txReceipt.TransactionHash,
                             TransactionIndex = txReceipt.TransactionIndex.HexValue
                         }
                          );

                        var _transactionContext = new TR20.Loyalty.TxIndexer.Proxy.ContractTransaction()
                        {
                            Id = transactionContext.Id,
                            Name = transactionContext.Name,
                            TransactionID = transactionContext.TransactionID,
                            TransactionTime = transactionContext.TransactionTime,
                            TransactionOwner = transactionContext.TransactionOwner,
                            TransactionConfirmation = new TR20.Loyalty.TxIndexer.Proxy.TransactionReceipt()
                            {
                                BlockHash = transactionContext.TransactionConfirmation.BlockHash,
                                BlockNumber = transactionContext.TransactionConfirmation.BlockNumber,
                                ContractAddress = transactionContext.TransactionConfirmation.ContractAddress,
                                CumulativeGasUsed = transactionContext.TransactionConfirmation.CumulativeGasUsed,
                                GasUsed = transactionContext.TransactionConfirmation.GasUsed,
                                Logs = transactionContext.TransactionConfirmation.Logs,
                                TransactionHash = transactionContext.TransactionConfirmation.TransactionHash,
                                TransactionIndex = transactionContext.TransactionConfirmation.TransactionIndex
                            },
                            BusinessContractDTO = new TokenTransfer()
                            {
                                Description = transactionContext.BusinessContractDTO.Description,
                                FromAccount = transactionContext.BusinessContractDTO.FromAccount,
                                ToAccount = transactionContext.BusinessContractDTO.ToAccount,
                                TokenAmount = transactionContext.BusinessContractDTO.TokenAmount,
                                TokenAddress = transactionContext.BusinessContractDTO.TokenAddress
                            }
                        };

                await indexerProxy.LogTransactionAsync(_transactionContext, transactionContext.BusinessContractDTO.Description);



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
