using Microsoft.VisualStudio.TestTools.UnitTesting;
using TR20.Loyalty.LedgerClient.Lib;
using System.Diagnostics;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TR20.Loyalty.LedgerClient.LedgerClient.Test
{
    [TestClass]
    public class LedgerClientTest
    {
        static string tokenFactoryContractAddress = "0xa82fd99261b16f92f9f7bb7010bb39b6d845603b";
        static string tokenContractAddress = "0xac8bf74f1b51b923507bea339c74b3b18482e3b0"; //JSON

        [TestInitialize]
        public void init()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }

        [TestMethod]
        public void GetSecretKey()
        {
            TR20.Loyalty.LedgerClient.Lib.KeyVaultClient client = new KeyVaultClient();
            var result = client.ReadSecret("0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD").GetAwaiter().GetResult().Value;

            
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
                "Jason's Token",
                18,
                "JSON").GetAwaiter().GetResult();


            var logObj = txReciept.Logs;

            var deployedTokenAddress = logObj.SelectToken("[0].address").ToString();

            Trace.WriteLine(deployedTokenAddress); 
            Trace.WriteLine(txReciept.Status);
        }

        [TestMethod]
        public void CheckEIP20()
        {
            ERC20Factory factory = new ERC20Factory(
           "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
            "0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD");

            var result = factory.CheckEIP20("0xa82fd99261b16f92f9f7bb7010bb39b6d845603b", LedgerClientTest.tokenContractAddress).GetAwaiter().GetResult();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEIP20()
        {
            ERC20Factory factory = new ERC20Factory(
           "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
            "0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD");

            var result = factory.IsEIP20("0xa82fd99261b16f92f9f7bb7010bb39b6d845603b", LedgerClientTest.tokenContractAddress).GetAwaiter().GetResult();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetTokenInfo()
        {
            ERC20 eRC20 = new ERC20(
           "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
           LedgerClientTest.tokenContractAddress,
            "0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD");

            var result = eRC20.GetTokenInfoAsync().GetAwaiter().GetResult();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBalance()
        {
            ERC20 eRC20 = new ERC20(
           "https://coe01.blockchain.azure.com:3200/Mi8hWUljBk9zrXxH0dq0Cpmt",
           LedgerClientTest.tokenContractAddress,
            "0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD");

            var result = eRC20.GetBalanceAsync("0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD").GetAwaiter().GetResult();

            Assert.IsTrue(result>0);
        }

        //[TestMethod]
        //public void Transfer()
        //{

        //}



    }
}
