using Microsoft.VisualStudio.TestTools.UnitTesting;
using TR20.Loyalty.TxIndexer.Library;
using TR20.Loyalty.OffChainRepository.Mongo;
using TR20.Loyalty.OffChainRepository.Mongo.Model;
using Nethereum.Hex.HexTypes;

namespace TR20.Loyalty.TxIndexer.Test
{
    [TestClass]
    public class TxIndexerTest
    {
        static string mongoConnection = "mongodb://mongoloyalty:tlayMnZYEGwrhduOH2MYlDnaUSZ7HDdajN8GgvdQausiPxRrahHWrLVMhVwMRvaIiy74aa5T43KRR2VxubEBGw==@mongoloyalty.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

        [TestMethod]
        public void LogTransaction()
        {
            var businessObject = new ContractTransaction(
                "0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD",
                new TokenTransfer()
                {
                    FromAccount = "0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD",
                    ToAccount = "0x1F9B9484188b42C01f4aaC308D4848659901F17b",
                    TokenAddress = "0xac8bf74f1b51b923507bea339c74b3b18482e3b0",
                    TokenAmount = "10",
                    Description = "Test Transaction Logging"
                },
                new TransactionReceipt()
                {
                    TransactionHash = "0xc35a346262f98712ef7216574c10a4f51fb7e7f3322a5b18ffa7fee32a675bb3",
                    BlockHash = "0x8241bc59218ce97022d0210c4ba2f9edd0479c8fe8969808fcfb315910abcf76"
                }, "Json");
            var txLogger = new TransactionIndexer(mongoConnection);
            var result = txLogger.LogTransaction(businessObject).GetAwaiter().GetResult();

            Assert.IsTrue(result);
        }
    }
}
