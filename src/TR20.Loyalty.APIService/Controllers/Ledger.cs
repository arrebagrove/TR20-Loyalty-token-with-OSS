using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TR20.Loyalty.APIService.Controllers
{
    internal class ProxyFactory
    {
        private string HTTPLedgerServiceEndpoint;
        private string HTTPTrackerServiceEndpoint;

        public ProxyFactory(IConfiguration configuration)
        {
            HTTPLedgerServiceEndpoint = configuration["LedgerServiceEndPoint"];
            HTTPTrackerServiceEndpoint = configuration["TrackerServiceEndPoint"];
        }

        public LedgerClient.Proxy.LedgerServiceProxy CreateLedgerProxy()
        {
            return new LedgerClient.Proxy.LedgerServiceProxy(HTTPLedgerServiceEndpoint, new System.Net.Http.HttpClient());
        }

        public TxTracker.Proxy.TrackerServiceProxy CreateTrackerProxy()
        {
            return new TxTracker.Proxy.TrackerServiceProxy(HTTPTrackerServiceEndpoint, new System.Net.Http.HttpClient());
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class Ledger : ControllerBase
    {
        private ProxyFactory _proxyFactory;
        public Ledger(IConfiguration configuration)
        {
            _proxyFactory = new ProxyFactory(configuration);
        }

        [HttpPost]
        [Route("CreateERC20Token")]
        public async Task<ActionResult<LedgerClient.Proxy.TokenInfo>> CreateERC20Token(string tokenFactoryContractAddress, double TotalAmountToken,
                                                        string Name,
                                                        int Decimal,
                                                        string Symbol)
        {
            return await _proxyFactory.CreateLedgerProxy().SetupTokenAsync(tokenFactoryContractAddress, TotalAmountToken, Name, Decimal, Symbol);
        }

        [HttpPost]
        [Route("CreateERC20TokenFactory")]
        public async Task<ActionResult<string>> CreateERC20TokenFactory()
        {
            return await _proxyFactory.CreateLedgerProxy().DeployESC20TokenFactoryContractAsync();
        }

        [HttpPost]
        [Route("IsERP20")]
        public async Task<ActionResult<bool>> IsERP20(string tokenFactoryContractAddress, string tokenContractAddress)
        {
            return await _proxyFactory.CreateLedgerProxy().IsERP20Async(tokenFactoryContractAddress, tokenContractAddress);
        }

        [HttpPost]
        [Route("GetBalance")]
        public async Task<ActionResult<string>> GetBalance(string tokenContractAddress, string account)
        {
            return await _proxyFactory.CreateLedgerProxy().GetBalanceAsync(tokenContractAddress, account);
        }

        [HttpPost]
        [Route("TransferFrom")]
        public async Task<ActionResult<bool>> TransferFrom(string tokenContractAddress, string delegatorAccountAddress,string senderAddress, string recepientAddress, double amount)
        {
            return await _proxyFactory.CreateLedgerProxy().TransferFromAsync(tokenContractAddress, delegatorAccountAddress, senderAddress, recepientAddress, amount);
        }

        [HttpPost]
        [Route("Transfer")]
        public async Task<ActionResult<bool>> Transfer(string tokenContractAddress, string senderAccountAddress,string recepientAddress, double amount)
        {
            return await _proxyFactory.CreateLedgerProxy().TransferAsync(tokenContractAddress, senderAccountAddress, recepientAddress, amount);
        }

        [HttpPost]
        [Route("Approve")]
        public async Task<ActionResult<bool>> Approve(string tokenContractAddress, string approverAccountAddress, string spenderAccress, double amount)
        {
            return await _proxyFactory.CreateLedgerProxy().ApproveAsync(tokenContractAddress, approverAccountAddress, spenderAccress, amount);
        }

        [HttpPost]
        [Route("GetTokenInfo")]
        public async Task<ActionResult<LedgerClient.Proxy.TokenInfo>> GetTokenInfo(string tokenContractAddress)
        {
            return await _proxyFactory.CreateLedgerProxy().GetTokenInfoAsync(tokenContractAddress);
        }

        [HttpPost()]
        [Route("GetTransactionHistory")]
        public Task<ICollection<TxTracker.Proxy.ContractTransaction>> GetTransactionInformationByAccount(string tokenContractAddress, string account)
        {
            return  _proxyFactory.CreateTrackerProxy().GetTransactionInformationByAccountAsync(tokenContractAddress, account);
        }

        [HttpPost]
        [Route("DeployTokenRewarderContract")]
        public async Task<ActionResult<string>> DeployTokenRewarder(string tokenContractAddress, string tokenOwnerAccountAddress, string rewarderName)
        {
            return await _proxyFactory.CreateLedgerProxy().DeployTokenRewarderAsync(tokenContractAddress, tokenOwnerAccountAddress, rewarderName);
        }

        [HttpPost]
        [Route("SendRewardToken")]
        public async Task<bool> SendRewardToken(string tokenContractAddress, string tokenContractOwner,string receipientAddress, double TokenAmount)
        {
            return await _proxyFactory.CreateLedgerProxy().SendRewardTokenAsync(tokenContractAddress, tokenContractOwner, receipientAddress, TokenAmount);
        }

        [HttpPost]
        [Route("DeployExchangeTokenContract")]
        public async Task<ActionResult<string>> DeployExchangeToken()
        {
            return await _proxyFactory.CreateLedgerProxy().DeployExchangeTokenAsync();
        }

        [HttpPost]
        [Route("ExchangeToken")]
        public async Task<bool> ExchangeToken(
            string tokenExchangecontractAddress,
            string exchangeMarketAddress,
            string exchangerAccountAddress,
            string sourceTokenContractAddress,
            string targetTokenContractAddress,
            int exchangeRatePercentage,
            int TokenAmount
            )
        {
            return await _proxyFactory.CreateLedgerProxy().ExchangeTokenAsync(
                tokenExchangecontractAddress,
                exchangeMarketAddress,
                exchangerAccountAddress,
                sourceTokenContractAddress,
                targetTokenContractAddress,
                exchangeRatePercentage,
                TokenAmount
                );
        }

    }
}
