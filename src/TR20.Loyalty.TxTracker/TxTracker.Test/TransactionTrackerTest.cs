using Microsoft.VisualStudio.TestTools.UnitTesting;
using TR20.Loyalty.TxTracker.Library;

namespace TxTracker.Test
{
    [TestClass]
    public class TransactionTrackerTest
    {
        static string mongoConnection = "mongodb://mongoloyalty:tlayMnZYEGwrhduOH2MYlDnaUSZ7HDdajN8GgvdQausiPxRrahHWrLVMhVwMRvaIiy74aa5T43KRR2VxubEBGw==@mongoloyalty.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";


        [TestMethod]
        public void GetTransactionHistory()
        {
            var txTracker = new TransactionTracker(mongoConnection);
            var results = txTracker.GetTransactionHistory("0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD");

            Assert.IsTrue(results.GetEnumerator().MoveNext());

        }
    }
}
