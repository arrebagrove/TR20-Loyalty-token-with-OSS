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

        //[TestMethod]
        //public void SetupToken()
        //{
        //    ERC20Factory factory = new ERC20Factory(
        //        "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
        //         "0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD");

        //    var txReciept = factory.SetupTokenAsync(LedgerClientTest.tokenFactoryContractAddress,
        //        1000000000000000,
        //        "Jason's Token",
        //        18,
        //        "JSON").GetAwaiter().GetResult();


        //    var logObj = txReciept.Logs;

        //    var deployedTokenAddress = logObj.SelectToken("[0].address").ToString();

        //    Trace.WriteLine(deployedTokenAddress);
        //    Trace.WriteLine(txReciept.Status);
        //}

        //[TestMethod]
        //public void SetupToken_WebAPI()
        //{
        //    var result = LedgerClientTest.ledgerServiceProxy.SetupTokenAsync(
        //        LedgerClientTest.tokenFactoryContractAddress,
        //        "10000000",
        //        $"test token{DateTime.Now.Ticks}",
        //        8,
        //        $"foo{DateTime.Now.Ticks}").GetAwaiter().GetResult();

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
            ERC20 eRC20 = new ERC20(
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
            var result = LedgerClientTest.ledgerServiceProxy.TransferAsync(LedgerClientTest.tokenContractAddress, LedgerClientTest.user1Account, "1").GetAwaiter().GetResult();
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

    }
}
