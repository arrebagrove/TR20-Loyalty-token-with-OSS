﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TR20.Loyalty.TxTracker.Library;
using TR20.Loyalty.OffChainRepository.Mongo.Model;


namespace TR20.Loyalty.TxTracker.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTrackerContoller : ControllerBase
    {
        private IConfiguration _configuration;
        private TransactionTracker _trackingservice;

        public TransactionTrackerContoller(IConfiguration configuration)
        {
            _configuration = configuration;
            _trackingservice = new TransactionTracker(_configuration["offchain_connectionstring"]);
        }

        //[HttpPost()]
        //[Route("GetTransactions")]
        //public IEnumerable<ContractTransaction> GetTransactionInformation([FromBody]string BindingId)
        //{
        //    var txObjects = _trackingservice.GetTransactionHistoryFromOffchain(BindingId);
        //    return txObjects;
        //}

        [HttpPost()]
        [Route("GetTransactionHistory")]
        public IEnumerable<ContractTransaction> GetTransactionInformationByAccount(string tokenContractAddress, string account)
        {
            var txObjects = _trackingservice.GetTransactionHistory(tokenContractAddress, account);
            return txObjects;
        }

        //[HttpPost()]
        //[Route("GetCurrentProfileStatusByCitizenIdentifier")]
        //public ContractTransaction GetCurrentProfileStatusByCitizenIdentifier([FromBody]string CitizenIdentifier)
        //{
        //    var txObject = _trackingservice.GetCurrentCitizenProfileFromOffchainByCitizenIdentifier(CitizenIdentifier);
        //    return txObject;
        //}

        //[HttpPost()]
        //[Route("GetCurrentCitizenProfileFromOffchainByBindingId")]
        //public ContractTransaction GetCurrentCitizenProfileFromOffchainByBindingId([FromBody]string Bindingid)
        //{
        //    var txObject = _trackingservice.GetCurrentCitizenProfileFromOffchainByBindingId(Bindingid);
        //    return txObject;
        //}

        //[HttpPost()]
        //[Route("GetTransactionsByTxEntityId")]
        //public ContractTransaction GetTransactionInformationByTxEntityId([FromBody]string EntityId)
        //{
        //    var txObject = _trackingservice.GetTransactionHistoryByTxEntityId(EntityId);
        //    return txObject;
        //}

        //[HttpPost()]
        //[Route("GetCompletedCitizenProfiles")]
        //public IEnumerable<ContractTransaction> GetCompletedCitizenProfiles(string state)
        //{
        //    var txObject = _trackingservice.GetCompletedCitizenProfiles(state);
        //    return txObject;
        //}

        //[HttpPost()]
        //[Route("GetIncompletedCitizenProfiles")]
        //public IEnumerable<ContractTransaction> GetIncompletedCitizenProfiles(string state)
        //{
        //    var txObject = _trackingservice.GetIncompletedCitizenProfiles(state);
        //    return txObject;
        //}

        //[HttpPost()]
        //[Route("GetCitizenProfiles")]
        //public IEnumerable<ContractTransaction> GetCitizenProfiles(string state)
        //{
        //    var txObject = _trackingservice.GetCitizenProfiles(state);
        //    return txObject;
        //}

        //[HttpPost()]
        //[Route("GetCitizenProfilesNotApprovedHealthcareplan")]
        //public IEnumerable<ContractTransaction> GetCitizenProfilesNotApprovedHealthcareplan(string state)
        //{
        //    var txObject = _trackingservice.GetCitizenProfilesNotApprovedHealthcareplan(state);
        //    return txObject;
        //}

        //[HttpPost()]
        //[Route("GetCitizenProfilesApprovedHealthcareplan")]
        //public IEnumerable<ContractTransaction> GetCitizenProfilesApprovedHealthcareplan(string state)
        //{
        //    var txObject = _trackingservice.GetCitizenProfilesApprovedHealthcareplan(state);
        //    return txObject;
        //}

        //[HttpPost()]
        //[Route("GetCitizenProfilesbyHealthcareByEligibility")]
        //public IEnumerable<ContractTransaction> GetCitizenProfilesbyHealthcareByEligibility(string state, CarePlanEligibilityStatus status)
        //{
        //    var txObject = _trackingservice.GetCitizenProfilesbyHealthcareByEligibility(state, status);
        //    return txObject;
        //}


        //[HttpPost()]
        //[Route("GetCitizenProfilesNotAssignedHealthcareEligibility")]
        //public IEnumerable<ContractTransaction> GetCitizenProfilesNotAssignedHealthcareEligibility(string state)
        //{
        //    var txObject = _trackingservice.GetCitizenProfilesNotAssignedHealthcareEligibility(state);
        //    return txObject;
        //}
    }
}
