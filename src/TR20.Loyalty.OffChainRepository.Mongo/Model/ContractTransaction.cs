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

        public ContractTransaction(Profile businessContract, TransactionReceipt contractDeployed)
        {
            InitObject(businessContract);
            ContractID = Guid.NewGuid().ToString();

            TransactionConfirmation = contractDeployed;
            //Name = contractDeployed.;
            BindingId = contractDeployed.ContractAddress;
        }

        private void InitObject(Profile businessContract)
        {
            Id = Guid.NewGuid();
            TransactionID = businessContract.TransactionID;
            BusinessContractDTO = businessContract;
            TransactionTime = businessContract.TransactedTime;
        }

        public ContractTransaction(string bindingId, string name, Profile businessContract, TransactionReceipt transactionConfirmation)
        {
            InitObject(businessContract);

            TransactionConfirmation = transactionConfirmation;
            BindingId = transactionConfirmation.ContractAddress;
            // Name = name;
        }

        //Key for Mongo......
        public Guid Id { get; set; }

        public bool IsActiveTransaction { get; set; }
        //Should be one per each deployed Smart Contract
        public string ContractID { get; set; }
        //Should be assigned per each transaction
        public string TransactionID { get; set; }
        //Business DTO
        public Profile BusinessContractDTO { get; set; }
        public DateTimeOffset TransactionTime { get; set; }
        public TransactionReceipt TransactionConfirmation { get; set; }
        public string Name { get; set; }
        public string BindingId { get; set; }

    }
}