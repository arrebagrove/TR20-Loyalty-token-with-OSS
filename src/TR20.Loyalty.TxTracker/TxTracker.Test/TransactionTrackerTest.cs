using Microsoft.VisualStudio.TestTools.UnitTesting;
using TR20.Loyalty.TxTracker.Library;

namespace TxTracker.Test
{
    [TestClass]
    public class TransactionTrackerTest
    {
        static string mongoConnection = "mongodb://mongoloyalty:t51hIYsmmBBEuunr72YJrThgOP7VwtYT09lTcr581TISc7vr6ToOBRc6AMgnpwxGUjuckKkLoTW7okZ8eMQeKA==@mongoloyalty.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";


        [TestMethod]
        public void GetTransactionHistory()
        {
            var txTracker = new TransactionTracker(mongoConnection);
            var results = txTracker.GetTransactionHistory("0xac8bf74f1b51b923507bea339c74b3b18482e3b0","0x1F9B9484188b42C01f4aaC308D4848659901F17b");

            Assert.IsTrue(results.GetEnumerator().MoveNext());

        }
    }
}
