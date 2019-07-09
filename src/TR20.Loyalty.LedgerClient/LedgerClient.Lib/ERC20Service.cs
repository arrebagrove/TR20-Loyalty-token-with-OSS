using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OffChain = TR20.Loyalty.OffChainRepository.Mongo.Model;
using TR20.Loyalty.TxIndexer.Proxy;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace TR20.Loyalty.LedgerClient.Lib
{
    public class ERC20Service
    {
        private string HttpRPCEndpoint;
        private string account;
        private IndexerServiceProxy indexerProxy;

        public ERC20Service(string httpRPCEndpoint, string account)
        {
            this.HttpRPCEndpoint = httpRPCEndpoint;
            this.account = account;
            indexerProxy = new IndexerServiceProxy("http://txindexer/",
                new System.Net.Http.HttpClient());
            }

        private ERC20Service()
        {
        }

        public async Task<TokenInfo> DeployERC20Contract(string tokenName, string tokenSymbol, BigInteger initialAmount, Byte decimalUnit)
        {
            ERC20 erc20 = new ERC20(this.HttpRPCEndpoint, this.account);
            string contractAddress = await erc20.DeployToken(tokenName, tokenSymbol, initialAmount, decimalUnit);

            return new TokenInfo()
            {
                Name = tokenName,
                Symbol = tokenSymbol,
                TotalSupplied = initialAmount,
                ContractAddress = contractAddress
            };
        }

        public async Task<BigInteger> GetBalanceAsync(string tokenContractAddress, string address)
        {
            ERC20 erc20 = new ERC20(this.HttpRPCEndpoint, this.account);
            return await erc20.GetBalanceAsync(tokenContractAddress, address);
        }

        public async Task<bool> TransferFromAsync(string tokenContractAddress, string senderAddress, string recepientAddress, BigInteger amount)
        {
            ERC20 erc20 = new ERC20(this.HttpRPCEndpoint, this.account);

            try
            {
                var txReceipt = await erc20.TransferFromAsync(tokenContractAddress, senderAddress, recepientAddress, amount);

                //adding log to Offchain
                var transactionContext = new OffChain.ContractTransaction(this.account,
                    new OffChain.TokenTransfer()
                    {
                        Description = "TransferFrom",
                        FromAccount = senderAddress,
                        ToAccount = recepientAddress,
                        TokenAmount = amount.ToString(),
                        TokenAddress = tokenContractAddress
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
                       });


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

#if !DEBUG
                await indexerProxy.LogTransactionAsync(_transactionContext, transactionContext.BusinessContractDTO.Description);
#endif

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> TransferAsync(string tokenContractAddress, string recepientAddress, BigInteger amount)
        {
            ERC20 erc20 = new ERC20(this.HttpRPCEndpoint, this.account);

            try
            {
                var txReceipt = await erc20.TransferAsync(tokenContractAddress,recepientAddress, amount);
                //adding log to Offchain

                var transactionContext = new OffChain.ContractTransaction(this.account,
                     new OffChain.TokenTransfer()
                     {
                         Description = "Transfer",
                         FromAccount = this.account,
                         ToAccount = recepientAddress,
                         TokenAmount = amount.ToString(),
                         TokenAddress = tokenContractAddress
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

#if !DEBUG
                await indexerProxy.LogTransactionAsync(_transactionContext, transactionContext.BusinessContractDTO.Description);
#endif
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //User1 approve Application's transaction.
        //User1 have to login to ledger and approve Application's tranfer
        public async Task<bool> ApproveAsync(string tokenContractAddress, string spenderAddress, BigInteger amount)
        {
            ERC20 erc20 = new ERC20(this.HttpRPCEndpoint, this.account);

            try
            {
                var txReceipt = await erc20.ApproveAsync(tokenContractAddress, spenderAddress, amount);
                //adding log to Offchain

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TokenInfo> GetTokenInfoAsync(string tokenContractAddress)
        {
            ERC20 erc20 = new ERC20(this.HttpRPCEndpoint, this.account);

            try
            {
                return await erc20.GetTokenInfoAsync(tokenContractAddress);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}