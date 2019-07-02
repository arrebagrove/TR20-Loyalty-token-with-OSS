using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using TR20.Loyalty.OffChainRepository.Mongo;
using TR20.Loyalty.OffChainRepository.Mongo.Model;
using TR20.Loyalty.OffChainRepository.Mongo.ModelBase;

namespace TR20.Loyalty.TxTracker.Library
{
    public class TransactionTracker
    {
        private readonly IRepository<ContractTransaction, Guid> _transactionIndexRepository;

        public TransactionTracker(string mongoconnString)
        {
            _transactionIndexRepository =
                  new BusinessTransactionRepository<ContractTransaction, Guid>(new MongoClient(mongoconnString));

        }

        public IEnumerable<ContractTransaction> GetTransactionHistory(string tokenContractAddress, string account)
        {
            var result = _transactionIndexRepository.FindAll(new GenericSpecification<ContractTransaction>(x => x.BusinessContractDTO.TokenAddress == tokenContractAddress &&
                                                                                                            ((x.BusinessContractDTO.FromAccount == account) ||
                                                                                                            (x.BusinessContractDTO.ToAccount == account))));
            return result;
        }

        //public IEnumerable<ContractTransaction> GetTransactionHistoryByCitizenProfileFromOffchain(string CitizenIdentifier)
        //{
        //    var result = _transactionIndexRepository.FindAll(new GenericSpecification<ContractTransaction>(x => x.BusinessContractDTO.CitizenIdentifier == CitizenIdentifier));
        //    return result;
        //}


        //public ContractTransaction GetCurrentCitizenProfileFromOffchainByCitizenIdentifier(string CitizenIdentifier)
        //{
        //    var result = _transactionIndexRepository.Find(new GenericSpecification<ContractTransaction>(x => x.BusinessContractDTO.CitizenIdentifier == CitizenIdentifier &&
        //                                                                                                        x.IsActiveTransaction));
        //    return result;
        //}

        ////EntityId will be Business Entity's Id fields
        //public ContractTransaction GetTransactionHistoryByTxEntityId(string EntityId)
        //{
        //    var result = _transactionIndexRepository.Find(new GenericSpecification<ContractTransaction>(x => x.Id == Guid.Parse(EntityId)));
        //    return result;
        //}

        
        //public IEnumerable<ContractTransaction> GetCompletedCitizenProfiles(string State)
        //{
        //    var result = _transactionIndexRepository.FindAll(new GenericSpecification<ContractTransaction>(x => 
        //                                                                                                        (x.BusinessContractDTO.Status == ProfileStatus.ProfileCompleted) && 
        //                                                                                                        (x.BusinessContractDTO.ActiveState == State) && 
        //                                                                                                        (x.BusinessContractDTO.CurrentHealthcarePlan.Eligible) &&
        //                                                                                                        (x.BusinessContractDTO.CurrentHealthcarePlan.CarePlanEligibilityStatus == CarePlanEligibilityStatus.NotAssigned) &&
        //                                                                                                        !x.BusinessContractDTO.CurrentHealthcarePlan.Approved &&
        //                                                                                                        x.IsActiveTransaction));
        //    return result;
        //}

        //public IEnumerable<ContractTransaction> GetIncompletedCitizenProfiles(string State)
        //{
        //    var result = _transactionIndexRepository.FindAll(new GenericSpecification<ContractTransaction>(x =>
        //                                                                                                        (x.BusinessContractDTO.Status == ProfileStatus.ProfileCreated) &&
        //                                                                                                        (x.BusinessContractDTO.ActiveState == State) &&
        //                                                                                                        (x.BusinessContractDTO.CurrentHealthcarePlan == null) &&
        //                                                                                                        x.IsActiveTransaction));
        //    return result;
        //}

        //public IEnumerable<ContractTransaction> GetCitizenProfiles(string State)
        //{
        //    var result = _transactionIndexRepository.FindAll(new GenericSpecification<ContractTransaction>(x =>
        //                                                                                                        (x.BusinessContractDTO.ActiveState == State) &&
        //                                                                                                        x.IsActiveTransaction));
        //    return result;
        //}

        //public IEnumerable<ContractTransaction> GetCitizenProfilesNotApprovedHealthcareplan(string State)
        //{
        //    var result = _transactionIndexRepository.FindAll(new GenericSpecification<ContractTransaction>(x =>
        //                                                                                                        (x.BusinessContractDTO.Status == ProfileStatus.ProfileCompleted) &&
        //                                                                                                        (x.BusinessContractDTO.ActiveState == State) &&
        //                                                                                                        (x.BusinessContractDTO.CurrentHealthcarePlan != null) &&
        //                                                                                                        (x.IsActiveTransaction) && 
        //                                                                                                        (x.BusinessContractDTO.CurrentHealthcarePlan.CarePlanEligibilityStatus != CarePlanEligibilityStatus.NotAssigned) &&
        //                                                                                                        (!x.BusinessContractDTO.CurrentHealthcarePlan.Approved)));
        //    return result;
        //}

        //public IEnumerable<ContractTransaction> GetCitizenProfilesApprovedHealthcareplan(string State)
        //{
        //    var result = _transactionIndexRepository.FindAll(new GenericSpecification<ContractTransaction>(x =>
        //                                                                                                        (x.BusinessContractDTO.Status == ProfileStatus.ProfileCompleted) &&
        //                                                                                                        (x.BusinessContractDTO.ActiveState == State) &&
        //                                                                                                        (x.BusinessContractDTO.CurrentHealthcarePlan != null) &&
        //                                                                                                        x.IsActiveTransaction &&
        //                                                                                                        x.BusinessContractDTO.CurrentHealthcarePlan.CarePlanEligibilityStatus != CarePlanEligibilityStatus.NotAssigned &&
        //                                                                                                         (x.BusinessContractDTO.CurrentHealthcarePlan.Eligible) &&
        //                                                                                                        x.BusinessContractDTO.CurrentHealthcarePlan.Approved));
        //    return result;
        //}

        //public IEnumerable<ContractTransaction> GetCitizenProfilesbyHealthcareByEligibility(string State, CarePlanEligibilityStatus EligibilityStatus)
        //{
        //    var result = _transactionIndexRepository.FindAll(new GenericSpecification<ContractTransaction>(x =>
        //                                                                                                        (x.BusinessContractDTO.Status == ProfileStatus.ProfileCompleted) &&
        //                                                                                                        (x.BusinessContractDTO.ActiveState == State) &&
        //                                                                                                        (x.BusinessContractDTO.CurrentHealthcarePlan != null) &&
        //                                                                                                        x.IsActiveTransaction &&
        //                                                                                                        !x.BusinessContractDTO.CurrentHealthcarePlan.Approved &&
        //                                                                                                         (x.BusinessContractDTO.CurrentHealthcarePlan.Eligible) &&
        //                                                                                                        x.BusinessContractDTO.CurrentHealthcarePlan.CarePlanEligibilityStatus == EligibilityStatus));
        //    return result;
        //}


        //public IEnumerable<ContractTransaction> GetCitizenProfilesNotAssignedHealthcareEligibility(string State)
        //{
        //    var result = _transactionIndexRepository.FindAll(new GenericSpecification<ContractTransaction>(x =>
        //                                                                                                        (x.BusinessContractDTO.Status == ProfileStatus.ProfileCompleted) &&
        //                                                                                                        (x.BusinessContractDTO.ActiveState == State) &&
        //                                                                                                        (x.BusinessContractDTO.CurrentHealthcarePlan != null) &&
        //                                                                                                        x.IsActiveTransaction &&
        //                                                                                                        !x.BusinessContractDTO.CurrentHealthcarePlan.Approved &&
        //                                                                                                         (x.BusinessContractDTO.CurrentHealthcarePlan.Eligible) &&
        //                                                                                                        x.BusinessContractDTO.CurrentHealthcarePlan.CarePlanEligibilityStatus == CarePlanEligibilityStatus.NotAssigned));
        //    return result;
        //}

    }
}