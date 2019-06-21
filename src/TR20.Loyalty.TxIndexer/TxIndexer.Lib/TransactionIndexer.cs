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

        public async Task<bool> LogTransaction(ContractTransaction transactionInformation, string description = null)
        {
            if (!string.IsNullOrEmpty(description))
            {
                transactionInformation.BusinessContractDTO.Description = description;
            }

            await _transactionIndexRepository.SaveAsync(transactionInformation);
            return true;
        }
    }
}