using Microsoft.VisualStudio.TestTools.UnitTesting;
using TR20.Loyalty.LedgerClient.Lib;
using System.Diagnostics;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TR20.Loyalty.LedgerClient.Proxy;

namespace TR20.Loyalty.LedgerClient.LedgerClient.Test
{
    [TestClass]
    public class LedgerClientTest
    {
        static string tokenFactoryContractAddress = "0xa82fd99261b16f92f9f7bb7010bb39b6d845603b";
        static string tokenContractAddress = "0xac8bf74f1b51b923507bea339c74b3b18482e3b0"; //JSON

        static string applicationAccount = "0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD";
        static string user1Account = "0x1F9B9484188b42C01f4aaC308D4848659901F17b";
        static string user2Account = "0x0f5DDacC06A44163badc5eD4f09dE0d3eFfC2716";


        static TR20.Loyalty.LedgerClient.Proxy.LedgerServiceProxy ledgerServiceProxy;
        [TestInitialize]
        public void init()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            LedgerClientTest.ledgerServiceProxy = new LedgerServiceProxy(
                "http://localhost:8080",
                new System.Net.Http.HttpClient()
                );
        }

        [TestMethod]
        public void GetSecretKey()
        {
            TR20.Loyalty.LedgerClient.Lib.KeyVaultClient client = new KeyVaultClient();
            var result = client.ReadSecret(applicationAccount).GetAwaiter().GetResult().Value;


            Assert.IsTrue(result.Equals("dcb759d475b49a4880d6bca41cd0809ef2eaec48c10d60915c63df902f2490b3"));

            Trace.WriteLine(result);

        }

        [TestMethod]
        public void SetupToken()
        {
            ERC20Factory factory = new ERC20Factory(
                "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
                 "0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD");

            var txReciept = factory.SetupTokenAsync(LedgerClientTest.tokenFactoryContractAddress,
                1000000000000000,
                "CAR TOKEN",
                18,
                "CAR").GetAwaiter().GetResult();


            var logObj = txReciept.Logs;

            var deployedTokenAddress = logObj.SelectToken("[0].address").ToString();

            Trace.WriteLine(deployedTokenAddress);
            Trace.WriteLine(txReciept.Status);
        }

        //[TestMethod]
        //public void SetupToken_WebAPI()
        //{
        //    var result = LedgerClientTest.ledgerServiceProxy.SetupTokenAsync(
        //        LedgerClientTest.tokenFactoryContractAddress,
        //        "10000000",
        //        "Airline Token" ,
        //        8,
        //        "AIR").GetAwaiter().GetResult();

        //    Assert.IsNotNull(result);
        //}




        [TestMethod]
        public void CheckEIP20()
        {
            ERC20Factory factory = new ERC20Factory(
           "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
            applicationAccount);

            var result = factory.CheckEIP20(LedgerClientTest.tokenFactoryContractAddress, LedgerClientTest.tokenContractAddress).GetAwaiter().GetResult();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEIP20()
        {
            ERC20Factory factory = new ERC20Factory(
           "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
            applicationAccount);

            var result = factory.IsEIP20(LedgerClientTest.tokenFactoryContractAddress, LedgerClientTest.tokenContractAddress).GetAwaiter().GetResult();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEIP20_WebAPI()
        {
            var result = LedgerClientTest.ledgerServiceProxy.IsERP20Async(LedgerClientTest.tokenFactoryContractAddress, LedgerClientTest.tokenContractAddress).GetAwaiter().GetResult();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetTokenInfo()
        {
            ERC20 eRC20 = new ERC20(
           "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
           LedgerClientTest.tokenContractAddress,
            applicationAccount);

            var result = eRC20.GetTokenInfoAsync().GetAwaiter().GetResult();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTokenInfo_WebAPI()
        {

            var result = LedgerClientTest.ledgerServiceProxy.GetTokenInfoAsync(LedgerClientTest.tokenContractAddress).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBalance()
        {
            ERC20 eRC20 = new ERC20(
           "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
           LedgerClientTest.tokenContractAddress,
            applicationAccount);

            var result = eRC20.GetBalanceAsync(applicationAccount).GetAwaiter().GetResult();

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetBalance_WebAPI()
        {

            var result = LedgerClientTest.ledgerServiceProxy.GetBalanceAsync(LedgerClientTest.tokenContractAddress, LedgerClientTest.applicationAccount).GetAwaiter().GetResult();
            Assert.IsTrue(Decimal.Parse(result) > 0);
        }

        [TestMethod]
        public void Transfer()
        {
            ERC20Service eRC20 = new ERC20Service(
                      "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
                      LedgerClientTest.tokenContractAddress,
                       applicationAccount);

            var result = eRC20.TransferAsync(user1Account, 1).GetAwaiter().GetResult();
            var balance = eRC20.GetBalanceAsync(user1Account).GetAwaiter().GetResult();

            Assert.IsTrue(balance > 0);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Transfer_WebAPI()
        {
            //ERC20 eRC20 = new ERC20(
            //          "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
            //          LedgerClientTest.tokenContractAddress,
            //           applicationAccount);

            //var result = eRC20.TransferAsync(user1Account, 1).GetAwaiter().GetResult();
            //var balance = eRC20.GetBalanceAsync(user1Account).GetAwaiter().GetResult();

            //Assert.IsTrue(balance > 0);
            //Assert.IsNotNull(result);
            var result = LedgerClientTest.ledgerServiceProxy.TransferAsync(LedgerClientTest.tokenContractAddress, LedgerClientTest.applicationAccount, LedgerClientTest.user1Account, 1).GetAwaiter().GetResult();
            var balance = LedgerClientTest.ledgerServiceProxy.GetBalanceAsync(LedgerClientTest.tokenContractAddress, LedgerClientTest.user1Account).GetAwaiter().GetResult();

            Assert.IsTrue(Decimal.Parse(balance) > 0);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Approve()
        {
            ERC20 eRC20 = new ERC20(
                                 "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
                                 LedgerClientTest.tokenContractAddress,
                                  user1Account);

            var result = eRC20.ApproveAsync(applicationAccount, 10000).GetAwaiter().GetResult();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Allowance()
        {
            ERC20 eRC20 = new ERC20(
                                 "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
                                 LedgerClientTest.tokenContractAddress,
                                  applicationAccount);
            var allowedMoney = eRC20.AllowanceAsync(applicationAccount, user1Account).GetAwaiter().GetResult();

            Assert.IsTrue(allowedMoney > 0);
        }

        [TestMethod]
        public void Transferfrom()
        {
            ERC20 eRC20 = new ERC20(
                      "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
                      LedgerClientTest.tokenContractAddress,
                       applicationAccount);

            var result = eRC20.TransferFromAsync(user1Account, user2Account, 1).GetAwaiter().GetResult();
            var balance_user2 = eRC20.GetBalanceAsync(user2Account).GetAwaiter().GetResult();
            var balance_user1 = eRC20.GetBalanceAsync(user1Account).GetAwaiter().GetResult();

            Assert.IsTrue(balance_user1 > 0);
            Assert.IsTrue(balance_user2 > 0);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeployRewardContract()
        {
            TokenRewarder rewarder = new TokenRewarder("https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
                       "0x0071df3755926F5C38b4cb68d550807db74DcbAc"); //airline
            var txReciept = rewarder.DeployContractAsync("ReadyAir", "0x505d2370e8e2afcd65869fda07dcd081fe2d0c03").GetAwaiter().GetResult();
            var deployedAddress = txReciept.ContractAddress;

            Assert.IsNotNull(deployedAddress);
        }


        [TestMethod]
        public void ReadInfosFromContract()
        {
            TokenRewarder rewarder = new TokenRewarder("https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
                     "0x0071df3755926F5C38b4cb68d550807db74DcbAc"); //airline
            var info = rewarder.GetContractInformation("0xf10e562e12569e313d300765bab04b14aed7ba16").GetAwaiter().GetResult();

            Assert.IsNotNull(info);
        }

        [TestMethod]
        public void SendRewardToken()
        {
            TokenRewarder rewarder = new TokenRewarder("https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
                       "0x0071df3755926F5C38b4cb68d550807db74DcbAc"); //airline

            var txRecipt =  rewarder.SendRewardTokenAsync("0xf10e562e12569e313d300765bab04b14aed7ba16",
                "0x1F9B9484188b42C01f4aaC308D4848659901F17b", 10).GetAwaiter().GetResult(); //airline token to user1

            Assert.IsNotNull(txRecipt);
        }

        [TestMethod]
        public void DeployExchangeTokenContract()
        {
            ExchangeToken exchangeToken = new ExchangeToken("https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
                       LedgerClientTest.applicationAccount); //application

            var txReceipt = exchangeToken.DeployContractAsync().GetAwaiter().GetResult();

            Assert.IsNotNull(txReceipt);
        }

        [TestMethod]
        public void ExchangeTokens()
        {
            ExchangeToken exchangeToken = new ExchangeToken("https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
                       LedgerClientTest.applicationAccount); //application

            var txRecipt = exchangeToken.ExchangeTokens(
                "0xbd61a163aa1f75712edc8cfd191facc25593c4f4", //exchange Token contract address
                "0xd924ae5f425c723830a7962042eff5391641d8d5", //Marketplace (application) address
                "0x5468f00d7ff611e574197ce822c35a0be78242f5", //user who wants to exchange token
                "0x86265a6295f571a6b75210a6b9b72b562cc7def8", // air token address
                "0x667423be3657b37bd8b02d1bb5ebed24457fb2b4", // car token address
                120, // exchange rate percentage 120% ( 100 AIR = 120 CAR )
                100).GetAwaiter().GetResult();

            Assert.IsNotNull(txRecipt);
        }

    }
}
