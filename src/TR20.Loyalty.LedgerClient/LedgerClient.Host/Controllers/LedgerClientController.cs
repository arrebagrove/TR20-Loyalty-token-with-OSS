using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TR20.Loyalty.LedgerClient.Lib;

namespace TR20.Loyalty.LedgerClient.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerClientController : ControllerBase
    {
        private IConfiguration _configuration;
        private ERC20FactoryService erc20FactoryService;
        private ERC20Service erc20Service;

        private string HTTPRPCEndpoint;
        private string APPAccount;

        public LedgerClientController(IConfiguration configuration)
        {
            _configuration = configuration;
            HTTPRPCEndpoint = _configuration["HTTPRPCEndPoint"];
            APPAccount = _configuration["APPAccount"];
        }

        [HttpPost]
        [Route("DeployESC20TokenFactoryContract")]
        public async Task<ActionResult<string>> DeployESC20TokenFactoryContract()
        {
            return await ERC20FactoryService.DeployESC20FactoryContract(this.HTTPRPCEndpoint, this.APPAccount);
        }

        [HttpPost]
        [Route("IsERP20")]
        public async Task<ActionResult<bool>> IsERP20(string tokenFactoryContractAddress, string tokenContractAddress)
        {
            ERC20FactoryService erc20FactoryService = new ERC20FactoryService(this.HTTPRPCEndpoint, tokenContractAddress ,this.APPAccount);
            return await erc20FactoryService.IsERP20Async(tokenFactoryContractAddress, tokenContractAddress);
        }

        [HttpPost]
        [Route("SetupToken")]
        public async Task<ActionResult<TokenInfo>> SetupToken(string tokenFactoryContractAddress, BigInteger TotalAmountToken,
                                                        string Name,
                                                        byte Decimal,
                                                        string Symbol)
        {
            ERC20FactoryService erc20FactoryService = new ERC20FactoryService(this.HTTPRPCEndpoint, tokenFactoryContractAddress ,this.APPAccount);
            return await erc20FactoryService.SetupTokenAsync(tokenFactoryContractAddress, TotalAmountToken, Name, Decimal, Symbol);
        }

        [HttpPost]
        [Route("GetBalance")]
        public async Task<ActionResult<BigInteger>> GetBalance(string tokenContractAddress, string account)
        {
            ERC20Service erc20Service = new ERC20Service(this.HTTPRPCEndpoint, tokenContractAddress, account);
            return await erc20Service.GetBalanceAsync(account);
        }
    }
}
