using System;
using System.Collections.Generic;
using System.Text;
using TR20.Loyalty.OffChainRepository.Mongo.ModelBase;
using Nethereum.RPC.Eth.DTOs;

namespace TR20.Loyalty.OffChainRepository.Mongo.Model
{
    public class ContractTransaction : IEntityModel<Guid>
    {
        public ContractTransaction()
        {
        }

        public ContractTransaction(string transactionOwner, TokenTransfer businessContract, TransactionReceipt contractDeployed, string TokenName ="")
        {
            Id = Guid.NewGuid();
            TransactionID = contractDeployed.TransactionHash;
            TransactionTime = DateTime.UtcNow;

            TransactionConfirmation = contractDeployed;
            BusinessContractDTO = businessContract;
            TransactionOwner = transactionOwner;
            Name = TokenName;
        }

        //Key for Mongo......
        public Guid Id { get; set; }

        //public bool IsActiveTransaction { get; set; }
        //Should be assigned per each transaction
        public string TransactionID { get; set; }
       
        public DateTime TransactionTime { get; set; }

        public TransactionReceipt TransactionConfirmation { get; set; }
        //Business DTO
        public TokenTransfer BusinessContractDTO { get; set; }

        public string Name { get; set; }
        public string TransactionOwner { get; set; }

    }
}