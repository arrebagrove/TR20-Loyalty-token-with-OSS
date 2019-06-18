using System;
using System.Collections.Generic;
using System.Text;

namespace TR20.Loyalty.OffChainRepository.Mongo.ModelBase
{
    /// <summary>
    /// After desiging Smart Contract, The Business DTO Entities should be added 
    /// </summary>
    public interface IConduentBusinessEntity
    {
        //    string ContractID { get; set; }

        string TransactionID { get; set; }

        DateTime TransactedTime { get; set; }


        /// <summary>
        /// /have to implemented
        /// </summary>
        string Description { get; set; }

    }
}