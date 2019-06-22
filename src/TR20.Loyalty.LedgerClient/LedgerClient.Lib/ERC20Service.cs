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
        private string tokenContractAddress;
        private IndexerServiceProxy indexerProxy;

        public ERC20Service(string httpRPCEndpoint, string tokenContractAddress, string account)
        {
            this.HttpRPCEndpoint = httpRPCEndpoint;
            this.tokenContractAddress = tokenContractAddress;
            this.account = account;

            indexerProxy = new IndexerServiceProxy("http://localhost:8081/",
                new System.Net.Http.HttpClient());
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
                var transactionContext = new OffChain.ContractTransaction(this.account,
                    new OffChain.TokenTransfer()
                    {
                        Description = "TransferFrom",
                        FromAccount = senderAddress,
                        ToAccount = recepientAddress,
                        TokenAmount = amount.ToString(),
                        TokenAddress = this.tokenContractAddress
                    },
                    txReceipt);


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
                        BlockNumber = new HexBigInteger()
                        {
                            HexValue = transactionContext.TransactionConfirmation.BlockNumber.HexValue,
                            Value = transactionContext.TransactionConfirmation.BlockNumber.Value.ToString()
                        },
                        ContractAddress = transactionContext.TransactionConfirmation.ContractAddress,
                        CumulativeGasUsed = new HexBigInteger()
                        {
                            HexValue = transactionContext.TransactionConfirmation.CumulativeGasUsed.HexValue,
                            Value = transactionContext.TransactionConfirmation.CumulativeGasUsed.Value.ToString()
                        },
                        GasUsed = new HexBigInteger()
                        {
                            HexValue = transactionContext.TransactionConfirmation.GasUsed.HexValue,
                            Value = transactionContext.TransactionConfirmation.GasUsed.Value.ToString()
                        },
                        Logs = transactionContext.TransactionConfirmation.Logs,
                        Status = new HexBigInteger()
                        {
                            HexValue = transactionContext.TransactionConfirmation.Status.HexValue,
                            Value = transactionContext.TransactionConfirmation.Status.Value.ToString()
                        },
                        TransactionHash = transactionContext.TransactionConfirmation.TransactionHash,
                        TransactionIndex = new HexBigInteger()
                        {
                            HexValue = transactionContext.TransactionConfirmation.TransactionIndex.HexValue,
                            Value = transactionContext.TransactionConfirmation.TransactionIndex.Value.ToString()
                        }
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
                var transactionContext = new OffChain.ContractTransaction(this.account,
                     new OffChain.TokenTransfer()
                     {
                         Description = "Transfer",
                         FromAccount = this.account,
                         ToAccount = recepientAddress,
                         TokenAmount = amount.ToString(),
                         TokenAddress = this.tokenContractAddress
                     },
                     txReceipt);

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
                        BlockNumber = new HexBigInteger()
                        {
                            HexValue = transactionContext.TransactionConfirmation.BlockNumber.HexValue,
                            Value = transactionContext.TransactionConfirmation.BlockNumber.Value.ToString()
                        },
                        ContractAddress = transactionContext.TransactionConfirmation.ContractAddress,
                        CumulativeGasUsed = new HexBigInteger()
                        {
                            HexValue = transactionContext.TransactionConfirmation.CumulativeGasUsed.HexValue,
                            Value = transactionContext.TransactionConfirmation.CumulativeGasUsed.Value.ToString()
                        },
                        GasUsed = new HexBigInteger()
                        {
                            HexValue = transactionContext.TransactionConfirmation.GasUsed.HexValue,
                            Value = transactionContext.TransactionConfirmation.GasUsed.Value.ToString()
                        },
                        Logs = transactionContext.TransactionConfirmation.Logs,
                        Status = new HexBigInteger()
                        {
                            HexValue = transactionContext.TransactionConfirmation.Status.HexValue,
                            Value = transactionContext.TransactionConfirmation.Status.Value.ToString()
                        },
                        TransactionHash = transactionContext.TransactionConfirmation.TransactionHash,
                        TransactionIndex = new HexBigInteger()
                        {
                            HexValue = transactionContext.TransactionConfirmation.TransactionIndex.HexValue,
                            Value = transactionContext.TransactionConfirmation.TransactionIndex.Value.ToString()
                        }
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