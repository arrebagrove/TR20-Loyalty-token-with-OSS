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
        public async Task<ActionResult<LedgerClient.Proxy.TokenInfo>> CreateERC20Token(string tokenFactoryContractAddress, string TotalAmountToken,
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
        public async Task<ActionResult<bool>> TransferFrom(string tokenContractAddress, string senderAddress, string recepientAddress, string amount)
        {
            return await _proxyFactory.CreateLedgerProxy().TransferFromAsync(tokenContractAddress, senderAddress, recepientAddress, amount);
        }

        [HttpPost]
        [Route("Transfer")]
        public async Task<ActionResult<bool>> Transfer(string tokenContractAddress, string recepientAddress, string amount)
        {
            return await _proxyFactory.CreateLedgerProxy().TransferAsync(tokenContractAddress, recepientAddress, amount);
        }

        [HttpPost]
        [Route("Approve")]
        public async Task<ActionResult<bool>> Approve(string tokenContractAddress, string account, string spenderAccress, string amount)
        {
            return await _proxyFactory.CreateLedgerProxy().ApproveAsync(tokenContractAddress, account, spenderAccress, amount);
        }

        [HttpPost]
        [Route("GetTokenInfo")]
        public async Task<ActionResult<LedgerClient.Proxy.TokenInfo>> GetTokenInfo(string tokenContractAddress)
        {
            return await _proxyFactory.CreateLedgerProxy().GetTokenInfoAsync(tokenContractAddress);
        }

        [HttpPost()]
        [Route("GetTransactionHistory")]
        public Task<ICollection<TxTracker.Proxy.ContractTransaction>> GetTransactionInformationByAccount(string account)
        {
            return  _proxyFactory.CreateTrackerProxy().GetTransactionInformationByAccountAsync(account);
        }
    }
}
