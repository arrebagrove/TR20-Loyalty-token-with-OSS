using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TR20.Loyalty.TxIndexer.Library;
using TR20.Loyalty.OffChainRepository.Mongo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using txIndexer = TR20.Loyalty.TxIndexer.Proxy;
using System.Numerics;
using Newtonsoft.Json.Linq;

namespace TR20.Loyalty.TxIndexer.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexerController : ControllerBase
    {
        private IConfiguration _configuration;
        private string _mongoConnectionString;
        public IndexerController(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoConnectionString = _configuration["offchain_connectionstring"];
        }


        [HttpPost()]
        [Route("LogTransaction")]
        public void LogTransaction([FromBody] txIndexer.ContractTransaction contractTransaction, string transactionDescription = "")
        {
            TransactionIndexer _agent = new TransactionIndexer(_mongoConnectionString);

            ContractTransaction _contractTransaction = new ContractTransaction(
                contractTransaction.TransactionOwner,
                new TokenTransfer()
                {
                    Description = contractTransaction.BusinessContractDTO.Description,
                    FromAccount = contractTransaction.BusinessContractDTO.FromAccount,
                    ToAccount = contractTransaction.BusinessContractDTO.ToAccount,
                    TokenAddress = contractTransaction.BusinessContractDTO.TokenAddress,
                    TokenAmount = contractTransaction.BusinessContractDTO.TokenAmount
                },
                new Nethereum.RPC.Eth.DTOs.TransactionReceipt()
                {
                    BlockHash = contractTransaction.TransactionConfirmation.BlockHash,
                    BlockNumber = new Nethereum.Hex.HexTypes.HexBigInteger(contractTransaction.TransactionConfirmation.BlockNumber.HexValue),
                    ContractAddress = contractTransaction.TransactionConfirmation.ContractAddress,
                    CumulativeGasUsed = new Nethereum.Hex.HexTypes.HexBigInteger(contractTransaction.TransactionConfirmation.CumulativeGasUsed.HexValue),
                    GasUsed = new Nethereum.Hex.HexTypes.HexBigInteger(contractTransaction.TransactionConfirmation.GasUsed.HexValue),
                    Logs = JArray.Parse(contractTransaction.TransactionConfirmation.Logs.ToString()),
                    Status = new Nethereum.Hex.HexTypes.HexBigInteger(contractTransaction.TransactionConfirmation.Status.HexValue),
                    TransactionHash = contractTransaction.TransactionConfirmation.TransactionHash,
                    TransactionIndex = new Nethereum.Hex.HexTypes.HexBigInteger(contractTransaction.TransactionConfirmation.TransactionIndex.HexValue)
                },
                 ""
                );

            _agent.LogTransaction(_contractTransaction, transactionDescription).GetAwaiter().GetResult();
        }


    }
}
