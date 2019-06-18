using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using TR20.Loyalty.OffChainRepository.Mongo;
using TR20.Loyalty.OffChainRepository.Mongo.Model;
using TR20.Loyalty.OffChainRepository.Mongo.ModelBase;


namespace TR20.Loyalty.TxIndexer.Library
{
    public class TransactionIndexer
    {
        private readonly IRepository<ContractTransaction, Guid> _transactionIndexRepository;
        private string _mongoConnectionString = "";

        public TransactionIndexer(string mongoConnectionString)
        {
            _mongoConnectionString = mongoConnectionString;
            _transactionIndexRepository =
              new BusinessTransactionRepository<ContractTransaction, Guid>(new MongoClient(mongoConnectionString));
        }

        //for Indexer
        public async Task<bool> LogTransaction(ContractTransaction transactionInformation)
        {
            await LogTransaction(transactionInformation);

            return true;
        }

        public async Task<bool> LogTransaction(ContractTransaction transactionInformation, string description = null)
        {
            //Marking previous tx as inactive
            var previousTxs =
                _transactionIndexRepository.FindAll(new GenericSpecification<ContractTransaction>(x => x.BusinessContractDTO.CitizenIdentifier == transactionInformation.BusinessContractDTO.CitizenIdentifier));
            foreach (var item in previousTxs)
            {
                if (item.IsActiveTransaction)
                {
                    item.IsActiveTransaction = false;
                    await _transactionIndexRepository.SaveAsync(item);
                }

            }

            if (!string.IsNullOrEmpty(description))
            {
                transactionInformation.BusinessContractDTO.Description = description;
            }

            transactionInformation.IsActiveTransaction = true;
            await _transactionIndexRepository.SaveAsync(transactionInformation);

            return true;
        }

        //for Indexer
        public async Task<bool> UpdateTransaction(ContractTransaction transactionInformation)
        {
            await _transactionIndexRepository.SaveAsync(transactionInformation);

            return true;
        }

        //public async Task<string> CreateProfile(string citizenName, string address, DateTime DateOfBirth, bool Citizenship, int FederalIncome, int StateIncome)
        //{
        //    var _simulatedDeployConfirmation = prepareDeployObject();
        //    TransactionIndexingServiceAgent txAgent = new TransactionIndexingServiceAgent(_mongoConnectionString);
        //    var result = await txAgent.LogTransaction(_simulatedDeployConfirmation);

        //    return _simulatedDeployConfirmation.BindingId; 
        //    //$"The ESC was deployed successfully, BindingId is : {_simulatedDeployConfirmation.BindingId}"; //result.ToString();
        //}



    }
}