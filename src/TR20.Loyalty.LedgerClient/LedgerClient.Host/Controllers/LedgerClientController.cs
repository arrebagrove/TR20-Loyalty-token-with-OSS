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

        private string HTTPRPCEndpoint;
        private string APPAccount;

        public LedgerClientController(IConfiguration configuration)
        {
            _configuration = configuration;
            HTTPRPCEndpoint = _configuration["HTTPRPCEndPoint"];
            APPAccount = _configuration["APPAccount"];
        }

        [HttpPost]
        [Route("SetupToken")]
        public async Task<ActionResult<TokenInfo>> SetupToken(BigInteger TotalAmountToken,
                                                        string Name,
                                                        byte Decimal,
                                                        string Symbol)
        {
            ERC20Service erc20Service = new ERC20Service(this.HTTPRPCEndpoint, this.APPAccount);
            return await erc20Service.DeployERC20Contract(Name, Symbol, TotalAmountToken, Decimal);
        }

        [HttpPost]
        [Route("GetBalance")]
        public async Task<ActionResult<BigInteger>> GetBalance(string tokenContractAddress, string account)
        {
            ERC20Service erc20Service = new ERC20Service(this.HTTPRPCEndpoint, this.APPAccount);
            return await erc20Service.GetBalanceAsync(tokenContractAddress, account);
        }

        [HttpPost]
        [Route("TransferFrom")]
        public async Task<ActionResult<bool>> TransferFrom(string tokenContractAddress, string loginAccountAddress, string senderAddress, string recepientAddress, Decimal amount)
        {
            ERC20Service erc20Service = new ERC20Service(this.HTTPRPCEndpoint, loginAccountAddress);
            return await erc20Service.TransferFromAsync(tokenContractAddress, senderAddress, recepientAddress, new BigInteger(amount));
        }

        [HttpPost]
        [Route("Transfer")]
        public async Task<ActionResult<bool>> Transfer(string tokenContractAddress, string loginAccountAddress, string recepientAddress, Decimal amount)
        {
            ERC20Service erc20Service = new ERC20Service(this.HTTPRPCEndpoint, loginAccountAddress);
            return await erc20Service.TransferAsync(tokenContractAddress, recepientAddress, new BigInteger(amount));
        }

        [HttpPost]
        [Route("Approve")]
        public async Task<ActionResult<bool>> Approve(string tokenContractAddress, string loginAccountAddress, string spenderAccress, Decimal amount)
        {
            ERC20Service erc20Service = new ERC20Service(this.HTTPRPCEndpoint, loginAccountAddress);
            return await erc20Service.ApproveAsync(tokenContractAddress, spenderAccress, new BigInteger(amount));
        }


        [HttpPost]
        [Route("GetTokenInfo")]
        public async Task<ActionResult<TokenInfo>> GetTokenInfo(string tokenContractAddress)
        {
            ERC20Service erc20Service = new ERC20Service(this.HTTPRPCEndpoint, this.APPAccount);
            return await erc20Service.GetTokenInfoAsync(tokenContractAddress);
        }

        [HttpPost]
        [Route("DeployTokenRewarderContract")]
        public async Task<ActionResult<string>> DeployTokenRewarder(string tokenContractAddress, string tokenOwnerAccountAddress, string rewarderName)
        {
            TokenRewarderService tokenRewarderService = new TokenRewarderService(
                this.HTTPRPCEndpoint,
                tokenOwnerAccountAddress);

            return await tokenRewarderService.DeployTokenRewarderContract(tokenContractAddress, rewarderName);
        }

        [HttpPost]
        [Route("SendRewardToken")]
        public async Task<bool> SendRewardToken(string tokenContractAddress, string tokenContractOwner, string receipientAddress, Decimal TokenAmount)
        {
            TokenRewarderService tokenRewarderService = new TokenRewarderService(
                this.HTTPRPCEndpoint,
                tokenContractOwner);

            return await tokenRewarderService.SendRewardTokenAsync(tokenContractAddress, receipientAddress, new BigInteger(TokenAmount));
        }

        [HttpPost]
        [Route("DeployExchangeTokenContract")]
        public async Task<ActionResult<string>> DeployExchangeToken()
        {
            ExchangeTokenService exchangeTokenService = new ExchangeTokenService(
                this.HTTPRPCEndpoint,
                this.APPAccount);

            return await exchangeTokenService.DeployExchangeTokenContract();
        }

        [HttpPost]
        [Route("ExchangeToken")]
        public async Task<bool> ExchangeToken(
            string tokenExchangecontractAddress,
            string exchangeMarketAddress,
            string exchangerAccountAddress,
            string sourceTokenContractAddress,
            string targetTokenContractAddress,
            decimal exchangeRaptePercentage,
            decimal TokenAmount
            )
        {
            ExchangeTokenService exchangeTokenService = new ExchangeTokenService(
                this.HTTPRPCEndpoint,
                this.APPAccount
                );


            return await exchangeTokenService.ExchangeTokens(
                    tokenExchangecontractAddress,
                    exchangeMarketAddress,
                    exchangerAccountAddress,
                    sourceTokenContractAddress,
                    targetTokenContractAddress,
                    new BigInteger(exchangeRaptePercentage),
                    new BigInteger(TokenAmount));
        }




    }
}
